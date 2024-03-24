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

    /**
     * 将数据源更新为 几何重叠因子 相关图像
     */
    public void ChangeDataSource_GOF()
    {
        InstanceHolder.Page.LineBlack.DataSource = CreateDataSource(i => GeometryOverlapFactor.Instance.Accept(i,GeometryOverlapFactor.AlgTypeEnum.Theory));
        InstanceHolder.Page.LineBlack.Description = new PenDescription("理论几何重叠因子");
        GeometryOverlapFactor.Instance.Update_Fitting_Arguments(GOF_FIttingData.getXValues(),GOF_FIttingData.getYValues());
        InstanceHolder.Page.LineBlue.DataSource = CreateDataSource(i => GeometryOverlapFactor.Instance.Accept(i,GeometryOverlapFactor.AlgTypeEnum.Fitting));
        InstanceHolder.Page.LineBlue.Description = new PenDescription("拟合几何重叠因子");
        InstanceHolder.Page.plotter.FitToView();
    }
    /**
     * 将数据源更新为 大气消光系数 相关图像
     */
    public void ChangeDataSource_AEC()
    {
        
    }
    /**
     * 将数据源更新为 回波粒子信号 相关图像
     */
    public void ChangeDataSource_EPG()
    {
        //给曲线图绑定数据源
        InstanceHolder.Page.LineBlack.DataSource = CreateDataSource(i => EchoParticleGenerator.Instance.Accept(i));
        InstanceHolder.Page.LineBlack.Description = new PenDescription("回波粒子信号 不含噪");
        InstanceHolder.Page.LineBlue.DataSource = CreateDataSource(i =>
        {
            var result = EchoParticleGenerator.Instance.Accept(i)
                   + GuassianNoice.Instance.Accept(0, Math.Sqrt(i) * 0.5)
                   * GuassianNoice.Instance.NormalDistribution(2.7, 0.1, 1);
            if (result < 0) result = 0;
            return result;
        });
        InstanceHolder.Page.LineBlue.Description = new PenDescription("回波粒子信号 含噪");
        // 渲染
        InstanceHolder.Page.LineBlack.ZIndex = 1; // 确保不含噪声的信号在上层
        InstanceHolder.Page.LineBlue.ZIndex = 0; // 确保含噪声的信号在下层
        InstanceHolder.Page.plotter.FitToView();
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