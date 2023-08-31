using System;
using System.Windows;
using System.Windows.Controls;
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
        line_black.DataSource = CreateSineDataSource(1.0);
        line_blue.DataSource = CreateSineDataSource(3.0); ;
        line_red.DataSource = CreateSineDataSource(5.0); ;

        // Force evertyhing plotted to be visible
        plotter.FitToView();
    }

    //模拟数据源
    private IPointDataSource CreateSineDataSource(double phase)
    {
        const int N = 100;
        Point[] pts = new Point[N];
        for (int i = 0; i < N; i++)
        {
            double x = i / (N / 10.0) + phase;
            pts[i] = new Point(x, Math.Sin(x - phase));
        }
        var ds = new EnumerableDataSource<Point>(pts);
        ds.SetXYMapping(pt => pt);
        return ds;
    }


}