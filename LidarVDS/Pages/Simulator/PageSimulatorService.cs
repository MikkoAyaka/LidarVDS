using System.Diagnostics;
using System.Windows;
using LidarVDS.Maths;
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
        InstanceHolder.Page.LineBlack.DataSource = CreateDataSource_EPG_WithoutNoice();
        InstanceHolder.Page.LineBlack.Description = new PenDescription("回波粒子信号 不含噪");
        InstanceHolder.Page.LineBlue.DataSource = CreateDataSource_EPG_WithNoice();
        InstanceHolder.Page.LineBlue.Description = new PenDescription("回波粒子信号 含噪");
        // 渲染
        InstanceHolder.Page.plotter.FitToView();
    }
    /**
     * 不含噪的回波粒子信号图像产生函数
     */
    private IPointDataSource CreateDataSource_EPG_WithoutNoice()
    {
        const int maxLen = 5000;
        Point[] pts = new Point[maxLen];
        for (int i = 1; i < maxLen; i++)
        {
            pts[i] = new Point(i, EchoParticleGenerator.Instance.Accept(i));
        }
        var ds = new EnumerableDataSource<Point>(pts);
        ds.SetXYMapping(pt => pt);
        return ds;
    }
    /**
     * 含噪的回波粒子信号图像产生函数
     */
    private IPointDataSource CreateDataSource_EPG_WithNoice()
    {
        const int maxLen = 5000;
        Point[] pts = new Point[maxLen];
        for (int i = 1; i < maxLen; i++)
        {
            // TODO 这里应该改为这样：
            // pts[i] = new Point(i, EchoParticleGenerator.Instance.Accept(i) + GuassianNoice.Instance.Accept(i));
            pts[i] = new Point(i,0);
        }
        var ds = new EnumerableDataSource<Point>(pts);
        ds.SetXYMapping(pt => pt);
        return ds;
    }
}