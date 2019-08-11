using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using OpenCart414Test.Data;

namespace OpenCart414Test.Pages.AdminPanel
{
    class AddTaxRatePage : SideMenuComponent
    {
        public IWebElement SaveButton { get { return driver.FindElement(By.CssSelector("button[data-original-title='Save']")); } }
        public IWebElement Name { get { return driver.FindElement(By.Id("input-name")); } }
        public IWebElement Rate { get { return driver.FindElement(By.Id("input-rate")); } }
        public SelectElement Type { get { return new SelectElement(driver.FindElement(By.Id("input-type"))); } }
        public SelectElement GeoZone { get { return new SelectElement(driver.FindElement(By.Id("input-geo-zone"))); } }

        public AddTaxRatePage(IWebDriver driver) : base(driver)
        {

        }

        public void AddTaxRate(TaxRate rate)
        {
            Name.SendKeys(rate.Name);
            Rate.SendKeys(rate.Rate.ToString());
            Type.SelectByText(rate.Type);
            GeoZone.SelectByText(rate.GeoZone);
            SaveButton.Click();
        }
    }
}

