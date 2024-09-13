using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databinding_NumberSystemConverter.Classes
{
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
}
