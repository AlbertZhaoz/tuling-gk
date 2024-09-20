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
using System.Windows.Shapes;

namespace WpfBindingDemo
{
    /// <summary>
    /// Binding03.xaml 的交互逻辑
    /// </summary>
    public partial class Binding03 : Window
    {
        public Binding03()
        {
            InitializeComponent();
            InitBinding();
        }

        private void InitBinding()
        {
            var employeeList = new List<Employee>();
            employeeList.Add(new Employee() { Id = 0, Name = "Amy", Score = "100" });
            employeeList.Add(new Employee() { Id = 1, Name = "Lucy", Score = "99" });
            employeeList.Add(new Employee() { Id = 2, Name = "Tony", Score = "98" }); 
            employeeList.Add(new Employee() { Id = 3, Name = "Jack", Score = "97" });
            employeeList.Add(new Employee() { Id = 4, Name = "Jack2", Score = "97" });
            employeeList.Add(new Employee() { Id = 5, Name = "Jack3", Score = "97" });

            // 指定集合类型的源和目标
            this.ListBoxEmployee.ItemsSource = employeeList.Where(x=>x.Name.Contains("Jack"));
            //this.ListBoxEmployee.DisplayMemberPath = "Name";
        }
    }
}
