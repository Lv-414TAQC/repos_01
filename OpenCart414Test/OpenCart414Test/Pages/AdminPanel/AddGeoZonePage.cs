using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using OpenCart414Test.Data;

namespace OpenCart414Test.Pages.AdminPanel
{
    class AddGeoZonePage : SideMenuComponent
    {
        public IWebElement GeoZoneName { get { return driver.FindElement(By.Id("input-name")); } }
        public IWebElement Description { get { return driver.FindElement(By.Id("input-description")); } }




        public AddGeoZonePage(IWebDriver driver) : base(driver)
        {


        }

        public void AddNewGeoZone(GeoZone geoZone)
        {
            GeoZoneName.SendKeys(geoZone.Name);
            Description.SendKeys(geoZone.Description);
            driver.FindElement(By.CssSelector("button[data-original-title='Add Geo Zone']")).Click();
            SelectElement Country = new SelectElement(driver.FindElement(By.Name("zone_to_geo_zone[0][country_id]")));
            Country.SelectByText(geoZone.Country);
            driver.FindElement(By.CssSelector("button[data-original-title='Save']")).Click();
        }
    }
}

