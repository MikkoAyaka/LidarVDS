using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace LidarVDS.Pages.Analysis;

public partial class PageAnalysis : Page
{
    [Obsolete("请通过相应Service类获取单例实例")]
    internal PageAnalysis()
    {
        InitializeComponent();
        // Frame.NavigationService.LoadCompleted += NavigationService_LoadCompleted;
    }

    

    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        //给曲线图绑定数据源
        line_black.DataSource = CreateDataSource(7000,0.0005);
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
        const int maxLen = 5000;
        Point[] pts = new Point[maxLen];
        // Dictionary<Double,Double> dataMap = Computer.MainAlg( viewDistance, scatteringValue,maxLen);
        // for (int i = 1; i < maxLen; i++)
        // {
        //     pts[i] = new Point(i, dataMap[i]);
        // }
        var ds = new EnumerableDataSource<Point>(pts);
        ds.SetXYMapping(pt => pt);
        return ds;
    }

    
    private void HistoryPage_Onclick(object sender, System.Windows.RoutedEventArgs e)
    {
        NavigationService.Navigate(new HistoryPage());
    }
}