using System;
using System.Windows;
using System.Windows.Controls;
namespace LidarVDS;

public partial class PageMain : Page
{
    public static PageMain Instance = new();
    internal PageMain()
    {
        Instance = this;
        InitializeComponent();
        var announcementStr = String.Join("\n", PageMainService.Instance.GetAnnouncements());
    }
    private void Image_Click(object sender, RoutedEventArgs e)
    {
        // System.Diagnostics.Process.Start("https://www.bilibili.com/");
    }
    
}
