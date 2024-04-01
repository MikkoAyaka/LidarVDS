using System.IO;
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
        public static MainWindow Instance;
        /**
         * 菜单初始化
         */
        public MainWindow()
        {
            Instance = this;
            TimingUtil.StartTiming("应用启动");
            AppTheme.GetTheme();//初始化主题
            InitializeComponent();
            var ms = TimingUtil.StopTiming("应用启动");
            $"启动成功，耗时 {ms/1000.0} 秒".LogInfo();
            PageFrame.Navigate(PageMain.Instance);
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
            PageFrame.Navigate(PageMain.Instance);
        }

        private void NavButton_Simulator_OnClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(PageSimulator.Instance);
        }

        private void NavButton_Settings_OnClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(PageSettings.Instance);
        }

        private void NavButton_Help_OnClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(PageHelp.Instance);
        }

        private void NavButton_Analysis_OnClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(PageAnalysis.Instance);
        }
    }
}