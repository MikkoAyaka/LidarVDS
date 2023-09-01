using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using TextBox = HandyControl.Controls.TextBox;

namespace LidarVDS.Components;

public partial class ArgumentsTable : UserControl
{
    public ArgumentsTable()
    {
        InitializeComponent();
    }

    /**
     * 显示环境参数列表
     */
    private void EnvironmentArguments(object sender, RoutedEventArgs e)
    {
        StackPanelContext.Children.Clear();
        var li = new List<string>(){"PM2.5","PM10","AQI","相对风速","湿度","气压"};
        foreach (var str in li)
        {
            TextBox textBox = new TextBox();
            textBox.Text = str;
            textBox.IsEnabled = false;
            StackPanelContext.Children.Add(textBox);
        }
    }

   
    /**
     * 是否可以编辑，默认否
     */
    public bool Editable { get; set; } = false;
}