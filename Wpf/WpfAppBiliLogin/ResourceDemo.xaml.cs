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
using System.Windows.Shapes;

namespace WpfAppBiliLogin
{
    /// <summary>
    /// ResourceDemo.xaml 的交互逻辑
    /// </summary>
    public partial class ResourceDemo : Window
    {
        public ResourceDemo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 后台获取资源两种写法
            // 1. 第一种获取资源
            this.Resources["SolidColorOne"] = new SolidColorBrush(Color.FromRgb(233,4,34));
            this.Resources["SolidThree"] = new SolidColorBrush(Color.FromRgb(23,4,34));

            // 2. 第二种获取资源的写法
            // var solidColor = App.Current.FindResource("SolidThree");
        }
    }
}
