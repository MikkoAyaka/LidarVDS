using System;
using System.Windows.Controls;
using HandyControl.Controls;

namespace LidarVDS.Components;

public partial class HistoryCard : UserControl
{
    public HistoryCard(string date, string time, string version, int argAmount, int viewDistance, int temperature, int humidity, int airPressure)
    {
        InitializeComponent();
        Date.Text = date;
        Time.Text = time;
        Version.Text = version;
        ArgAmount.Text = argAmount+"个";
        ViewDistance.Text = viewDistance+"m";
        Temperature.Text = temperature+"°C";
        Humidity.Text = humidity+"%";
        AirPressure.Text = airPressure+"hpa";
    }
}