using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfDependencyProp
{
    public class School:DependencyObject
    {
        // propa


        public static int GetGrade(DependencyObject obj)
        {
            return (int)obj.GetValue(GetGradeProperty);
        }

        public static void SetGetGrade(DependencyObject obj, int value)
        {
            obj.SetValue(GetGradeProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GetGradeProperty =
            DependencyProperty.RegisterAttached("GetGrade", typeof(int), typeof(School), new PropertyMetadata(0));


    }
}
