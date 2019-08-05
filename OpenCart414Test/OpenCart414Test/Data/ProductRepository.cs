using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Data
{
    public sealed class ProductRepository
    {
        private ProductRepository() { }

        public static Product GetMacBook()
        {
            return new Product("MacBook",
                //"Intel Core 2 Duo processor Powered by an Intel Core 2 Duo processor at speeds up to 2.1..",
                "Powered by an Intel Core 2 Duo processor at speeds up to 2.1.",
                "500.00")
                .AddPrice(Currency.US_DOLLAR, "602.00")
                .AddPrice(Currency.EURO, "472.33")
                .AddPrice(Currency.POUND_STERLING, "368.73");
        }

        //public static IList<Product> GetFromExternal() { }
    }
}
