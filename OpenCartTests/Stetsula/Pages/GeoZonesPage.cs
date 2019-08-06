using System;
using System.Collections.Generic;
using System.Text;
using CurrencyTests.Stetsula.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCartTests.Stetsula.Pages
{
    class GeoZonesPage : HeaderPart
    {
        SideMenuComponent SideMenu;
        public IWebElement AddNewButton { get { return Driver.FindElement(By.CssSelector("a[data-original-title='Add New']")); } }
        public IWebElement DeleteButtton { get { return Driver.FindElement(By.CssSelector("a[data-original-title='Delete']")); } }
        public IList<GeoZoneComponent> GeoZones;

        public GeoZonesPage(IWebDriver driver) : base (driver)
        {
            GetGeoZones();

        }

        public void GetGeoZones()
        {
            foreach (IWebElement item in Driver.FindElements(By.CssSelector("form tbody tr")))
            {
                GeoZones = new List<GeoZoneComponent>();
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
                Console.WriteLine(item.Name);
                if (item.Name == geoZone)
                    item.Checkbox.Click();
            }

        }
    }
}
