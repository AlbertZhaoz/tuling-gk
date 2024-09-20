using System.Windows;
using System.Windows.Controls;

namespace WpfTulingGkMes.Ucs;

public partial class DeviceUc : UserControl
{
    public DeviceUc()
    {
        InitializeComponent();
    }
    
    public string DeviceName
    {
        get { return (string)GetValue(DeviceNameProperty)+"设备整机状态"; }
        set { SetValue(DeviceNameProperty, value); }
    }

    // Using a DependencyProperty as the backing store for DeviceName.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty DeviceNameProperty =
        DependencyProperty.Register("DeviceName", typeof(string), typeof(DeviceUc), new PropertyMetadata(""));



    public string IpAddress
    {
        get { return (string)GetValue(IpAddressProperty); }
        set { SetValue(IpAddressProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IpAddress.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IpAddressProperty =
        DependencyProperty.Register("IpAddress", typeof(string), typeof(DeviceUc), new PropertyMetadata(""));



    public string Port
    {
        get { return (string)GetValue(PortProperty); }
        set { SetValue(PortProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Port.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty PortProperty =
        DependencyProperty.Register("Port", typeof(string), typeof(DeviceUc), new PropertyMetadata(""));



    public string ActiveTime
    {
        get { return (string)GetValue(ActiveTimeProperty); }
        set { SetValue(ActiveTimeProperty, value); }
    }

    // Using a DependencyProperty as the backing store for ActiveTime.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ActiveTimeProperty =
        DependencyProperty.Register("ActiveTime", typeof(string), typeof(DeviceUc), new PropertyMetadata(""));


}