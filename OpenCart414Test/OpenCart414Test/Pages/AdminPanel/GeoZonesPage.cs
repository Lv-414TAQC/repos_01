using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart414Test.Data;

namespace OpenCart414Test.Pages.AdminPanel
{
    public class GeoZonesPage : SideMenuComponent
    {
        public IWebElement AddNewButton { get { return driver.FindElement(By.CssSelector("a[data-original-title='Add New']")); } }
        public IWebElement DeleteButtton { get { return driver.FindElement(By.CssSelector("button[data-original-title='Delete']")); } }
        public IList<GeoZoneComponent> GeoZones = new List<GeoZoneComponent>();

        public GeoZonesPage(IWebDriver driver) : base(driver)
        {
            GetGeoZones();

        }

        public void GetGeoZones()
        {
            foreach (IWebElement item in driver.FindElements(By.CssSelector("form tbody tr")))
            {
                GeoZoneComponent GeoZone = new GeoZoneComponent();
                GeoZone.Checkbox = item.FindElement(By.XPath("./td/input"));
                GeoZone.Name = item.FindElement(By.XPath("./td/following-sibling::td")).Text;
                GeoZone.Description = item.FindElement(By.XPath("./td/following-sibling::td//following-sibling::td")).Text;
                GeoZone.EditButton = item.FindElement(By.XPath("./td/a"));
                GeoZones.Add(GeoZone);

            }
        }

        public void SelectGeoZone(string geoZone)
        {
            foreach (var item in GeoZones)
            {
                if (item.Name == geoZone)
                    item.Checkbox.Click();
            }

        }

        public void DeleteGeoZone(string geoZone)
        {
            SelectGeoZone(geoZone);
            DeleteButtton.Click();
            driver.SwitchTo().Alert().Accept();
        }

        public void AddNewGeoZone(GeoZone geoZone)
        {
            AddNewButton.Click();
            AddGeoZonePage GeoZone = new AddGeoZonePage(driver);
            GeoZone.AddNewGeoZone(geoZone);

        }
    }
}

