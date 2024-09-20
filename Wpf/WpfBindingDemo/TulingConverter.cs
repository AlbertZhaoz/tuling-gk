using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfBindingDemo
{
    class TulingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Category c = (Category)value;

            switch (c)
            {
                case Category.Akun:
                    return @"\Resources\ak.png";
                case Category.Xc:
                    return @"\Resources\xc.png";
                case Category.Xj:
                    return @"\Resources\xj.png";
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class TulingMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!values.Cast<string>().Any(text => string.IsNullOrEmpty(text))
                && values[0].ToString() == values[1].ToString()
                && values[2].ToString() == values[3].ToString()
                )
            {
                return true;
            }

            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
