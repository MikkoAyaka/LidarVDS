using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HandyControl.Controls;
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
            InitializeComponent();
            Growl.Success("启动成功");
            PageFrame.Navigate(new PageMain());
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
    }
}