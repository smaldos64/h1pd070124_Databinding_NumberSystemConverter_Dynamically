using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Databinding_NumberSystemConverter.Tools
{
    public class ControlTools
    {
        public static void InsertRowInGrid(Grid Grid_Object)
        {
            RowDefinition MyRow = new RowDefinition();
            MyRow.Height = GridLength.Auto;
            Grid_Object.RowDefinitions.Add(MyRow);
        }

        public static Label InsertLabelInGrid(Grid Grid_Object, 
                                              string LabelName, 
                                              string LabelText,
                                              int RowPosition, 
                                              int ColumnPosition, 
                                              int ColumnSpan)
        {
            Label Label_Object = new Label();

            Label_Object.Name = LabelName;
            Label_Object.Content = LabelText;
            Label_Object.SetValue(Grid.ColumnSpanProperty, ColumnSpan);

            Grid_Object.Children.Add(Label_Object);
            Grid.SetColumn(Label_Object, ColumnPosition);
            Grid.SetRow(Label_Object, RowPosition);

            return (Label_Object);
        }

        public static TextBox InsertTextBoxInGrid(Grid Grid_Object, 
                                                  string TextBoxName, 
                                                  int RowPosition,
                                                  int ColumnPosition, 
                                                  int ColumnSpan, 
                                                  int Width, 
                                                  int Height,
                                                  KeyEventHandler FunctionKeyDown,
                                                  TextChangedEventHandler FunctionTextChanged,
                                                  string TextBox_Text = "",
                                                  bool DisableTextBox = false)
        {
            TextBox TextBox_Object = new TextBox();

            TextBox_Object.Name = TextBoxName;
            TextBox_Object.SetValue(Grid.ColumnSpanProperty, ColumnSpan);
            TextBox_Object.Width = Width;
            TextBox_Object.Height = Height;

            if (null != FunctionTextChanged)
            {
                TextBox_Object.TextChanged += FunctionTextChanged;
            }

            if (null != FunctionKeyDown)
            {
                TextBox_Object.KeyDown += FunctionKeyDown;
            }

            if ("" != TextBox_Text)
            {
                TextBox_Object.Text = TextBox_Text;
            }

            if (true == DisableTextBox)
            {
                TextBox_Object.IsReadOnly = true;
                TextBox_Object.Background = Brushes.Yellow;
                TextBox_Object.Foreground = Brushes.Blue;
            }

            Grid_Object.Children.Add(TextBox_Object);
            Grid.SetColumn(TextBox_Object, ColumnPosition);
            Grid.SetRow(TextBox_Object, RowPosition);

            return (TextBox_Object);
        }

        public static Button InsertButtonInGrid(Grid Grid_Object,
                                                string ButtonName, 
                                                string ButtonText, 
                                                int RowPosition,
                                                int ColumnPosition, 
                                                int ColumnSpan, 
                                                int Width, 
                                                int Height,
                                                RoutedEventHandler FunctionButtonClicked)
        {
            Button Button_Object = new Button();

            Button_Object.Name = ButtonName;
            Button_Object.Width = Width;
            Button_Object.Height = Height;
            Button_Object.Content = ButtonText;
            Button_Object.SetValue(Grid.ColumnSpanProperty, ColumnSpan);

            Button_Object.Click += FunctionButtonClicked;

            Grid_Object.Children.Add(Button_Object);
            Grid.SetColumn(Button_Object, ColumnPosition);
            Grid.SetRow(Button_Object, RowPosition);

            return (Button_Object);
        }
    }
}
