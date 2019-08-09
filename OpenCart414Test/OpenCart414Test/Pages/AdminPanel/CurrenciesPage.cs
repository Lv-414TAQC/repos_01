using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OpenCart414Test.Pages.AdminPanel
{
    class CurrenciesPage : HeaderPart
    {
        IWebElement RefrefhButton { get { return Driver.FindElement(By.CssSelector("a[data-original-title='Refresh Currency Values']")); } }
        IWebElement AddButton { get { return Driver.FindElement(By.CssSelector("a[data-original-title='Add New']")); } }
        IWebElement DeleteButton { get { return Driver.FindElement(By.CssSelector("a[data-original-title='Delete']")); } }
        IList<CurrencyComponent> Currencies;

        public CurrenciesPage(IWebDriver driver) : base(driver)
        {
            Currencies = new List<CurrencyComponent>();
            GetCurrencies();
        }

        void GetCurrencies()
        {
            foreach (IWebElement item in Driver.FindElements(By.CssSelector("table.table-bordered.table-hover tbody tr")))
            {
                CurrencyComponent Currency = new CurrencyComponent();
                Currency.CheckBox = item.FindElement(By.XPath("./td/input"));
                Currency.Title = item.FindElement(By.XPath("./td/input/../following-sibling::td")).Text;
                Currency.Value = Decimal.Parse(item.FindElement(By.XPath("./td/input/../following-sibling::td[@class='text-right']")).Text.Replace(".", ","));
                Currencies.Add(Currency);
            }
        }

        public decimal GetCurrencyRate(string currency)
        {
            decimal value = 0;
            foreach (CurrencyComponent item in Currencies)
            {
                if (item.Title == currency)
                {
                    value = item.Value;
                    break;
                }
            }
            return value;
        }

    }
}

