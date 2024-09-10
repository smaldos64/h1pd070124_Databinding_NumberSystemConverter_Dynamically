using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Databinding_NumberSystemConverter.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    public class GenericRadixNumberConverter : IValueConverter
    {
        private bool _waitingForDecimalConversionToOtherRadixNumberSystem = false;

        // Metoden herunder konverter fra det decimale talsystem =>
        // 10 tals/ciffer systemet til alle andre talsystemer. 
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            _waitingForDecimalConversionToOtherRadixNumberSystem = false;
            if (value is string text)
            {
                if (!string.IsNullOrEmpty(text))
                {
                    int radix = System.Convert.ToInt32(parameter);
                    //string TempString = System.Convert.ToString(System.Convert.ToUInt32(text, radix));
                    //String TempStringUpper = TempString.ToUpper();
                    //return TempStringUpper;
                    //String TempStringToReturn = System.Convert.ToString(System.Convert.ToUInt32(text, radix));
                    //return TempStringToReturn;
                    return System.Convert.ToString(System.Convert.ToUInt32(text), radix).ToUpper();
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

        // Metoden herunder konverter tilbage til det decimale talsystem =>
        // 10 tals/ciffer systemet fra alle andre talsystemer. 
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)

        {
            if (true == _waitingForDecimalConversionToOtherRadixNumberSystem)
            {
                return string.Empty;
            }
            else
            {
                _waitingForDecimalConversionToOtherRadixNumberSystem = true;
            }

            if (value is string text)
            {
                if (!string.IsNullOrEmpty(text))
                {
                    int radix = System.Convert.ToInt32(parameter);
                    string DecimalString = "";
                    try
                    {
                        DecimalString = System.Convert.ToString(System.Convert.ToUInt32(text, radix));
                        return DecimalString;
                    }
                    catch (Exception ex)
                    {
                        string ErrorString = ex.ToString();
                    }
                    return string.Empty;
                    //return System.Convert.ToString(System.Convert.ToUInt32(text, radix));
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

