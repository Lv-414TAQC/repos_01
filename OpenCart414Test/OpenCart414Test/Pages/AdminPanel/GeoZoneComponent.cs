using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart414Test.Pages.AdminPanel
{
    public class GeoZoneComponent
    {
        public IWebElement Checkbox;
        public string Name { get; set; }
        public string Description { get; set; }
        public IWebElement EditButton { get; set; }
    }
}
