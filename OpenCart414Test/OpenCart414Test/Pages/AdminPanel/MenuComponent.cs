using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OpenCart414Test.Pages.AdminPanel
{
    public  class MenuComponent
    {
        IWebDriver Driver;
        public IWebElement MenuButton { get; set; }
        public string MenuLabel;
        //public string Path;

        //public void Click()
        //{
        //    //if (ParentMenu != null)
        //      ///  ParentMenu.Click();
        //    //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        //    //var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(MenuXPath)));
        //    //Actions action = new Actions(Driver);
        //    //action.MoveToElement(element).Perform();
        //    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    Driver.FindElement(By.XPath(Path)).Click();
        //}

        public MenuComponent(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
