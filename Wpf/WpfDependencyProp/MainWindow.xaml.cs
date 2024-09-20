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

namespace WpfDependencyProp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var student = new Student();
            student.Age = 18;

            var binding = new Binding();
            binding.Source = student;
            binding.Path = new PropertyPath("Age");

            // this.btnDp.SetBinding(Button.ContentProperty, binding);

            

        }
    }
}