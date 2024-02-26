using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using SharpVectors.Dom;

namespace LidarVDS.Pages.Analysis;

public partial class HistoryPage : Page
{
    [Obsolete("请通过相应Service类获取单例实例")]
    internal HistoryPage()
    {
        InitializeComponent();
        // Frame.NavigationService.LoadCompleted += NavigationService_LoadCompleted;
    }

    //定义历史数据对象，创建一个包含实验结果和参数值的类
    public class ExperimentData
    {
        public double ExperimentResult { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public DateTime Timestamp { get; set; }
    }

    //保存历史数据
    Dictionary<DateTime, ExperimentData> historicalDataDictionary = new Dictionary<DateTime, ExperimentData>();
    // 添加历史数据
    DateTime timestamp = DateTime.Now;
    ExperimentData data = new ExperimentData
    {
        ExperimentResult = 42.0,
        Parameters = new Dictionary<string, object>
        {
            { "Parameter1", 10 },
            { "Parameter2", "Value" },
            // 添加其他参数
        },
        Timestamp = DateTime.Now
    };

    // historicalDataDictionary.Add(timestamp, data);

    
    
    
    
    //跳转到统计图界面
    private void PageAnalysis_Onclick(object sender, System.Windows.RoutedEventArgs e)
    {
        NavigationService.Navigate(new PageAnalysis());
    }
   
}
