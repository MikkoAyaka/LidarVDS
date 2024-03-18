using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using LidarVDS.Maths;
using LidarVDS.Utils;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using Point = System.Windows.Point;

namespace LidarVDS.Pages.Analysis;

public partial class PageAnalysis : Page
{
    [Obsolete("请通过相应Service类获取单例实例")]
    internal PageAnalysis()
    { 
        InitializeComponent();
        Loaded += new RoutedEventHandler(MainWindow_Loaded);
    }

    

    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        line_black.DataSource = CreateDataSource();
        plotter.FitToView();
    }
    
    /**
     * viewDistance 能见度 单位米
     * scatteringCoefficient 大气颗粒散射系数 单位每米，取值范围在 10^5/m ~ 10^6/m
     */
    private IPointDataSource CreateDataSource()
    {
        const int maxLen = 5000;
        var dataPoints = new List<Point>();
        for (var x = 1; x <= maxLen; x++)
        {
            var y = EchoParticleGenerator.Instance.Accept(x);
            dataPoints.Add(new Point(x,y));
        }

        var dataSource = new EnumerableDataSource<Point>(dataPoints);
        dataSource.SetXYMapping(pt => pt);
        return dataSource;
    }
    

    
    private void HistoryPage_Onclick(object sender, System.Windows.RoutedEventArgs e)
    {
        NavigationService.Navigate(new HistoryPage());
    }
}