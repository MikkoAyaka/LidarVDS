using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HandyControl.Controls;
using LidarVDS.Pages.Analysis;
using LidarVDS.Pages.Help;
using LidarVDS.Pages.Settings;
using LidarVDS.Pages.Simulator;
using LidarVDS.Utils;
using Window = HandyControl.Controls.Window;

namespace LidarVDS
{
    public partial class MainWindow : Window
    {
        /**
         * 菜单初始化
         */
        public MainWindow()
        {
            TimingUtil.StartTiming("应用启动");
            InitializeComponent();
            var ms = TimingUtil.StopTiming("应用启动");
            $"启动成功，耗时 {ms/1000.0} 秒".LogInfo();
            PageFrame.Navigate(PageMainService.GetPage());
        }

        /**
         * 拖拽窗口
         */
        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        /**
         * 最小化窗口
         */
        private void HideWindow(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            WindowState = WindowState.Minimized;
        }

        /**
         * 关闭窗口
         */
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            Close();
        }

        private void NavButton_MainPage_OnClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(PageMainService.GetPage());
        }

        private void NavButton_Simulator_OnClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(PageSimulatorService.GetPage());
        }

        private void NavButton_Settings_OnClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(PageSettingsService.GetPage());
        }

        private void NavButton_Help_OnClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(PageHelpService.GetPage());
        }

        private void NavButton_Analysis_OnClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(PageAnalysisService.GetPage());
        }
    }
}