using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using OpenCart414Test.Data;

namespace OpenCart414Test.Pages.AdminPanel
{
    public class TaxRatesPage : SideMenuComponent
    {
        IWebElement AddNewButton { get { return driver.FindElement(By.CssSelector("a[data-original-title='Add New']")); } }
        IWebElement DeleteButton { get { return driver.FindElement(By.CssSelector("button[data-original-title='Delete']")); } }
        IList<IWebElement> TaxRates = new List<IWebElement>();

        public TaxRatesPage(IWebDriver driver) : base(driver){ }

        public void GetTaxrates() { }

        public void AddNewTaxRate(TaxRate rate)
        {
            AddNewButton.Click();
            AddTaxRatePage TaxRate = new AddTaxRatePage(driver);
            TaxRate.AddTaxRate(rate);
        }

        public TaxRatesPage DeleteTaxRate(string taxRate)
        {
            string Path = String.Format(@"//td[contains(text(),'{0}')]/preceding-sibling::td/input", taxRate);
            foreach (var item in driver.FindElements(By.XPath(Path)))
                item.Click();
            driver.FindElement(By.CssSelector("button[data-original-title='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return new TaxRatesPage(driver);
        }
    }
}
