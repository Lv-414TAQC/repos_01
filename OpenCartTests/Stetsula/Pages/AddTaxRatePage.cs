using OpenCartTests.Stetsula;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyTests.Stetsula.Pages
{
    class AddTaxRatePage : HeaderPart
    {
        public IWebElement SaveButton { get { return Driver.FindElement(By.CssSelector("button[data-original-title='Save']")); } }
        public IWebElement Name { get { return Driver.FindElement(By.Id("input-name")); } }
        public IWebElement Rate { get { return Driver.FindElement(By.Id("input-rate")); } }
        public SelectElement Type { get { return new SelectElement(Driver.FindElement(By.Id("input-type"))); } }
        public SelectElement GeoZone { get { return new SelectElement(Driver.FindElement(By.Id("input-geo-zone"))); } }

        public AddTaxRatePage(IWebDriver driver) : base(driver)
        {

        }

        public void AddTaxRate(string name, double rate, string type, string geoZone)
        {
            Name.SendKeys(name);
            Rate.SendKeys(rate.ToString());
            Type.SelectByText(type);
            GeoZone.SelectByText(geoZone);
            SaveButton.Click();
        }
    }
}
