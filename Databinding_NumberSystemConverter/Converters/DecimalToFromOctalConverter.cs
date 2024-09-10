using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Databinding_NumberSystemConverter.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    public class DecimalToFromOctalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string text)
            {
                if (!string.IsNullOrEmpty(text))
                {
                    return System.Convert.ToString(System.Convert.ToUInt32(text), 8);
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string text)
            {
                if (!string.IsNullOrEmpty(text))
                {
                    return System.Convert.ToString(System.Convert.ToUInt32(text, 8));
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }
    }
}

