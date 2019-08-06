using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCartTests.Stetsula
{
    abstract class HeaderPart
    {
        protected IWebDriver Driver;
        public IWebElement MenuButton { get { return Driver.FindElement(By.Id("button-menu")); } }
        public IWebElement Logo { get { return Driver.FindElement(By.CssSelector("a.navbar-brand")); } }
        public IWebElement LogoutButton { get { return Driver.FindElement(By.XPath("//a/i[@class='fa fa-sign-out fa-lg']//ancestor::a")); } }
        public DropDownMenuComponent NotificationsMenu;
        public DropDownMenuComponent StoresMenu;
        public DropDownMenuComponent HelpMenu;

        public HeaderPart(IWebDriver driver)
        {
            Driver = driver;
        }
    }

    
}
