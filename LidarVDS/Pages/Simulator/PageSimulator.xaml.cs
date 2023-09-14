using System;
using System.Windows;
using System.Windows.Controls;
using LidarVDS.Utils;
using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace LidarVDS.Pages.Simulator;

public partial class PageSimulator : Page
{
    [Obsolete("请通过相应Service类获取单例实例")]
    public PageSimulator()
    {
        InitializeComponent();

        Loaded += new RoutedEventHandler(MainWindow_Loaded);
    }

    private void slider_PM25_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
    {
        //var width = slider_PM25
    }

    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        //给曲线图绑定数据源
        line_black.DataSource = CreateDataSource(1000,10000);
        // line_blue.DataSource = CreateSineDataSource(3.0); ;
        // line_red.DataSource = CreateSineDataSource(5.0); ;

        // Force evertyhing plotted to be visible
        plotter.FitToView();
    }
    /**
     * viewDistance 能见度 单位米
     * scatteringCoefficient 大气颗粒散射系数 单位每米，取值范围在 10^5/m ~ 10^6/m
     */
    private IPointDataSource CreateDataSource(int viewDistance,double scatteringValue)
    {
        const int maxLen = 1000;
        Point[] pts = new Point[maxLen];
        for (int i = 0; i < maxLen; i++)
        {
            double x = i;
            double y = Computer.MainAlg(i, viewDistance, scatteringValue);
            pts[i] = new Point(x, y);
        }
        var ds = new EnumerableDataSource<Point>(pts);
        ds.SetXYMapping(pt => pt);
        return ds;
    }
    //模拟数据源
    private IPointDataSource CreateSineDataSource(double phase)
    {
        const int N = 100;
        Point[] pts = new Point[N];
        for (int i = 0; i < N; i++)
        {
            double x = i;
            pts[i] = new Point(x, Math.Sin(x));
        }
        var ds = new EnumerableDataSource<Point>(pts);
        ds.SetXYMapping(pt => pt);
        
        return ds;
    }


}