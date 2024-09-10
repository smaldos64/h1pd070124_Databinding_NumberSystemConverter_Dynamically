using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databinding_NumberSystemConverter.ViewModels
{
    public class MyViewModel : INotifyPropertyChanged
    {
        private string _decimalValueString;

        public string DecimalValueString
        {
            get
            {
                return _decimalValueString;
            }
            set
            {
                _decimalValueString = value;
                OnPropertyChanged(nameof(DecimalValueString));
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
