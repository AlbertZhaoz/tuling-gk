using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfRouteEvent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 控件自带的路由事件
            this.gridRoot.AddHandler(Button.ClickEvent,new RoutedEventHandler(ButtonClickHandle));
            this.gridA.AddHandler(Button.ClickEvent,new RoutedEventHandler(ButtonClickHandle));
            this.canvasB.AddHandler(TimeButton.MyEventEvent,new EventHandler<ReportTimeEventArgs>(MyEventHanlde)); 
        }

        private void MyEventHanlde(object? sender, ReportTimeEventArgs e)
        {
            var element = sender as FrameworkElement;

            string timeStr = e.ClickTime.ToString();
            MessageBox.Show($"{element.Name}--{timeStr}");
        }

        private void ButtonClickHandle(object sender, RoutedEventArgs e)
        {
            var element = sender as FrameworkElement;

            var btnName = (e.OriginalSource as FrameworkElement).Name;
            MessageBox.Show(btnName);

            if(element != null&&element == this.gridA) { 
                e.Handled = true;
            }
        }
    }
}