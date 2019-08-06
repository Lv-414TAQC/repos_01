using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCartTests.Stetsula.Pages
{
    class GeoZonesPage : HeaderPart
    {
        SideMenuComponent SideMenu;
        public IWebElement AddNewButton { get { return Driver.FindElement(By.CssSelector("a[data-original-title='Add New']")); } }
        public IWebElement DeleteButtton { get { return Driver.FindElement(By.CssSelector("a[data-original-title='Delete']")); } }
        

        public GeoZonesPage(IWebDriver driver) : base (driver)
        {
                
        }
    }
}
