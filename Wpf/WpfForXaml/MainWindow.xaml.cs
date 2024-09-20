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

namespace WpfForXaml;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        // var scb = new SolidColorBrush();
        // scb.Color = Colors.Aqua;
        //
        // this.rectangle1.Fill = scb;
    }

    private void OnTulingClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Hi,everyone this is tuling course.");
    }
}