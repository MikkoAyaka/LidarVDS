using System;
using System.Windows.Controls;

namespace LidarVDS.Pages.Simulator;

public partial class PageSimulator : Page
{
    [Obsolete("请通过相应Service类获取单例实例")]
    public PageSimulator()
    {
        InitializeComponent();
    }
}