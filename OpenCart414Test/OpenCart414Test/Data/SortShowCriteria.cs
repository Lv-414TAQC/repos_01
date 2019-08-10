using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Data
{
    public class SortShowCriteria
    {
        public string SortValue { get; private set; }
        public string ShowValue { get; private set; }

        public SortShowCriteria(string sortValue,string showValue)
        {
            SortValue = sortValue;
            ShowValue = showValue;
        }

    }
}
