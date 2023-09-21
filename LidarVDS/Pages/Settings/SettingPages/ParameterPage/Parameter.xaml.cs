using System.Windows;
using System.IO;
using YamlDotNet.Serialization;
using System.Collections.Generic;

namespace LidarVDS.Pages.Settings.SettingPages.ParameterPage
{
    public partial class Parameter
    {
        private Dictionary<string, string> _yamlData;//定义字典缓存数据
        
        private string _filePath = "D:/LidarVDS/LidarVDS/LidarVDS/Pages/Settings/Data.yaml";//获取文件位置
        
        public Parameter()//初始化页面
        {
            InitializeComponent();
            _yamlData = new Dictionary<string, string>();//声明字典
        }

        private void Save(object sender, RoutedEventArgs e)//保存按钮
        {
            // // 获取文本框中的输入数据
            // string input1 = WindSpeed.Text;
            // string input2 = Humidity.Text;
            // string input3 = Pressure.Text;
            //
            // // 将数据存入字典
            // _yamlData["WindSpeed"] = input1;
            // _yamlData["Humidity"] = input2;
            // _yamlData["Pressure"] = input3;

            // 将数据写入YAML文件
            var serializer = new SerializerBuilder().Build();
            string yamlContent = serializer.Serialize(_yamlData);
            File.WriteAllText(_filePath, yamlContent);
        }

        //刷新按钮
        private void Refresh(object sender, RoutedEventArgs e)
        {
            string yamlContent = File.ReadAllText(_filePath);

            var deserializer = new DeserializerBuilder().Build();
            var yamlObject = deserializer.Deserialize<Dictionary<string, object>>(yamlContent);

            // 获取指定键的值并显示在文本框中
            if (yamlObject.TryGetValue("WindSpeed", out var value1))
            {
                var value = value1.ToString();
                // WindSpeed.Text = value;
            }
            
            if (yamlObject.TryGetValue("Humidity", out var value2))
            {
                var value = value2.ToString();
                // Humidity.Text = value;
            }
            
            if (yamlObject.TryGetValue("Pressure", out var value3))
            {
                var value = value3.ToString();
                // Pressure.Text = value;
            }
                
        }
    }
}