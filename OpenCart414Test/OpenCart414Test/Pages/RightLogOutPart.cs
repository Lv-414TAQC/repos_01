using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    class RightLogOutPart : RightMenuPart
    {
        public IWebElement RightMenuLogin
        { get { return driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Login']")); } }
        public IWebElement RightMenuRegister
        { get { return driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Register']")); } }
        public RightLogOutPart(IWebDriver driver) : base(driver)
        {
        }
        public string GetRightMenuLoginText()
        {
            return RightMenuLogin.Text;
        }
        public void ClickRightMenuLogin()
        {
            RightMenuLogin.Click();
        }
        public string GetRightMenuRegisterText()
        {
            return RightMenuRegister.Text;
        }
        public void ClickRightMenuRegister()
        {
            RightMenuRegister.Click();
        }
    }
}
