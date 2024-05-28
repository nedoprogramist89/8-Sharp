using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SerializeLIB;
using System.IO;


namespace _8_С_
{
    public partial class MainWindow : Window
    {
        private Serializer _serializer = new Serializer();
        private string _dataFilePath = "data.json";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SwitchToLightTheme(object sender, RoutedEventArgs e)
        {
            var lightTheme = new Uri("pack://application:,,,/ThemeLibrary;component/Themes/LightTheme.xaml", UriKind.Absolute);
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = lightTheme });
        }

        private void SwitchToDarkTheme(object sender, RoutedEventArgs e)
        {
            var darkTheme = new Uri("pack://application:,,,/ThemeLibrary;component/Themes/DarkTheme.xaml", UriKind.Absolute);
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = darkTheme });
        }

        private async void SerializeData(object sender, RoutedEventArgs e)
        {
            var data = new { Name = "John Doe", Age = 30 };
            await _serializer.SerializeAsync(data, _dataFilePath);
            MessageBox.Show("Data serialized!");
        }

        private async void DeserializeData(object sender, RoutedEventArgs e)
        {
            if (File.Exists(_dataFilePath))
            {
                var data = await _serializer.DeserializeAsync<dynamic>(_dataFilePath);
                MessageBox.Show($"Data deserialized: Name={data.Name}, Age={data.Age}");
            }
            else
            {
                MessageBox.Show("Data file not found.");
            }
        }
    }
}
