using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HandyControl.Controls;

namespace LidarVDS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : GlowWindow
    {
        private static MainWindow INSTANCE;
        public MainWindow()
        {
            INSTANCE = this;
            InitializeComponent();
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void HideWindow(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            WindowState = WindowState.Minimized;
        }
        private void CloseWindow(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            Close();
        }
    }
}