using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using LidarVDS.Maths;
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

        ComboBox.Items.Add("斜率法");
        ComboBox.Items.Add("改进的斜率法");
        ComboBox.Items.Add("改进的 Fernald 算法");
        ComboBox.SelectedIndex = 0;
    }

    private void slider_PM25_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
    {
        //var width = slider_PM25
    }

    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        //给曲线图绑定数据源
        line_black.DataSource = CreateDataSource();
        // line_blue.DataSource = CreateSineDataSource(3.0); ;
        // line_red.DataSource = CreateSineDataSource(5.0); ;

        // Force evertyhing plotted to be visible
        plotter.FitToView();
    }
    /**
     * viewDistance 能见度 单位米
     * scatteringCoefficient 大气颗粒散射系数 单位每米，取值范围在 10^5/m ~ 10^6/m
     */
    private IPointDataSource CreateDataSource()
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
}