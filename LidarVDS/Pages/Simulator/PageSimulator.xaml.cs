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
        // ComboBox.Items.Add("斜率法");
        // ComboBox.Items.Add("改进的斜率法");
        // ComboBox.Items.Add("改进的 Fernald 算法");
        // ComboBox.SelectedIndex = 0;
    }

    private async void LateInit()
    {
        while (!IsLoaded)
        {
            await Task.Delay(1);
        }
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