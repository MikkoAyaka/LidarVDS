using System.Windows;
using System.IO;
using YamlDotNet.Serialization;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace LidarVDS.Pages.Settings.SettingPages.ParameterPage
{
    public partial class Parameter
    {
        private Dictionary<string, string> _yamlData;//定义字典缓存数据
        
        private string _filePath = @"../../Debug/net6.0-windows/Settings.yaml";//获取文件位置
            //"D:\LidarVDS\LidarVDS\LidarVDS\bin\Debug\net6.0-windows\Settings.yaml"
        public Parameter()//初始化页面
        {
            InitializeComponent();
            //LoadSavedData();
            //_yamlData = new Dictionary<string, string>();//声明字典
        }

        private void Save(object sender, RoutedEventArgs e)//保存按钮
        {
            // 获取选择的内容
            string selectedColor = ((ComboBoxItem)Color.SelectedItem).Content.ToString();//主体颜色
            string selectedSize = ((ComboBoxItem)Size.SelectedItem).Content.ToString();//字体大小

            // 整合数据
            var settings = new
            {
                MainColor = selectedColor,
                FontSize = selectedSize,
                // 可根据需要添加更多选项
            };
            // 将数据写入YAML文件
            var serializer = new SerializerBuilder().Build();//新建串行器
            
            string yamlContent = serializer.Serialize(settings);
            
            File.WriteAllText(_filePath, yamlContent, Encoding.UTF8);//写入文件
        }

        //刷新按钮
        private void Refresh(object sender, RoutedEventArgs e)
        {
            // 刷新按钮点击事件，重新加载保存的数据
            LoadSavedData();
        }
        
        //加载内容
        private void LoadSavedData()
        {
            if (File.Exists(_filePath))
            {
                // 读取保存的数据
                string yamlContent = File.ReadAllText(_filePath);

                // 反序列化YAML为对象
                var deserializer = new DeserializerBuilder().Build();
                var settings = deserializer.Deserialize<dynamic>(yamlContent);

                // 设置下拉框的选定值
                SetValue(Color, settings.MainColor);
                SetValue(Size, settings.FontSize);
                // 根据需要设置更多下拉框的选定值
            }
        }

        private void SetValue(ComboBox comboBox, string value)
        {
            // 设置下拉框的选定值
            foreach (ComboBoxItem item in comboBox.Items)
            {
                if (item.Content.ToString() == value)
                {
                    comboBox.SelectedItem = item;
                    break;
                }
            }
        }
    }
}