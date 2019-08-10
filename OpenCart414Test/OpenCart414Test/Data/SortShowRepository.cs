using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Data
{
    public sealed class SortShowRepository
    {
        private SortShowRepository() { }

        public static SortShowCriteria ShowBy25()
        {
            return new SortShowCriteria("Default", "25");
        }
    }
}
