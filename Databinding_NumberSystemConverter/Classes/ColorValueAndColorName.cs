using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Databinding_NumberSystemConverter.Classes
{
    public class ColorValueAndColorName
    { 
        // Man skal huske at bruge { get; set; } "notationen" på sine variable,
        // hvis man vil binde til disse fra sin *.xaml fil. Ellers virker
        // bindingen ikke !!!
        public string SolidColorBrushName { get; set; }
        //public SolidColorBrush SolidColorBrushValue { get; set; } = new SolidColorBrush();
        public Brush SolidColorBrushValue { get; set; }

        public ColorValueAndColorName()
        {

        }

        public ColorValueAndColorName(string SolidColorBrushName,
                                      SolidColorBrush SolidColorBrushValue)
        {
            this.SolidColorBrushName = SolidColorBrushName;
            this.SolidColorBrushValue = SolidColorBrushValue;
        }

        // Funktionen herunder bliver gældende, hvis man i MainWindow.xaml filen
        // har en erklæring som nu : DisplayMemberPath="{Binding Path=SolidColorBrushName}"
        // Så i dette tilfælde kan man faktisk skrive hvad som helst efter lighedstegnet i
        // DisplayMemberPath erklæringen i sin MainWindow.xaml. F.eks. vil dette her 
        // også virke : DisplayMemberPath="{Binding Path=Lars!!!}".
        // Man bør selvfølgelig for overskuelighedens skyld bibeholde :
        // DisplayMemberPath="{Binding Path=SolidColorBrushName}" .

        // Hvis man i stedet for i sin MainWindow.xaml fil har en erklæring :
        // DisplayMemberPath="SolidColorBrushName", bliver funktionen IKKE gældende.
        // I stedet for laves de en direkte reference til SolidColorBrushName i 
        // dette tilfælde.
        public override string ToString()
        {
            return (this.SolidColorBrushName);
        }
    }

    public class ColorValueAndColorNameEqualityComparer : IEqualityComparer<ColorValueAndColorName>
    {
        public bool Equals(ColorValueAndColorName? b1, ColorValueAndColorName? b2)
        {
            if (ReferenceEquals(b1, b2))
                return true;

            if (b2 is null || b1 is null)
                return false;

            return (b1.SolidColorBrushName == b2.SolidColorBrushName);
        }

        public int GetHashCode(ColorValueAndColorName box)
        {
            return box.SolidColorBrushName.GetHashCode();
        }
    }
}
