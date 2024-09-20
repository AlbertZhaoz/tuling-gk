using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfBindingDemo
{
    /// <summary>
    /// ValidationAndConverter.xaml 的交互逻辑
    /// </summary>
    public partial class ValidationAndConverter : Window
    {
        private ObservableCollection<TulingModel> tulingModels = new ObservableCollection<TulingModel>(){
            new TulingModel(){CategoryProp = Category.Akun,Name="Akun1"},
            new TulingModel(){CategoryProp = Category.Akun,Name="Akun2"},
            new TulingModel(){CategoryProp = Category.Xc,Name="Xc"},
            new TulingModel(){CategoryProp = Category.Xj,Name="Xj1"},
            new TulingModel(){CategoryProp = Category.Xj,Name="Xj2"},
            };

        public ValidationAndConverter()
        {
            InitializeComponent();
            InitBinding();
        }

        private void InitBinding()
        {
            var binding = new Binding();
            binding.Source = this.sliderOne;
            binding.Path = new PropertyPath("Value");
            binding.ValidationRules.Add(new TulingValidation() { ValidatesOnTargetUpdated = true });

            // 校验通知开关
            binding.NotifyOnValidationError = true;

            this.textBoxOne.SetBinding(TextBox.TextProperty, binding);
            this.textBoxOne.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(ValidationErrorMethod));

            this.listBoxAks.ItemsSource = tulingModels;


            var textBox1Binding = new Binding("Text"){Source=this.textBox1};
            var textBox2Binding = new Binding("Text"){Source=this.textBox2};
            var textBox3Binding = new Binding("Text"){Source=this.textBox3};
            var textBox4Binding = new Binding("Text"){Source=this.textBox4};

            var mb = new MultiBinding(){ Mode = BindingMode.OneWay};
            mb.Bindings.Add(textBox1Binding);
            mb.Bindings.Add(textBox2Binding);
            mb.Bindings.Add(textBox3Binding);
            mb.Bindings.Add(textBox4Binding);
            mb.Converter = new TulingMultiConverter();

            this.loginBtn.SetBinding(Button.IsEnabledProperty,mb);
        }

        private void ValidationErrorMethod(object sender, RoutedEventArgs e)
        {
            var testErrors = Validation.GetErrors(this.textBoxOne);

            if ((testErrors.Count > 0))
            {
                this.textBoxOne.ToolTip = testErrors[0].ErrorContent.ToString();
            }
        }

        private void ChangeAkunMethod(object sender, RoutedEventArgs e)
        {
            tulingModels.Clear();
            tulingModels.Add(new TulingModel() { CategoryProp = Category.Akun, Name = "Akun1" });
            tulingModels.Add(new TulingModel() { CategoryProp = Category.Akun, Name = "Akun2" });
            tulingModels.Add(new TulingModel() { CategoryProp = Category.Akun, Name = "Akun3" });
            tulingModels.Add(new TulingModel() { CategoryProp = Category.Akun, Name = "Akun4" });
            tulingModels.Add(new TulingModel() { CategoryProp = Category.Akun, Name = "Akun5" });


        }
    }

}
