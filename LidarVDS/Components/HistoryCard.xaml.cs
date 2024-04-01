using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using HandyControl.Controls;
using LidarVDS.Pages.Analysis;
using LidarVDS.Pages.Simulator;
using LidarVDS.Resources.Values;
using LidarVDS.Utils;

namespace LidarVDS.Components;

public partial class HistoryCard : UserControl
{
    private string fileName;
    private string path;
    public HistoryCard(string date, string time, string version, int argAmount, int viewDistance, int temperature, int humidity, int airPressure)
    {
        InitializeComponent();
        Date.Text = date;
        Time.Text = time;
        fileName = date + "_" + time + ".yml";
        path = FileUtil.historyPath + "\\" + fileName;
        Version.Text = version;
        ArgAmount.Text = argAmount+"个";
        ViewDistance.Text = viewDistance+"m";
        Temperature.Text = temperature+"°C";
        Humidity.Text = humidity+"%";
        AirPressure.Text = airPressure+"hpa";
    }

    private void Select(object sender, RoutedEventArgs e)
    {
        var text = FileUtil.load(path);
        LidarArgumentsRepository.GetInstance().Deserialize(text);
        MainWindow.Instance.SimulatorBtn.IsChecked = true;
        MainWindow.Instance.PageFrame.Navigate(PageSimulator.Instance);
        PageSimulator.Instance.ArgTable.Refresh();
    }

    private void Delete(object sender, RoutedEventArgs e)
    {
        if(File.Exists(path)) File.Delete(path);
        PageAnalysis.Instance.MainWindow_Loaded(sender,e);
    }
}