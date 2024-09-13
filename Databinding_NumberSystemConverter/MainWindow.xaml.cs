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
using Databinding_NumberSystemConverter.Classes;
using Databinding_NumberSystemConverter.ViewModels;
using Databinding_NumberSystemConverter.ExtensionMethods;
using System.Collections.ObjectModel;

namespace Databinding_NumberSystemConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProjectViewModel ProjectViewModelObject = new ProjectViewModel();

        public MainWindow()
        {
            InitializeComponent();

            ProjectViewModelObject.RadixNumberSystemsList = Const.RadixNumberSystemsList;
            cmbRadixNumbers.ItemsSource = ProjectViewModelObject.RadixNumberSystemsList;
            cmbRadixNumbers.SelectedIndex = 0;

            ProjectViewModelObject.ColorValueAndColorNameList = Const.ColorValueAndColorNamesList;
            cmbBackGroundColors.ItemsSource = ProjectViewModelObject.ColorValueAndColorNameList;
            cmbBackGroundColors.SelectedIndex = 0;

            cmbAllBackGroundColors.ItemsSource = PredefinedBrushes.Brushes;
            cmbAllBackGroundColors.SelectedIndex = 0;
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
            if (!Const.ColorValueAndColorNamesList.Any(i => i.SolidColorBrushName == ColorValueAndColorNameObject.SolidColorBrushName))
            {
                Const.ColorValueAndColorNamesList.Add(ColorValueAndColorNameObject);
            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        private void btnCloseApplication_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cmbBackGroundColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Background = ((ColorValueAndColorName)cmbBackGroundColors.SelectedItem).SolidColorBrushValue;
        }

        #region DynamicRadixNumberSystemHandling
        private void btnAddRadixNumberSystem_Click(object sender, RoutedEventArgs e)
        {
            int RadixNumberSystemValue = Convert.ToInt16(cmbRadixNumbers.SelectedValue);
            DynamicKeysInfo DynamicKeysInfoObject = new DynamicKeysInfo();
            TextBox TextBoxObject = new TextBox();

            if ((RadixNumberSystemValue >= Const.MinRadixNumberSystem) &&
                 (RadixNumberSystemValue <= Const.MaxRadixNumberSystem))
            {
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
                TextBoxObject.IsReadOnly = true;

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

                Const.RadixNumberSystemsList.Remove(RadixNumberSystemValue);
                cmbRadixNumbers.SelectedIndex = 0;
            }
        }

        private void btnDeleteNumbers_Click(object sender, RoutedEventArgs e)
        {
            // Viser hvor stærk DataBinding er. Alle tekstbokse relateret til 
            // RadixNumber SYstem vil have deres tekst slettet netop på grund
            // af deres indbyrdes DataBindings. 
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

            Const.RadixNumberSystemsList.Add(RadixNumberSystemValue);
            Const.RadixNumberSystemsList.BubbleSort();
            cmbRadixNumbers.SelectedIndex = 0;
        }
        #endregion
    }   
}