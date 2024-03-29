using System;
using System.Windows.Media;
using System.IO;
using YamlDotNet.Serialization;
using System.Collections.Generic;
using System.Windows;

namespace LidarVDS.Utils
{
    public class AppTheme
    {
        private static string _dataPath = @"../../Debug/net6.0-windows/Settings.yaml";//主题文件位置

        private static string _colorPath = @"../../../Utils/Color.yaml";//详细颜色设计
        
        public static string Theme = "";

        public static string Size = "";

        public static void GetTheme()
        {
            if (File.Exists(_dataPath)&&File.Exists(_colorPath))
            {
                // 读取保存的数据
                string ThemeData = File.ReadAllText(_dataPath);
                string ColorData = File.ReadAllText(_colorPath);

                // 反序列化YAML为对象
                var deserializer1 = new DeserializerBuilder().Build();
                var ThemeSet = deserializer1.Deserialize<dynamic>(ThemeData);

                Theme = ThemeSet["MainColor"];
                //Size = ThemeSet["FontSize"];

                // 反序列化YAML为对象
                var deserializer2 = new DeserializerBuilder().Build();
                var ColorSet = deserializer2.Deserialize<dynamic>(ColorData);

                object c;
                
                if (ColorSet.TryGetValue((object)"Background", out c))
                {
                    var newBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(c.ToString()));
                    Application.Current.Resources["Background"] = newBrush;
                };
                if (ColorSet.TryGetValue("HideButton", out c))
                {
                    var newBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(c.ToString()));
                    Application.Current.Resources["HideButton"] = newBrush;
                };
                if (ColorSet.TryGetValue("CloseButton", out c))
                {
                    var newBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(c.ToString()));
                    Application.Current.Resources["CloseButton"] = newBrush;
                };
            }
        }
    }
}