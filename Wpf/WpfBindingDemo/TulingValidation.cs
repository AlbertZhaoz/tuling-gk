using System.Globalization;
using System.Windows.Controls;

namespace WpfBindingDemo;

public class TulingValidation:ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        double d;

        if(double.TryParse(value.ToString(),out d))
        {
            if (d >= 0&&d<10)
            {
                return new ValidationResult(true,null);
            }
        }

        return new ValidationResult(false,"Validation Failed");
    }
}