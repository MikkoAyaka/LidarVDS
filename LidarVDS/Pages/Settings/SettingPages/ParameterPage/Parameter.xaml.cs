using System.Windows;
using System.IO;
using YamlDotNet.Serialization;
using System.Text;
using System.Windows.Controls;
using LidarVDS.Utils;

namespace LidarVDS.Pages.Settings.SettingPages.ParameterPage
{
    public partial class Parameter
    {
        private string _filePath = @"../../Debug/net6.0-windows/Settings.yaml";//获取文件位置
        private string _colorPath = @"../../../Utils/Color.yaml";//详细颜色设计
        public Parameter()//初始化页面
        {
            InitializeComponent();
            
            LoadSavedData();//加载选择项
            
            AppTheme.GetTheme();
        }

        private void Save(object sender, RoutedEventArgs e)//保存按钮
        {
            // 获取选择的内容
            string selectedColor = ((ComboBoxItem)Color.SelectedItem).Content.ToString();//主体颜色
            string selectedDebug = ((ComboBoxItem)Debug.SelectedItem).Content.ToString();//字体大小

            // 整合数据
            var settings = new
            {
                MainColor = selectedColor,
                DebugMode = selectedDebug,
                // 可根据需要添加更多选项
            };
            // 将数据写入YAML文件
            var serializer = new SerializerBuilder().Build();//新建串行器
            string yamlContent = serializer.Serialize(settings);
            
            File.WriteAllText(_filePath, yamlContent, Encoding.UTF8);//写入文件
            
            //修改详细颜色配置
            string background = null;
            string hide_button = null;
            string close_button = null;
            
            if (selectedColor == "蓝色主题")
            {
                background = "#6DA6F6";
                hide_button = "#6DA6F0";
                close_button = "#6DA6F0";
            }
            else if (selectedColor == "红色主题")
            {
                background = "#FF6B6B";
                hide_button = "#E74455";
                close_button = "#E74455";
            }
            else if (selectedColor == "绿色主题")
            {
                background = "#5EC603";
                hide_button = "#9DF252";
                close_button = "#9DF252";
            }
            
            var color = new
            {
                Background = background,
                HideButton = hide_button,
                CloseButton = close_button,
            };
            // 将数据写入YAML文件
            var serializer2 = new SerializerBuilder().Build();//新建串行器
            string c = serializer2.Serialize(color);
            
            File.WriteAllText(_colorPath, c, Encoding.UTF8);//写入文件
            $"修改成功".LogInfo();
            
            LoadSavedData();

            AppTheme.GetTheme();
            AppTheme.GetMode();
        }

        //刷新按钮
        /*private void Refresh(object sender, RoutedEventArgs e)
        {
            // 刷新按钮点击事件，重新加载保存的数据
            LoadSavedData();

            AppTheme.GetTheme();
            AppTheme.GetMode();
        }*/
        
        //加载选项框中的选项
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
                SetValue(Debug, settings["DebugMode"]);
                SetValue(Color, settings["MainColor"]);
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