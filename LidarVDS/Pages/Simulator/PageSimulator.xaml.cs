using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LidarVDS.Pages.Simulator;

public partial class PageSimulator : Page
{ 
    [Obsolete("请通过相应Service类获取单例实例")]
    public PageSimulator()
    {
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
        PageSimulatorService.GetInstance().ChangeDataSource_EPG();
    }

    private void GOF_Selected(object sender, RoutedEventArgs e)
    {
        PageSimulatorService.GetInstance().ChangeDataSource_GOF();
    }

    private void AEC_Selected(object sender, RoutedEventArgs e)
    {
        PageSimulatorService.GetInstance().ChangeDataSource_AEC();
    }
}