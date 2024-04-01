using System.Windows.Controls;
using LidarVDS.Pages.Settings.SettingPages.ParameterPage;

namespace LidarVDS.Pages.Settings;

public partial class PageSettings : Page
{
    public static PageSettings Instance = new();
    private PageSettings()
    {
        Instance = this;
        InitializeComponent();
        SettingFrame.Navigate(Parameter.Instance);
    }

    private void Environment_OnClick(object sender, System.Windows.RoutedEventArgs e)
    {
        SettingFrame.Navigate(Parameter.Instance);
    }

}