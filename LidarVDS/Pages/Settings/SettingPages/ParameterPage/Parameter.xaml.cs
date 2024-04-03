using System.Diagnostics;
using System.Windows;
using System.IO;
using YamlDotNet.Serialization;
using System.Windows.Controls;
using System.Windows.Media;
using LidarVDS.Utils;
using ComboBox = System.Windows.Controls.ComboBox;

namespace LidarVDS.Pages.Settings.SettingPages.ParameterPage
{
    public partial class Parameter
    {
        public static readonly Parameter Instance = new();
        private ConfigurationSettings _settings;
        private ColorScheme _colorScheme = new();

        public Parameter()
        {
            InitializeComponent();
            InitializeSettings();
        }

        private void InitializeSettings()
        {
            _settings = ConfigurationSettings.Load();
            SetValue(DebugCombo, _settings.DebugMode);
            SetValue(ColorCombo, _settings.MainColor);
            SetValue(NoticeCombo, _settings.Notice);
            UpdateUI();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            _settings.Save();
            AppLogger.Enabled = _settings.parse(_settings.Notice);
            AppLogger.LogInfo("修改成功");
            UpdateUI();
        }

        private void UpdateUI()
        {
            _colorScheme.UpdateColors(_settings.MainColor);
        }

        private void SetValue(ComboBox comboBox, string value)
        {
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

    public class ConfigurationSettings
    {
        public string DebugMode = "关";
        public string MainColor = "蓝色主题";
        public string Notice = "开";

        public static ConfigurationSettings Load()
        {
            if (File.Exists(FileUtil.configFilePath))
            {
                string yamlContent = FileUtil.load(FileUtil.configFilePath);
                var deserializer = new DeserializerBuilder().Build();
                return deserializer.Deserialize<ConfigurationSettings>(yamlContent);
            }

            return new ConfigurationSettings();
        }

        public void Save()
        {
            DebugMode = ((ComboBoxItem)Parameter.Instance.DebugCombo.SelectedItem).Content.ToString();
            MainColor = ((ComboBoxItem)Parameter.Instance.ColorCombo.SelectedItem).Content.ToString();
            Notice = ((ComboBoxItem)Parameter.Instance.NoticeCombo.SelectedItem).Content.ToString();
            
            var serializer = new SerializerBuilder().Build();
            string yamlContent = serializer.Serialize(this);
            FileUtil.save(FileUtil.configFolderPath, FileUtil.configFileName, yamlContent);
        }

        public bool parse(string str)
        {
            if (str.Equals("开")) return true;
            return false;
        }
    }

    public class ColorScheme
    {
        public void UpdateColors(string mainColor)
        {
            switch (mainColor)
            {
                case "蓝色主题":
                    UpdateBackground("#6DA6F6");
                    UpdateHideButton("#fdfbdc");
                    UpdateCloseButton("#f89999");
                    break;
                case "红色主题":
                    UpdateBackground("#FF6B6B");
                    UpdateHideButton("#E74455");
                    UpdateCloseButton("#E74455");
                    break;
                case "绿色主题":
                    UpdateBackground("#5EC603");
                    UpdateHideButton("#9DF252");
                    UpdateCloseButton("#9DF252");
                    break;
            }
        }

        private void UpdateBackground(string colorHex)
        {
            var newBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorHex));
            Application.Current.Resources["Background"] = newBrush;
        }

        private void UpdateHideButton(string colorHex)
        {
            var newBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorHex));
            Application.Current.Resources["HideButton"] = newBrush;
        }

        private void UpdateCloseButton(string colorHex)
        {
            var newBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorHex));
            Application.Current.Resources["CloseButton"] = newBrush;
        }
    }
}
