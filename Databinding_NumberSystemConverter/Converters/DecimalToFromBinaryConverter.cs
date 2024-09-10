using Databinding_NumberSystemConverter.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Databinding_NumberSystemConverter.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    public class DecimalToFromBinaryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string text)
            {
                if (!string.IsNullOrEmpty(text))
                {
                    return System.Convert.ToString(System.Convert.ToUInt32(text), 2);
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
                    return System.Convert.ToString(System.Convert.ToUInt32(text, 2));
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
