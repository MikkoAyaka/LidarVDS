using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using LidarVDS.Utils;
using MdXaml;

namespace LidarVDS.Pages.Help;

public partial class PageHelp : Page
{
    [Obsolete("请通过相应Service类获取单例实例")]
    internal PageHelp()
    {
        InitializeComponent();
    }

    private void Btn1_Click(object sender, RoutedEventArgs e)
    {
        Viewer.Document = new Markdown().Transform(File.ReadAllText(FileUtil.documentsPath+"\\斜程能见度.md"));
    }

    private void Btn2_Click(object sender, RoutedEventArgs e)
    {
        Viewer.Document = new Markdown().Transform(File.ReadAllText(FileUtil.documentsPath+"\\大气后向散射.md"));
    }
    
    private void Btn3_Click(object sender, RoutedEventArgs e)
    {
        Viewer.Document = new Markdown().Transform(File.ReadAllText(FileUtil.documentsPath+"\\微脉冲激光雷达.md"));
    }
    
    private void Btn4_Click(object sender, RoutedEventArgs e)
    {
        Viewer.Document = new Markdown().Transform(File.ReadAllText(FileUtil.documentsPath+"\\米散射.md"));
    }
    
    private void Btn5_Click(object sender, RoutedEventArgs e)
    {
        Viewer.Document = new Markdown().Transform(File.ReadAllText(FileUtil.documentsPath+"\\瑞利散射.md"));
    }
    
    private void Btn6_Click(object sender, RoutedEventArgs e)
    {
        Viewer.Document = new Markdown().Transform(File.ReadAllText(FileUtil.documentsPath+"\\能见度反演算法.md"));
    }
}