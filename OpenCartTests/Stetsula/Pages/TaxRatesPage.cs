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

        public void AddNewTaxRate()
        {

        }
    }
}
