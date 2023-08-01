using System.Windows.Controls;
using System.Windows;
using System.IO;
using YamlDotNet.Serialization;
using System.Collections.Generic;

namespace LidarVDS.Pages.Settings.SettingPages.ConstantPage
{
    /// <summary>
    /// Constant.xaml 的交互逻辑
    /// </summary>

    public partial class Constant : Page
    {
        private Dictionary<string, string> yamlData;//定义字典缓存数据
        private string filePath = "D:\\LidarVDS\\Main\\LidarVDS\\LidarVDS\\bin\\Debug\\net6.0-windows\\Data.yaml";//获取文件位置

        public Constant()
        {
            InitializeComponent();
            yamlData = new Dictionary<string, string>();//声明字典
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            // 获取文本框中的输入数据
            string input1 = Atmospheric_Transmissivity_Data.Text;
            string input2 = Background_Noise_Data.Text;

            // 将数据存入字典
            yamlData["ATD"] = input1;
            yamlData["BND"] = input2;

            // 将数据写入YAML文件
            var serializer = new SerializerBuilder().Build();
            string yamlContent = serializer.Serialize(yamlData);
            File.WriteAllText(filePath, yamlContent);
        }

        //读取.yaml文件的内容
        public string ReadYamlFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        

        //刷新按钮
        private void Atmospheric_Transmissivity_Refresh(object sender, RoutedEventArgs e)
        {
            string filePath = "D:\\LidarVDS\\Main\\LidarVDS\\LidarVDS\\bin\\Debug\\net6.0-windows\\Data.yaml";
            string yamlContent = File.ReadAllText(filePath);

            var deserializer = new DeserializerBuilder().Build();
            var yamlObject = deserializer.Deserialize<Dictionary<string, object>>(yamlContent);

            // 获取指定键的值并显示在文本框中
            if (yamlObject.ContainsKey("ATD"))
            {
                var value = yamlObject["ATD"].ToString();
                Atmospheric_Transmissivity_Data.Text = value;
            }
        }

        //刷新按钮
        private void Background_Noise_Refresh(object sender, RoutedEventArgs e)
        {
            string filePath = "D:\\LidarVDS\\Main\\LidarVDS\\LidarVDS\\bin\\Debug\\net6.0-windows\\Data.yaml";
            string yamlContent = File.ReadAllText(filePath);

            var deserializer = new DeserializerBuilder().Build();
            var yamlObject = deserializer.Deserialize<Dictionary<string, object>>(yamlContent);

            // 获取指定键的值并显示在文本框中
            if (yamlObject.ContainsKey("BND"))
            {
                var value = yamlObject["BND"].ToString();
                Background_Noise_Data.Text = value;
            }
        }
    }
}