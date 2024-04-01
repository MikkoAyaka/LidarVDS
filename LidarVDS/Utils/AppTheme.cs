using System;
using System.Windows.Media;
using System.IO;
using YamlDotNet.Serialization;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace LidarVDS.Utils
{
    public class AppTheme
    {
        
        public static string Theme;

        public static string Size;

        public static bool Mode;

        public static void GetTheme()
        {
            if (File.Exists(FileUtil.configFilePath)&&File.Exists(FileUtil.colorFilePath))
            {
                // 读取保存的数据
                string ThemeData = File.ReadAllText(FileUtil.configFilePath);
                string ColorData = File.ReadAllText(FileUtil.colorFilePath);

                // 反序列化YAML为对象
                var deserializer1 = new DeserializerBuilder().Build();
                var ThemeSet = deserializer1.Deserialize<dynamic>(ThemeData);

                Theme = ThemeSet["MainColor"];

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

        public static void GetMode()
        {
            if (File.Exists(FileUtil.configFilePath))
            {
                // 读取保存的数据
                string ThemeData = FileUtil.load(FileUtil.configFilePath);

                // 反序列化YAML为对象
                var deserializer1 = new DeserializerBuilder().Build();
                var ModeSet = deserializer1.Deserialize<dynamic>(ThemeData);

                string mode = ModeSet["DebugMode"];
                if (mode == "开")
                {
                    
                    AppLogger.DebugMode = true;
                }
                else
                {
                    AppLogger.DebugMode = false;
                }
            }
        }
    }
}