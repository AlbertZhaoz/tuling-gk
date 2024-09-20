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
using WpfTemplateStyleTrigger.Models;

namespace WpfTemplateStyleTrigger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Car> carList = new List<Car>(){ 
            new Car(){Automaker="fate",Name="ak",Year="2024",TopSpeed="300"},
            new Car(){Automaker="fate",Name="xc",Year="2025",TopSpeed="301"},
            new Car(){Automaker="fate",Name="ak",Year="2026",TopSpeed="302"},
            new Car(){Automaker="fate",Name="xj",Year="2027",TopSpeed="303"},
            new Car(){Automaker="fate",Name="xj",Year="2028",TopSpeed="304"},
            };

        public MainWindow()
        {
            InitializeComponent();
            InitBinding();
        }

        private void InitBinding()
        {
            this.listBoxCars.ItemsSource = carList;
        }
    }
}