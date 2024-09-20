using System.Windows;
using System.Windows.Controls;

namespace WpfTulingGkMes.Ucs;

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