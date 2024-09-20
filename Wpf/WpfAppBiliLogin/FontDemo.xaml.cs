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
    /// FontDemo.xaml 的交互逻辑
    /// </summary>
    public partial class FontDemo : Window
    {
        public FontDemo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.textzh.FontFamily = (FontFamily)this.FindResource("zhjq");
        }
    }
}
