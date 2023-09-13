using System;
using System.Windows;
using System.Windows.Controls;

namespace LidarVDS.Pages.Help;

public partial class PageHelp : Page
{
    [Obsolete("请通过相应Service类获取单例实例")]
    internal PageHelp()
    {
        InitializeComponent();
    }
}