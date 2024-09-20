using Microsoft.Extensions.DependencyInjection;
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

namespace WpfToolKitDemo.Views
{
    /// <summary>
    /// MessengersDemoView.xaml 的交互逻辑
    /// </summary>
    public partial class MessengersDemoView : Window
    {
        public MessengersDemoView()
        {
            InitializeComponent();

            InitService();
        }

        private void InitService()
        {
            IFileService filesService = App.Current.Services.GetService<IFileService>();
            filesService.Save();
        }
    }
}
