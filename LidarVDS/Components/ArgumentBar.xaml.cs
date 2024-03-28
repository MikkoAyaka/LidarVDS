using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using LidarVDS.Resources.Values;

namespace LidarVDS.Components;

public partial class ArgumentBar : UserControl
{
    public LidarArgumentsData ArgumentData;
    public ArgumentBar(LidarArgumentsData argumentData)
    {
        InitializeComponent();
        ArgumentData = argumentData;
        try
        {
            Logo.Source = new BitmapImage(new Uri(argumentData.ImgPath));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        Title.Text = argumentData.Name;
        ArgumentBarSlider.Minimum = argumentData.MinValue;
        ArgumentBarSlider.Value = argumentData.NowValue;
        ArgumentBarSlider.Maximum = argumentData.MaxValue;
        ArgumentBarSlider.TickFrequency = (argumentData.MaxValue - argumentData.MinValue) / 50;
        Units.Text = argumentData.Units;
    }

    private void ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        ArgumentData.NowValue = e.NewValue;
    }
}