using CurrencyTests.Stetsula.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCartTests.Stetsula.Pages
{
    class TaxRatesPage : HeaderPart
    {
        IWebElement AddNewButton { get { return Driver.FindElement(By.CssSelector("a[data-original-title='Add New']")); } } 
        IWebElement DeleteButton { get { return Driver.FindElement(By.CssSelector("button[data-original-title='Delete']")); } } 
        IList<IWebElement> TaxRates = new List<IWebElement>();

        public TaxRatesPage(IWebDriver driver) : base(driver)
        {
            

        }

        public void GetTaxrates()
        {

        }

        public void AddNewTaxRate(string name, double rate, string type, string geoZone)
        {
            AddNewButton.Click();
            AddTaxRatePage TaxRate = new AddTaxRatePage(Driver);
            TaxRate.AddTaxRate(name, rate, type, geoZone);
        }

        public void DeleteTaxrate(string taxRate)
        {
            string Path = String.Format(@"//td[contains(text(),'{0}')]/preceding-sibling::td/input", taxRate);
            foreach (var item in Driver.FindElements(By.XPath(Path)))
                item.Click();
            Driver.FindElement(By.CssSelector("button[data-original-title='Delete']")).Click();
            Driver.SwitchTo().Alert().Accept();
        }
    }
}
