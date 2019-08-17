using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCart414Test.Pages.AdminPanel
{
    public abstract class HeaderPart
    {
        protected IWebDriver driver;
        public IWebElement MenuButton { get { return driver.FindElement(By.Id("button-menu")); } }
        public IWebElement Logo { get { return driver.FindElement(By.CssSelector("a.navbar-brand")); } }
        public IWebElement LogoutButton { get { return driver.FindElement(By.XPath("//a/i[@class='fa fa-sign-out fa-lg']//ancestor::a")); } }
        public DropDownMenuComponent NotificationsMenu;
        public DropDownMenuComponent StoresMenu;
        public DropDownMenuComponent HelpMenu;

        public HeaderPart(IWebDriver driver)
        {
            this.driver = driver;
        }
    }


}
