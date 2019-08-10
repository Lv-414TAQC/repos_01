using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Data
{
    public class Product
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        //private Review review;
        public string BasePrice { get; private set; }
        private IDictionary<Currency, string> prices; // TODO Use Big/Decimal

        public Product(string title, string description, string basePrice)
        {
            Title = title;
            Description = description;
            BasePrice = basePrice;
            prices = new Dictionary<Currency, string>();
        }

        public Product AddPrice(Currency currency, string price)
        {
            prices.Add(currency, price);
            return this;
        }

        public string GetPrice(Currency currency)
        {
            return prices[currency];
        }
        public string GetName()
        {
            return Title;
        }
        public string GetDescription()
        {
            return Description;
        }
    }
}
