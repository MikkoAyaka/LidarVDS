using System.Windows.Controls;
// using LidarVDS.Pages.Settings.SettingPages.ConstantPage;
// using LidarVDS.Pages.Settings.SettingPages.VariablePage;
// using LidarVDS.Pages.Settings.SettingPages.Sys_Page;
// using LidarVDS.Pages.Settings.SettingPages.OtherPage;

namespace LidarVDS.Pages.Settings;

public partial class PageSettings : Page
{
    public PageSettings()
    {
        InitializeComponent();
    }

    private void Constant_OnClick(object sender, System.Windows.RoutedEventArgs e)
    {
        // SettingFrame.Navigate(ConstantService.GetPage());
    } private void Variable_OnClick(object sender, System.Windows.RoutedEventArgs e)
    {
        // SettingFrame.Navigate(VariableService.GetPage());
    }
    private void System_OnClick(object sender, System.Windows.RoutedEventArgs e)
    {
        // SettingFrame.Navigate(Sys_Service.GetPage());
    }
    private void Others_OnClick(object sender, System.Windows.RoutedEventArgs e)
    {
        // SettingFrame.Navigate(OtherService.GetPage());
    }
}