using System;
using System.Windows.Media;
using System.IO;
using YamlDotNet.Serialization;
using System.Collections.Generic;

namespace LidarVDS.Utils
{
    public class AppTheme
    {
        private static string _dataPath = @"..\..\Debug\net6.0-windows\Settings.yaml";//主题文件位置

        private static string _colorPath = @"../../..\Utils\Color.yaml";//详细颜色设计
        
        public static string Theme = "";

        public static string Size = "";
        public static SolidColorBrush Background { get; set;} = new SolidColorBrush();
        public static SolidColorBrush Color1 { get; set;} = new SolidColorBrush();
        public static SolidColorBrush Color2 { get; set;} = new SolidColorBrush();
        public static SolidColorBrush Color3 { get; set;} = new SolidColorBrush();
        
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
                Size = ThemeSet["FontSize"];

                // 反序列化YAML为对象
                var deserializer2 = new DeserializerBuilder().Build();
                var ColorSet = deserializer2.Deserialize<dynamic>(ColorData);

                object c;
                
                if (ColorSet.TryGetValue((object)"Background", out c))
                {
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(c.ToString()));
                };
                if (ColorSet.TryGetValue("Color1", out c))
                {
                    Color1 = new SolidColorBrush((Color)ColorConverter.ConvertFromString(c.ToString()));
                };
                if (ColorSet.TryGetValue("Color2", out c))
                {
                    Color2 = new SolidColorBrush((Color)ColorConverter.ConvertFromString(c.ToString()));
                };
                if (ColorSet.TryGetValue("Color3", out c))
                {
                    Color3 = new SolidColorBrush((Color)ColorConverter.ConvertFromString(c.ToString()));
                };
            }
        }
        /*public static void Change()
        {
            if (Theme == "蓝色")
            {
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6DA6F6"));
                Color1 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6DA6F5"));
                Color2 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6DA6F4"));
                Color3 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6DA6F3"));
            }
            else if (Theme == "红色")
            {
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0000"));
                Color1 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0001"));
                Color2 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0002"));
                Color3 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0003"));
            }
            else if (Theme == "绿色")
            {
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EE0000"));
                Color1 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0001"));
                Color2 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0002"));
                Color3 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0003"));
            }
        }

        public static void Save()
        {
            
        }*/
    }
}