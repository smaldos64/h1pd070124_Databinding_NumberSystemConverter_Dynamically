#define Use_XAML_Components_In_Code

using CommunityToolkit.Mvvm.ComponentModel;
using Databinding_NumberSystemConverter.Constants;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToolsLibrary;
using static System.Net.Mime.MediaTypeNames;

using Databinding_NumberSystemConverter.Tools;
using System.Reflection;
using System.Configuration;
using Databinding_NumberSystemConverter.Converters;
using System.Collections.ObjectModel;

namespace Databinding_NumberSystemConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<ColorValueAndColorName> ColorValueAndColorNamesListTemp = new ObservableCollection<ColorValueAndColorName>(Const.ColorValueAndColorNamesList);
        //{
        //    get { return (Const.ColorValueAndColorNamesList; }
        //}
        ObservableCollection<ColorValueAndColorName> ColorValueAndColorNamesList
        {
            get { return ColorValueAndColorNamesListTemp; }
        }

        //ObservableCollection<int> ComboBoxList = new ObservableCollection<int>()
        //{
        //    3, 4, 5, 6, 7, 9, 12, 13, 14, 15
        //};

        ObservableCollection<MyItem> myItems = new ObservableCollection<MyItem>
        {
            new MyItem { Property1 = "Value1", Property2 = 10 },
            new MyItem { Property1 = "Value2", Property2 = 20 },
            // ... more items
        };

        public MainWindow()
        {
            InitializeComponent();
            InitializeComboBoxRadixNumbers();
            InitializeComboBoxBackGroundColors();
            this.DataContext = new MyViewModel { MyItems = myItems };
            cmbTestListBinding.SelectedIndex = 0;
            //cmbAllBackGroundColors.ItemsSource = PredefinedBrushes.Brushes;
            cmbAllBackGroundColors.SelectedIndex = 0;
        }

        private void InitializeComboBoxRadixNumbers()
        {
            cmbRadixNumbers.Items.Clear();
            for (int Counter = Const.MinRadixNumberSystem; Counter <= Const.MaxRadixNumberSystem; ++Counter)
            {
                if (!Const.RadixNumberSystemInUseList.Contains(Counter))
                {
                    cmbRadixNumbers.Items.Add(Counter.ToString());
                }
            }
            cmbRadixNumbers.SelectedIndex = 0;
        }

        private void InitializeComboBoxBackGroundColors()
        {
            //cmbBackGroundColors.Items.Clear();
            cmbBackGroundColors.ItemsSource = ColorValueAndColorNamesList;

            //cmbBackGroundColors.ItemsSource = Const.ColorValueAndColorNamesList;
            //cmbBackGroundColors.DisplayMemberPath = "ColorValueAndColorName.SolidColorBrushName";
            //cmbBackGroundColors.SelectedValuePath = "SolidColorBrushValue";

            //for (int Counter = 0; Counter < Const.ColorList.Count; ++Counter)
            //{
            //    cmbBackGroundColors.Items.Add(Const.ColorList[Counter]);
            //    //cmbBackGroundColors.Items.Insert(Counter, Const.ColorValueAndColorNamesList[Counter]);
            //}

            //for (int Counter = 0; Counter < Const.ColorValueAndColorNamesList.Count; ++Counter)
            //{
            //    ComboBox ComboBoxItem = new ComboBox();
            //    ComboBoxItem.DisplayMemberPath = Const.ColorValueAndColorNamesList[Counter].SolidColorBrushName;
            //    ComboBoxItem.SelectedValue = Const.ColorValueAndColorNamesList[Counter].SolidColorBrushValue;
            //    cmbBackGroundColors.Items.Add(ComboBoxItem);
            //}

            //ComboBox ComboBoxItem = new ComboBox();
            //ComboBoxItem.DataContext = Const.ColorValueAndColorNamesList;
            //ComboBoxItem.DisplayMemberPath = "SolidColorBrushName";
            //ComboBoxItem.SelectedValuePath = "SolidColorBrushValue";
            //cmbBackGroundColors.Items.Add(ComboBoxItem);
            cmbBackGroundColors.SelectedIndex = 0;
        }

        private void txtCheckForValidPositiveNumberPressedForRadixSystem(object sender, KeyEventArgs e)
        {
            if (!(KeyHelper.IsKeyPressedValidInSpecifiedKeyArray(e.Key, Const.ValidSystemsKeyArray)))
            {
                if (!(KeyHelper.IsKeyPressedValidForCurrentNumberSystem(e.Key,
                                                                        Const.RadixNumberSystemsValidKeysArray,
                                                                        int.Parse(((TextBox)sender).Tag.ToString()))))
                {
                    SystemSounds.Beep.Play();
                    e.Handled = true;
                }
            }
        }

        private void btnAddBackGroundColor_Click(object sender, RoutedEventArgs e)
        {
            ColorValueAndColorName ColorValueAndColorNameObject = new ColorValueAndColorName();
            ColorValueAndColorNameObject.SolidColorBrushName = ((PredefinedBrush)cmbAllBackGroundColors.SelectedItem).BrushName;
            ColorValueAndColorNameObject.SolidColorBrushValue = ((PredefinedBrush)cmbAllBackGroundColors.SelectedItem).BrushColor;
            Const.ColorValueAndColorNamesList.Add(ColorValueAndColorNameObject);
        }

        private void cmbBackGroundColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Background = ((ColorValueAndColorName)cmbBackGroundColors.SelectedItem).SolidColorBrushValue;
        }

        #region DynamicRadixNumberSystemHandling
        private void btnRadixNumbers_Click(object sender, RoutedEventArgs e)
        {
            int RadixNumberSystemValue = Convert.ToInt16(cmbRadixNumbers.SelectedValue);
            DynamicKeysInfo DynamicKeysInfoObject = new DynamicKeysInfo();
            TextBox TextBoxObject = new TextBox();

            if ((RadixNumberSystemValue >= Const.MinRadixNumberSystem) &&
                 (RadixNumberSystemValue <= Const.MaxRadixNumberSystem))
            {
                Const.RadixNumberSystemInUseList.Add(RadixNumberSystemValue);
                InitializeComboBoxRadixNumbers();

                ControlTools.InsertRowInGrid(MainGrid);

                String LabelName = "lblRadixNumber" + RadixNumberSystemValue.ToString();
                String LabelText = RadixNumberSystemValue.ToString() + " Tal System (" + RadixNumberSystemValue.ToString() + " tal / cifre) : ";
                ControlTools.InsertLabelInGrid(MainGrid,
                                               LabelName,
                                               LabelText,
                                               (MainGrid.RowDefinitions.Count - 1),
                                               Const.LabelColumnNumber,
                                               Const.LabelColumnSpan);

                DynamicKeysInfoObject.FirstLabelInGridRowNumber = MainGrid.Children.Count - 1;
                DynamicKeysInfoObject.GridRowNumber = MainGrid.RowDefinitions.Count - 1;
                DynamicKeysInfoObject.RadixNumber = RadixNumberSystemValue;

                Const.DynamicKeysInfoList.Add(DynamicKeysInfoObject);

                string TextBoxName = "txtRadixNumber" + RadixNumberSystemValue.ToString();
                TextBoxObject = ControlTools.InsertTextBoxInGrid(MainGrid,
                                                 TextBoxName,
                                                 (MainGrid.RowDefinitions.Count - 1),
                                                 Const.TextBoxColumnNumber,
                                                 Const.TextBoxColumnSpan,
                                                 220,
                                                 23,
                                                 FunctionKeyDown: txtCheckForValidPositiveNumberPressedForRadixSystem,
                                                 FunctionTextChanged: null);

                TextBoxObject.Tag = RadixNumberSystemValue;
                TextBoxObject.MaxLength = 8;

                Binding BindingObject = new Binding();
                BindingObject.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                BindingObject.Mode = BindingMode.TwoWay;
                BindingObject.ElementName = "txtRadixNumber10";
                BindingObject.Path = new PropertyPath(TextBox.TextProperty);
                BindingObject.ConverterParameter = RadixNumberSystemValue;
                BindingObject.Converter = new GenericRadixNumberConverter();

                BindingOperations.SetBinding(TextBoxObject, TextBox.TextProperty, BindingObject);

                string ButtonName = "btnRadixNumber_" + RadixNumberSystemValue.ToString();
                string ButtonText = "Slet " + RadixNumberSystemValue.ToString() + " tal/ciffer systemet";

                ControlTools.InsertButtonInGrid(MainGrid,
                                                ButtonName,
                                                ButtonText,
                                                (MainGrid.RowDefinitions.Count - 1),
                                                Const.ButtonColumnNumber,
                                                Const.ButtonColumnSpan,
                                                220,
                                                23,
                                                FunctionButtonClicked: btnClearRadixSystem_Click);
            }
        }

        private void btnDeleteNumbers_Click(object sender, RoutedEventArgs e)
        {
            txtRadixNumber2.Text = String.Empty;
        }

        private void btnClearRadixSystem_Click(object sender, RoutedEventArgs e)
        {
            int LabelComponentNumberInGrid = -1;

            String ButtonName = (((System.Windows.FrameworkElement)sender).Name);
            ButtonName = ButtonName.Trim();
            int SearchPosition = ButtonName.LastIndexOf("_");
            int RadixNumberSystemValue = Convert.ToInt32(ButtonName.Substring(SearchPosition + 1));

            int IndexInComponentsList = Const.DynamicKeysInfoList.FindIndex(r => r.RadixNumber == RadixNumberSystemValue);

            if (Const.DynamicKeysInfoList.Count - 1 == IndexInComponentsList)
            {
                MainGrid.Children.RemoveRange(Const.DynamicKeysInfoList[IndexInComponentsList].FirstLabelInGridRowNumber,
                                              Const.NumberOfControlsInRadixSystemsGridRow);
            }
            else
            {
                MainGrid.Children.RemoveRange(Const.DynamicKeysInfoList[IndexInComponentsList].FirstLabelInGridRowNumber,
                                              Const.DynamicKeysInfoList[IndexInComponentsList + 1].FirstLabelInGridRowNumber -
                                              Const.DynamicKeysInfoList[IndexInComponentsList].FirstLabelInGridRowNumber);
            }

            MainGrid.RowDefinitions.RemoveAt(Const.DynamicKeysInfoList[IndexInComponentsList].GridRowNumber);

            int CounterInDynamicKeysInfoList = IndexInComponentsList + 1;

            while (CounterInDynamicKeysInfoList < Const.DynamicKeysInfoList.Count)
            {
                int LabelComponentNumberInGridSave = Const.DynamicKeysInfoList[CounterInDynamicKeysInfoList].FirstLabelInGridRowNumber;
                Const.DynamicKeysInfoList[CounterInDynamicKeysInfoList].FirstLabelInGridRowNumber = LabelComponentNumberInGrid;
                LabelComponentNumberInGrid = LabelComponentNumberInGridSave;
                Const.DynamicKeysInfoList[CounterInDynamicKeysInfoList].GridRowNumber--;

                CounterInDynamicKeysInfoList++;
            }

            Const.DynamicKeysInfoList.RemoveAt(IndexInComponentsList);

            int IndexInRadixNumberSystemInUseList = Const.RadixNumberSystemInUseList.FindIndex(r => r == RadixNumberSystemValue);

            Const.RadixNumberSystemInUseList.RemoveAt(IndexInRadixNumberSystemInUseList);

            InitializeComboBoxRadixNumbers();
        }
        #endregion

        private void btnTestComboBox_Click(object sender, RoutedEventArgs e)
        {
            MyItem MyItemObject = new MyItem();

            MyItemObject.Property1 = txtTestString.Text;
            MyItemObject.Property2 = Convert.ToInt32(txtTestInt.Text);
            myItems.Add(MyItemObject);
            txtTestString.Text = String.Empty;
            txtTestInt.Text = String.Empty;
        }

        private void cmbTestListBinding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtTestComboBoxSeletion.Text = ((MyItem)cmbTestListBinding.SelectedItem).Property1 + " : " +
                                           ((MyItem)cmbTestListBinding.SelectedItem).Property2.ToString();
        }
        
    }

    public class MyItem
    {
        public string Property1 { get; set; } = null;
        public int Property2 { get; set; }

        public override string ToString()
        {
            return (this.Property1);
        }
    }

    public class MyViewModel
    {
        public ObservableCollection<MyItem> MyItems { get; set; }
    }
}