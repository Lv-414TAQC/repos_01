using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCart414Test.Pages.AdminPanel
{
    class SideMenuComponent
    {
        IWebDriver driver;
        public IWebElement ProfileSection { get { return driver.FindElement(By.Id("profile")); } }
        public IWebElement DashboardButton { get { return driver.FindElement(By.Id("menu-dashboard")); } }
        public Dictionary<string, MenuComponent> Menus = new Dictionary<string, MenuComponent>();

        public SideMenuComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        //public void ClickMenu(string menu)
        //    {
        //        Menus[menu].Click();
        //    }
    }

}
