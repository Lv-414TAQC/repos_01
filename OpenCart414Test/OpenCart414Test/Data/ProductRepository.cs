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

        public static Product GetIPhone()
        {
            return new Product("iPhone",
                "iPhone is a revolutionary new mobile phone that allows you to make a call by simply" +
                "tapping a name or number in your address book, a favorites list, or a call log." +
                "It also automatically syncs all your contacts from a PC, Mac, or Internet service." +
                "And it lets you select and listen to voicemail messages in whatever order you want just like email.", "100.00")
                .AddPrice(Currency.US_DOLLAR, "123.20")
                .AddPrice(Currency.EURO, "106.04")
                .AddPrice(Currency.POUND_STERLING, "92.93");
        }

        public static Product GetCanonEos5D()
        {
            return new Product("Canon EOS 5D",
                "Canon's press material for the EOS 5D states that it 'defines (a) new D-SLR category', while we're not typically too concerned with marketing talk this particular statement is clearly pretty accurate", "98.00")
                .AddPrice(Currency.US_DOLLAR, "123.20")
                .AddPrice(Currency.EURO, "106.04")
                .AddPrice(Currency.POUND_STERLING, "92.93");
        }
        //public static IList<Product> GetFromExternal() { }
    }
}
