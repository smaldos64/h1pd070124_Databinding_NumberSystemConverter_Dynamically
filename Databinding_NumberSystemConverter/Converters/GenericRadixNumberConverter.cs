using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;

using Databinding_NumberSystemConverter.Constants;

namespace Databinding_NumberSystemConverter.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    public class GenericRadixNumberConverter : IValueConverter
    {
        // Metoden herunder konverter fra det decimale talsystem =>
        // 10 tals/ciffer systemet til alle andre talsystemer. 
        public object Convert(object Value, Type TargetType, object Parameter, System.Globalization.CultureInfo Culture)
        {
            if (Value is string Text)
            {
                if (!string.IsNullOrEmpty(Text))
                {
                    int Radix = System.Convert.ToInt32(Parameter);
                    //return System.Convert.ToString(System.Convert.ToUInt32(Text), Radix).ToUpper();
                    return (ConvertFromDecimalToRadixSystem(Text, Radix));
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
        public object ConvertBack(object Value, Type TargetType, object Parameter, System.Globalization.CultureInfo Culture)

        {
            if (Value is string Text)
            {
                if (!string.IsNullOrEmpty(Text))
                {
                    int Radix = System.Convert.ToInt32(Parameter);
                    return ConvertFromRadixSystemToDecimal(Text, Radix);
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

        private string ConvertFromRadixSystemToDecimal(string RadixNumberSystemString, int Radix)
        {
            int DecimalValue = 0;
            int Power = RadixNumberSystemString.Length - 1;

            foreach (char c in RadixNumberSystemString)
            {
                int DigitValue = Array.IndexOf(Const.RadixCharacters, c);
                DecimalValue += DigitValue * (int)Math.Pow(32, Power);
                Power--;
            }

            return DecimalValue.ToString();
        }

        private string ConvertFromDecimalToRadixSystem(string DecimalString, int Radix)
        {
            int DecimalValue = System.Convert.ToInt32(DecimalString);
            StringBuilder RadixNumberSystemString = new StringBuilder();

            while (DecimalValue > 0)
            {
                int DigitValue = DecimalValue % Radix;
                RadixNumberSystemString.Insert(0, Const.RadixCharacters[DigitValue]);
                DecimalValue /= Radix;
            }

            return RadixNumberSystemString.ToString();
        }
    }
}

