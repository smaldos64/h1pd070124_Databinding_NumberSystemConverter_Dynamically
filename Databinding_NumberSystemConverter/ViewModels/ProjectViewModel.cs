using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Databinding_NumberSystemConverter.Constants;
using Databinding_NumberSystemConverter.Classes;

namespace Databinding_NumberSystemConverter.ViewModels
{
    public class ProjectViewModel 
    {
        public ObservableCollection<ColorValueAndColorName> ColorValueAndColorNameList { get; set; }

        public ObservableCollection<int> RadixNumberSystemsList { get; set; }
    }
}
