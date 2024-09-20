using System.Globalization;
using System.Resources;
using System.Windows.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WpfTemplateStyleTrigger.Converters;

public class Automaker2LogoPathConverter:IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string uriStr = $"/Resources/Logos/{value}.png";
        return uriStr;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}