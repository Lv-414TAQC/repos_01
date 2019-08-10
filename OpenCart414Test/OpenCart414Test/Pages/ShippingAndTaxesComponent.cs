using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace OpenCart414Test.Pages
{
    class ShippingAndTaxesComponent
    {
        IWebDriver driver;
        public IWebElement ShippingAndTaxesButton{ get { return driver.FindElement(By.CssSelector("a[href = '#collapse-shipping']"); } }
        SelectElement country;
        SelectElement region;
        IWebElement postCode  { get { return driver.FindElement(By.Id("input-postcode")); } }
        IWebElement getQuotesButton { get { return driver.FindElement(By.Id("button-quote"))} }


        public ShippingAndTaxesComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        void ChooseCountry(string countryName)
        {
            country = new SelectElement(driver.FindElement(By.Id("input-country")));
            country.SelectByText(countryName);
        }

        void ChooseRegion(string regionName)
        {
            region = new SelectElement(driver.FindElement(By.Id("input-zone")));
            region.SelectByText(regionName);
        }
    }
}
