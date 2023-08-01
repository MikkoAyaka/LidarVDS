using System;
using System.Windows.Controls;
using LidarVDS.Utils;

namespace LidarVDS;

public partial class PageMain : Page
{
    [Obsolete("请通过相应Service类获取单例实例")]
    public PageMain()
    {
        InitializeComponent();
    }
    
}
