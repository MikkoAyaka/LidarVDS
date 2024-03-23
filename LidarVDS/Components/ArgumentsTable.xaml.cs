using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using LidarVDS.Resources.Values;
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
        LidarArgumentsRepository.GetInstance().GetArguments(LidarArgumentTypeEnum.Environment).ForEach(arg =>
        {
            ArgumentBar bar = new(arg);
            bar.IsEnabled = Editable;
            StackPanelContext.Children.Add(bar);
        });
    }

    private void OpticalArguments(object sender, RoutedEventArgs e)
    {
        StackPanelContext.Children.Clear();
        LidarArgumentsRepository.GetInstance().GetArguments(LidarArgumentTypeEnum.OpticalUnit).ForEach(arg =>
        {
            ArgumentBar bar = new(arg);
            bar.IsEnabled = Editable;
            StackPanelContext.Children.Add(bar);
        });
    }

   
    /**
     * 是否可以编辑，默认否
     */
    public bool Editable { get; set; } = true;
}