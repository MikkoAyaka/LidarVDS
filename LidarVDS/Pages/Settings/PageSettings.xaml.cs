using System.Windows.Controls;
using LidarVDS.Pages.Settings.SettingPages.EnvironmentPage;
using LidarVDS.Pages.Settings.SettingPages.LidarPage;

namespace LidarVDS.Pages.Settings;

public partial class PageSettings : Page
{
    public PageSettings()
    {
        InitializeComponent();
    }

    private void Environment_OnClick(object sender, System.Windows.RoutedEventArgs e)
    {
        SettingFrame.Navigate(EnvironmentService.GetPage());
    } 
    
    private void Lidar_OnClick(object sender, System.Windows.RoutedEventArgs e)
    {
        SettingFrame.Navigate(LidarService.GetPage());
    } 
    
}