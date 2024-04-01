using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LidarVDS.Resources.Values;
using LidarVDS.Utils;

namespace LidarVDS.Pages.Simulator;

public partial class PageSimulator : Page
{
    public static PageSimulator Instance = new();
    private PageSimulator()
    {
        Instance = this;
        InitializeComponent();
        LateInit();
    }

    private async void LateInit()
    {
        while (!IsLoaded) await Task.Delay(100);
        ViewBtn1.IsChecked = true;
    }

    private void EPG_Selected(object sender, RoutedEventArgs e)
    {
        PageSimulatorService.Instance.ChangeDataSource_EPG();
    }

    private void GOF_Selected(object sender, RoutedEventArgs e)
    {
        PageSimulatorService.Instance.ChangeDataSource_GOF();
    }

    private void AEC_Selected(object sender, RoutedEventArgs e)
    {
        PageSimulatorService.Instance.ChangeDataSource_AEC();
    }

    private void Refresh(object sender, RoutedEventArgs e)
    {
        PageSimulatorService.Instance.Refresh();
    }

    private void Save(object sender, RoutedEventArgs e)
    {
        var date = DateTime.Now.ToString("yyyy-MM-dd");
        var time = DateTime.Now.ToString("HH-mm-ss");
        var text = LidarArgumentsRepository.GetInstance().Serialize();
        text += "Date: "+date+"\n";
        text += "Time: "+time+"\n";
        text += "ArgAmount: "+LidarArgumentsRepository.GetInstance().GetArguments().Count+"\n";
        text += "Version: 1.0.0\n";
        FileUtil.save(FileUtil.historyPath,date+"_"+time+".yml",text);
        AppLogger.LogSuccess(date+" 数据保存成功。");
    }
}