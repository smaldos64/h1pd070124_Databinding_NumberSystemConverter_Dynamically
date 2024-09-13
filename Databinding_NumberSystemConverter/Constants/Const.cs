using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using ToolsLibrary;

namespace Databinding_NumberSystemConverter.Constants
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
    public class DynamicKeysInfo
    {
        public int FirstLabelInGridRowNumber;
        public int GridRowNumber;
        public int RadixNumber;

        public DynamicKeysInfo(int FirstLabelInGridRowNumber,
                               int GridRowNumber,
                               int RadixNumber)
        {
            this.FirstLabelInGridRowNumber = FirstLabelInGridRowNumber;
            this.GridRowNumber = GridRowNumber;
            this.RadixNumber = RadixNumber;
        }

        public DynamicKeysInfo()
        {
            
        }
    }
    public class Const
    {
        public static readonly int LabelColumnNumber = 1;
        public static readonly int LabelColumnSpan = 1;

        public static readonly int TextBoxColumnNumber = 2;
        public static readonly int TextBoxColumnSpan = 1;

        public static readonly int ButtonColumnNumber = 5;
        public static readonly int ButtonColumnSpan = 1;

        public static readonly int NumberOfControlsInRadixSystemsGridRow = 3;

        public static readonly int MaxByteValue = 255;
        public static readonly int NumberOfBitsInByte = 8;

        public static readonly int MinRadixNumberSystem = 2;
        public static readonly int MaxRadixNumberSystem = 32;

        public static readonly int MinOctetValue = 0;
        public static readonly int MaxOctetValue = 255;

        public static readonly string NothingEnteredInTextBox = "0";

        public static readonly char[] RadixCharacters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public static List<int> RadixNumberSystemInUseList = new List<int>()
        {
            2,
            8,
            10,
            16
        };

        public static List<DynamicKeysInfo> DynamicKeysInfoList = new List<DynamicKeysInfo>();

        public static Key[] ValidSystemsKeyArray =
        {
            Key.Delete,
            Key.Back
        };

        public static ValidKeysForNumberInRadixSystems[] RadixNumberSystemsValidKeysArray =
        {
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.D0,
                SecondValidKey = Key.NumPad0,
                IsKeyALetter = false
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.D1,
                SecondValidKey = Key.NumPad1,
                IsKeyALetter = false
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.D2,
                SecondValidKey = Key.NumPad2,
                IsKeyALetter = false
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.D3,
                SecondValidKey = Key.NumPad3,
                IsKeyALetter = false
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.D4,
                SecondValidKey = Key.NumPad4,
                IsKeyALetter = false
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.D5,
                SecondValidKey = Key.NumPad5,
                IsKeyALetter = false
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.D6,
                SecondValidKey = Key.NumPad6,
                IsKeyALetter = false
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.D7,
                SecondValidKey = Key.NumPad7,
                IsKeyALetter = false
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.D8,
                SecondValidKey = Key.NumPad8,
                IsKeyALetter = false
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.D9,
                SecondValidKey = Key.NumPad9,
                IsKeyALetter = false
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.A,
                SecondValidKey = Key.A,
                IsKeyALetter = true
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.B,
                SecondValidKey = Key.B,
                IsKeyALetter = true
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.C,
                SecondValidKey = Key.C,
                IsKeyALetter = true
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.D,
                SecondValidKey = Key.D,
                IsKeyALetter = true
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.E,
                SecondValidKey = Key.E,
                IsKeyALetter = true
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.F,
                SecondValidKey = Key.F,
                IsKeyALetter = true
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.G,
                SecondValidKey = Key.G,
                IsKeyALetter = true
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.H,
                SecondValidKey = Key.H,
                IsKeyALetter = true
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.I,
                SecondValidKey = Key.I,
                IsKeyALetter = true
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.J,
                SecondValidKey = Key.J,
                IsKeyALetter = true
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.K,
                SecondValidKey = Key.K,
                IsKeyALetter = true
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.L,
                SecondValidKey = Key.L,
                IsKeyALetter = true
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.M,
                SecondValidKey = Key.M,
                IsKeyALetter = true
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.N,
                SecondValidKey = Key.N,
                IsKeyALetter = true
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.O,
                SecondValidKey = Key.O,
                IsKeyALetter = true
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.P,
                SecondValidKey = Key.P,
                IsKeyALetter = true
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.Q,
                SecondValidKey = Key.Q,
                IsKeyALetter = true
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.R,
                SecondValidKey = Key.R,
                IsKeyALetter = true
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.S,
                SecondValidKey = Key.S,
                IsKeyALetter = true
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.T,
                SecondValidKey = Key.T,
                IsKeyALetter = true
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.U,
                SecondValidKey = Key.U,
                IsKeyALetter = true
            },
            new ValidKeysForNumberInRadixSystems()
            {
                FirstValidKey = Key.V,
                SecondValidKey = Key.V,
                IsKeyALetter = true
            }
        };

        public static List<SolidColorBrush> ColorList = new List<SolidColorBrush>()
        {
            new SolidColorBrush()
            {
                Color = Colors.Red
            },
            new SolidColorBrush()
            {
                Color = Colors.Green
            }
        };

        public static List<ColorValueAndColorName> ColorValueAndColorNamesList = new List<ColorValueAndColorName>()
        {
            //new ColorValueAndColorName("Red", Brushes.Red),
            //new ColorValueAndColorName("Green", Brushes.Green),
            new ColorValueAndColorName()
            {
                SolidColorBrushName = "Yellow",
                SolidColorBrushValue = Brushes.Yellow
            },
            new ColorValueAndColorName()
            {
                SolidColorBrushName = "Red",
                SolidColorBrushValue = Brushes.Red
            },
            new ColorValueAndColorName()
            {
                SolidColorBrushName = "Green",
                SolidColorBrushValue = Brushes.Green
            },
            new ColorValueAndColorName()
            {
                SolidColorBrushName = "Blue",
                SolidColorBrushValue = Brushes.Blue
            },
            new ColorValueAndColorName()
            {
                SolidColorBrushName = "White",
                SolidColorBrushValue = Brushes.White
            },
            new ColorValueAndColorName()
            {
                SolidColorBrushName = "Orange",
                SolidColorBrushValue = Brushes.Orange
            }
        };
    }
}
