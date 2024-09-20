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

namespace WpfBindingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Employee _employee = new Employee(){ Name="Tuling"};
        private int count = 0;


        public MainWindow()
        {
            InitializeComponent();
            InitBinding();
        }

        private void InitBinding()
        {
            // 做数据和界面元素绑定
            var binding = new Binding();
            binding.Source = _employee;
            binding.Path = new PropertyPath("Name");
            binding.Mode = BindingMode.TwoWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus; 

            this.textBoxEmployee.SetBinding(TextBox.TextProperty,binding);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _employee.Name = _employee.Name+"-->"+count;

            this.textBlockEmployee.Text =count+"-"+ _employee.Name;

            count++;
        }
    }
}