using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LidarVDS.Pages.Analysis;

public partial class HistoryPage : Page
{
    [Obsolete("请通过相应Service类获取单例实例")]
    internal HistoryPage()
    {
        InitializeComponent();
        // Frame.NavigationService.LoadCompleted += NavigationService_LoadCompleted;
    }

   
}
