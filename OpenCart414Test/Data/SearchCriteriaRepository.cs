using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Data
{
    public sealed class SearchCriteriaRepository
    {
        private SearchCriteriaRepository() { }

        public static SearchCriteria GetMacBook()
        {
            return new SearchCriteria("MacBook",
                "Laptops & Notebooks", true, false);
        }
    }
}
