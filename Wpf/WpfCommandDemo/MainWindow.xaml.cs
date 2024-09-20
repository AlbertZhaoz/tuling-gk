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

namespace WpfCommandDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitCommand();
        }

        // 常用的一些命令微软已经帮我们封装好了
        // ApplicationCommands

        // 1.声明并定义命令
        private RoutedCommand clearCmd = new RoutedCommand("Clear",typeof(MainWindow));

        private void InitCommand()
        {
            //2. 为命令添加一些快捷键
            this.clearCmd.InputGestures.Add(new KeyGesture(Key.C,ModifierKeys.Alt));

            //3. 为命令指定源和目标
            this.btnClear.Command = clearCmd;
            this.btnClear.CommandTarget = this.textBoxContent;

            //4. 创建命令关联
            var cb = new CommandBinding();
            cb.Command = this.clearCmd;
            cb.CanExecute += Cb_CanExecute;
            cb.Executed += Cb_Executed;

            //5. 设置命令的位置
            this.stackPanelContain.CommandBindings.Add(cb);  
        }

        private void Cb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.textBoxContent.Clear();
            e.Handled = true;
        }

        private void Cb_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(textBoxContent.Text)) { 
                e.CanExecute = false;    
            }
            else
            {
                e.CanExecute = true;
            }

            e.Handled = true;
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(textBoxContent.Text)) { 
                e.CanExecute = false;    
            }
            else
            {
                e.CanExecute = true;
            }

            e.Handled = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter.ToString() == "Tuling")
            {
                this.textBoxContent.Text += "Tuling\n";
            }
            else
            {
                this.textBoxContent.Text += "Bili\n";
            }

            e.Handled = true;
        }
    }
}