using System.Globalization;
using System.Windows.Data;

namespace WpfTemplateStyleTrigger.Converters;

public class Name2PhotoPathConverter:IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var uriStr = $"/Resources/Images/{value}.png";
        return uriStr ;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}