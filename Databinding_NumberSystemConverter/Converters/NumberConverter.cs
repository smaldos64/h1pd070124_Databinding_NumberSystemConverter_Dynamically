using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Databinding_NumberSystemConverter.Converters
{
    public class NumberConverter : DependencyObject
    {
        public static readonly DependencyProperty DecimalStringValueProperty =
            DependencyProperty.Register(
                name: "DecimalStringValue", 
                propertyType: typeof(string), 
                ownerType: typeof(NumberConverter), 
                typeMetadata: new PropertyMetadata(0, OnDecimalValueChanged));

        public string DecimalValue
        {
            get => (string)GetValue(DecimalStringValueProperty);
            set => SetValue(DecimalStringValueProperty, value);
        }

        private static void OnDecimalValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // No need to do anything here, as the bindings will handle updates
        }
    }
}
