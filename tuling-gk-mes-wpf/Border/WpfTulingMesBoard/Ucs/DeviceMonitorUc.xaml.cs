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

namespace WpfTulingMesBoard
{
    /// <summary>
    /// DeviceUc.xaml 的交互逻辑
    /// </summary>
    public partial class DeviceMonitorUc : UserControl
    {
        public DeviceMonitorUc()
        {
            InitializeComponent();
        }


        public string DeviceMonitorName
        {
            get { return (string)GetValue(DeviceMonitorNameProperty); }
            set { SetValue(DeviceMonitorNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeviceName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeviceMonitorNameProperty =
            DependencyProperty.Register("DeviceMonitorName", typeof(string), typeof(DeviceUc), new PropertyMetadata(""));



        public string DeviceUse
        {
            get { return (string)GetValue(DeviceUseProperty); }
            set { SetValue(DeviceUseProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IpAddress.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeviceUseProperty =
            DependencyProperty.Register("DeviceUse", typeof(string), typeof(DeviceUc), new PropertyMetadata(""));


        public string DeviceMonitorActiveTime
        {
            get { return (string)GetValue(DeviceMonitorActiveTimeProperty); }
            set { SetValue(DeviceMonitorActiveTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ActiveTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeviceMonitorActiveTimeProperty =
            DependencyProperty.Register("DeviceMonitorActiveTime", typeof(string), typeof(DeviceUc), new PropertyMetadata(""));


    }
}
