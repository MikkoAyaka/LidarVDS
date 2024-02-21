using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LidarVDS.Utils;
namespace LidarVDS;

public partial class PageMain : Page
{
    [Obsolete("请通过相应Service类获取单例实例")]
    internal PageMain()
    {
        InitializeComponent();
        var announcementStr = String.Join("\n", PageMainService.GetInstance().GetAnnouncements());
    }
    private void Image_Click(object sender, RoutedEventArgs e)
    {
        System.Diagnostics.Process.Start("https://www.bilibili.com/");
    }
    
}
