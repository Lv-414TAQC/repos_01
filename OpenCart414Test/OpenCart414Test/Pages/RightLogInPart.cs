using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class RightLoginPart : RightMenuPart
    {
        public IWebElement RightMenuEditAccount
        { get { return driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Edit Account']")); } }
        public IWebElement RightMenuPassword
        { get { return driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Password']")); } }
        public IWebElement RightMenuLogout
        { get { return driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Logout']")); } }
        public RightLoginPart(IWebDriver driver) : base(driver)
        {
        }
        public string GetRightMenuEditAccountText()
        {
            return RightMenuEditAccount.Text;
        }
        public void ClickRightMenuEditAccount()
        {
            RightMenuEditAccount.Click();
        }
        public string GetRightMenuPasswordText()
        {
            return RightMenuPassword.Text;
        }
        public void ClickRightMenuPassword()
        {
            RightMenuPassword.Click();
        }
        public string GetRightMenuLogoutText()
        {
            return RightMenuLogout.Text;
        }
        public void ClickRightMenuLogout()
        {
            RightMenuLogout.Click();
        }
    }
}
