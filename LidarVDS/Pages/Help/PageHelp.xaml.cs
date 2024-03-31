using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
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
        Viewer.Document = new Markdown().Transform(FileUtil.load(FileUtil.documentsPath+"\\斜程能见度.md"));
    }

    private void Btn2_Click(object sender, RoutedEventArgs e)
    {
        Viewer.Document = new Markdown().Transform(FileUtil.load(FileUtil.documentsPath+"\\大气后向散射.md"));
    }
    
    private void Btn3_Click(object sender, RoutedEventArgs e)
    {
        Viewer.Document = new Markdown().Transform(FileUtil.load(FileUtil.documentsPath+"\\微脉冲激光雷达.md"));
    }
    
    private void Btn4_Click(object sender, RoutedEventArgs e)
    {
        Viewer.Document = new Markdown().Transform(FileUtil.load(FileUtil.documentsPath+"\\米散射.md"));
    }
    
    private void Btn5_Click(object sender, RoutedEventArgs e)
    {
        Viewer.Document = new Markdown().Transform(FileUtil.load(FileUtil.documentsPath+"\\瑞利散射.md"));
    }
    
    private void Btn6_Click(object sender, RoutedEventArgs e)
    {
        Viewer.Document = new Markdown().Transform(FileUtil.load(FileUtil.documentsPath+"\\能见度反演算法.md"));
    }
    
    private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        string url = "https://www.yuque.com/mikkoayaka/vp9g2k/ywcg78ccdt0btyk2?singleDoc#";
        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }
    
    private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        string url = "https://www.yuque.com/mikkoayaka/vp9g2k/ywcg78ccdt0btyk2?singleDoc#";
        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }
    
    private void aboutclick(object sender, MouseButtonEventArgs e)
    {
        Window window = new Window();
        window.Width = 400;
        window.Height = 300;
        window.Title = "关于";
        TextBlock textBlock = new TextBlock();
        textBlock.Text = "版本信息：1.0\n指导老师：冯帅\n开发人员：冉琦、田浩、殷嘉辰、谢思远、王霖康、吴骏\n软著信息：";
        textBlock.Margin = new Thickness(10);
        textBlock.FontSize = 16;
        window.Content = textBlock;
        window.ShowDialog();
    }
    
    private void Iaboutclick(object sender, MouseButtonEventArgs e)
    {
        Window window = new Window();
        window.Width = 400;
        window.Height = 300;
        window.Title = "关于";
        TextBlock textBlock = new TextBlock();
        textBlock.Text = "版本信息：1.0\n指导老师：冯帅\n开发人员：冉琦、田浩、殷嘉辰、谢思远、王霖康、吴骏\n软著信息：";
        textBlock.Margin = new Thickness(10);
        textBlock.FontSize = 16;
        window.Content = textBlock;
        window.ShowDialog();
    }
}
