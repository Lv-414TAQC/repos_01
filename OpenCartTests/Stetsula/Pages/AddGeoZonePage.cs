using OpenCartTests.Stetsula;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyTests.Stetsula.Pages
{
    class AddGeoZonePage : HeaderPart
    {
        public IWebElement GeoZoneName { get { return Driver.FindElement(By.Id("input-name")); } }
        public IWebElement Description { get { return Driver.FindElement(By.Id("input-description")); } }
        
        
        

        public AddGeoZonePage(IWebDriver driver) : base(driver)
        {


        }

        public void AddNewGeoZone(string name, string description, string country)
        {
            GeoZoneName.SendKeys(name);
            Description.SendKeys(description);
            Driver.FindElement(By.CssSelector("button[data-original-title='Add Geo Zone']")).Click();
            SelectElement Country = new SelectElement(Driver.FindElement(By.Name("zone_to_geo_zone[0][country_id]")));
            Country.SelectByText(country);
            Driver.FindElement(By.CssSelector("button[data-original-title='Save']")).Click();
    }
    }
}
