using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using LidarVDS.Components;
using LidarVDS.Maths;
using LidarVDS.Resources.Values;
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
        Loaded += MainWindow_Loaded;
    }

    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        Container.Children.Clear();
        foreach (var filePath in Directory.GetFiles(FileUtil.historyPath))
        {
            var text = FileUtil.load(filePath);
            var dynmap = LidarArgumentsRepository.DeserializeAsMap(text);
            var date = (string)dynmap["Date"];
            var time = (string)dynmap["Time"];
            var version = (string)dynmap["Version"];
            var argAmount = int.Parse((string)dynmap["ArgAmount"]);
            var viewDistance = int.Parse((string)dynmap["ViewDistance"]);
            var temperature = int.Parse((string)dynmap["Temperature"]);
            var humidity = int.Parse((string)dynmap["Humidity"]);
            var airPressure = (int)(double.Parse((string)dynmap["AtmospheicPressure"]) * 1013.25);
            var card = new HistoryCard(date, time, version, argAmount, viewDistance, temperature, humidity,
                airPressure);
            card.Margin = new Thickness(10,10,10,10);
            Container.Children.Add(card);
        }
    }
}