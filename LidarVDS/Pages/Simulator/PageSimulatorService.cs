using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using LidarVDS.Maths;
using LidarVDS.Resources.Values;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace LidarVDS.Pages.Simulator;

public class PageSimulatorService
{
    private PageSimulatorService() {}
    private static class InstanceHolder
    {
        public static readonly PageSimulatorService Instance = new();
        public static readonly PageSimulator Page = new();
    }
    public static PageSimulator GetPage()
    {
        return InstanceHolder.Page;
    }
    public static PageSimulatorService GetInstance()
    {
        return InstanceHolder.Instance;
    }

    private Func<double, double> generator1;
    private Func<double, double> generator2;

    /**
     * 将数据源更新为 几何重叠因子 相关图像
     */
    public void ChangeDataSource_GOF()
    {
        InstanceHolder.Page.HorizontalAxisTitle.Content = "m";
        InstanceHolder.Page.VerticalAxisTitle.Content = "%";
        generator1 = i => GeometryOverlapFactor.Instance.Accept(i, GeometryOverlapFactor.AlgTypeEnum.Theory) * 100;
        generator2 = i => GeometryOverlapFactor.Instance.Accept(i, GeometryOverlapFactor.AlgTypeEnum.Fitting) * 100;
        GeometryOverlapFactor.Instance.Update_Fitting_Arguments(GOF_FIttingData.getXValues(),GOF_FIttingData.getYValues());
        InstanceHolder.Page.LineBlack.Description = new PenDescription("理论几何重叠因子");
        InstanceHolder.Page.LineBlue.Description = new PenDescription("拟合几何重叠因子");
        Refresh();
    }
    /**
     * 将数据源更新为 大气消光系数 相关图像
     */
    public void ChangeDataSource_AEC()
    {
        generator1 = x => AtmosphericExtinctionCoeff.Instance.Accept(x);
        InstanceHolder.Page.LineBlack.Description = new PenDescription("消光系数 含噪");
        generator2 = i => AtmosphericExtinctionCoeff.Instance.Accept(i);
        InstanceHolder.Page.LineBlue.Description = new PenDescription("消光系数 不含噪");
        Refresh();
    }

    public void Refresh()
    {
        InstanceHolder.Page.LineBlack.DataSource = CreateDataSource(generator1);
        InstanceHolder.Page.LineBlue.DataSource = CreateDataSource(generator2);
        InstanceHolder.Page.plotter.FitToView();
    }
    /**
     * 将数据源更新为 回波粒子信号 相关图像
     */
    public void ChangeDataSource_EPG()
    {
        InstanceHolder.Page.HorizontalAxisTitle.Content = "m";
        InstanceHolder.Page.VerticalAxisTitle.Content = "PhE";
        //给曲线图绑定数据源
        generator1 = i => EchoParticleGenerator.Instance.Accept(i);
        generator2 = i =>
        {
            if (EchoParticleGenerator.Instance.Accept(i) == 0)
            {
                return 0;
            }

            var result = EchoParticleGenerator.Instance.Accept(i)
                         + GuassianNoice.Instance.Accept(0, i); //stdDev越大，波动峰值越大，stdDev应该逐渐增大
            if (result < 0) result = 0;
            return result;
        };
        InstanceHolder.Page.LineBlack.Description = new PenDescription("回波粒子信号 不含噪");
        InstanceHolder.Page.LineBlue.Description = new PenDescription("回波粒子信号 含噪");
        
        // 渲染
        InstanceHolder.Page.LineBlack.ZIndex = 1; // 确保不含噪声的信号在上层
        InstanceHolder.Page.LineBlue.ZIndex = 0; // 确保含噪声的信号在下层
        Refresh();
    }

    private IPointDataSource CreateDataSource(Func<double,double> algorithm)
    {
        const int maxLen = 5000;
        Point[] pts = new Point[maxLen];

        Parallel.For(1, maxLen, i =>
        {
            pts[i] = new Point(i, algorithm.Invoke(i));
        });

        var ds = new EnumerableDataSource<Point>(pts);
        ds.SetXYMapping(pt => pt);
        return ds;
    }
}