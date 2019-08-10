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
        public static SearchCriteria GetMacBookD()
        {
            return new SearchCriteria("Mac",
                "Laptops & Notebooks", false, false);
        }
        public static SearchCriteria GetHpSearchCriteria()
        {
            return new SearchCriteria("with the stunning new 30-inch diagonal",
                "Laptops & Notebooks", false, true);
        }
        public static SearchCriteria GetImac()
        {
            return new SearchCriteria("iM",
                "Desktops", true, false);
        }
        public static SearchCriteria GetAllProducts()
        {
            return new SearchCriteria("%",
                "", false, false);
        }
        public static SearchCriteria GetAllProducts()
        {
            return new SearchCriteria("%",
                "", false, false);
        }
        public static SearchCriteria GetUnsuccessSearch()
        {
            return new SearchCriteria("qweqwe",
                "", false, false);
        }
    }
}
