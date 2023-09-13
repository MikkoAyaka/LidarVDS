// using System;
// using System.Windows.Controls;
//
// namespace LidarVDS.Pages.Analysis;
//
// public partial class PageAnalysis : Page
// {
//     [Obsolete("请通过相应Service类获取单例实例")]
//     public PageAnalysis()
//     {
//         InitializeComponent();
//     }
// }


using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LidarVDS.Pages.Analysis;

public partial class PageAnalysis : Page
{
    [Obsolete("请通过相应Service类获取单例实例")]
    internal PageAnalysis()
    {
        InitializeComponent();
        // Frame.NavigationService.LoadCompleted += NavigationService_LoadCompleted;
    }

    private void ShowStatisticsPage(List<double> data)
    {
        // 创建统计图子页面的实例
        // statisticsPage statisticsPage = new StatisticsPage(data);

        // 导航到统计图子页面
        // Frame.Navigate(statisticsPage);
    }

    private void ShowHistoryPage(List<List<double>> historicalData)
    {
        // 创建历史记录子页面的实例
        // HistoryPage historyPage = new HistoryPage(historicalData);

        // 导航到历史记录子页面
        // Frame.Navigate(historyPage);
    }

    private void Button_Click1(object sender, RoutedEventArgs e)
    {
        // 模拟历史数据
        List<double> historicalData1 = new List<double> { 10, 20, 30, 40, 50 };
        List<double> historicalData2 = new List<double> { 5, 15, 25, 35, 45 };

        /*// 点击按钮后导航到统计图子页面，并传递相应的历史数据
        if (sender == Button1)
        {
            ShowStatisticsPage(historicalData1);
        }
        else if (sender == Button2)
        {
            ShowStatisticsPage(historicalData2);
        }*/
    }

    private void Button_Click2(object sender, RoutedEventArgs e)
    {
        // 模拟历史数据
        List<List<double>> historicalData = new List<List<double>>();
        historicalData.Add(new List<double> { 10, 20, 30, 40, 50 });
        historicalData.Add(new List<double> { 5, 15, 25, 35, 45 });

        // 点击按钮后导航到历史记录子页面，并传递历史数据
        ShowHistoryPage(historicalData);
    }

    private void HistoryPage_Onclick(object sender, System.Windows.RoutedEventArgs e)
    {
        HistoryFrame.Navigate(HistoryPageService.GetPage());
    }
}