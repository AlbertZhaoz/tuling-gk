using System.Collections.ObjectModel;
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
using LiveCharts;
using WpfTulingGkMes.Models;
using WpfTulingGkMes.Ucs;
using WpfTulingGkMes.Views;
using TabItem = HandyControl.Controls.TabItem;

namespace WpfTulingGkMes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Func<ChartPoint, string> PointLabel { get; set; }

        public MainWindow()
        {
            var loginView = new UserLoginView();

            if (!loginView.ShowDialog() ?? true)
            {
                return;
            }

            InitializeComponent();
            InitLiveChart2();
        }

        private void InitLiveChart2()
        {
            this.DataContext = this;
            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})",
                    chartPoint.Y, chartPoint.Participation);
        }

        private void CanFdScreen(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        /// <summary>
        /// 设备台账
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            // 遍历 ContentTabControl 检查是否已经存在同名的 TabItem
            foreach (TabItem item in this.ContentTabControl.Items)
            {
                // 如果 TabItem 的 Header 是 "设备台账"，则设置为选中状态并返回
                if (item.Header is StackPanel panel && panel.Children[0] is TextBlock textBlock && textBlock.Text == "设备台账")
                {
                    this.ContentTabControl.SelectedItem = item;
                    return; // 已存在标签页，直接返回
                }
            }
            
            var testTabItem = new TabItem();

            // 创建右键菜单
            var closeMenuItem = new MenuItem
            {
                Header = "关闭",
                Width = 100,
            };
            closeMenuItem.Click += (s, args) =>
            {
                // 从 TabControl 中移除当前的 TabItem
                this.ContentTabControl.Items.Remove(testTabItem);
            };

            var contextMenu = new ContextMenu();
            contextMenu.Items.Add(closeMenuItem);

            // 设置 TabItem 的右键菜单
            testTabItem.ContextMenu = contextMenu;

            // 创建 TabItem 的 Header
            var headerPanel = new StackPanel { Orientation = Orientation.Horizontal };
            headerPanel.Children.Add(new TextBlock { Text = "设备台账" });

            testTabItem.Header = headerPanel;
            testTabItem.Content = new DeviceCollection();

            this.ContentTabControl.Items.Add(testTabItem);
            this.ContentTabControl.SelectedItem = testTabItem;
        }
    }
}