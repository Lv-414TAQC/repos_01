using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class SuccessfullyRegisterPage : RightMenuPart
    {
        public readonly string Expected_Success_Message = "Your Account Has Been Created!";

        public IWebElement ContinueButton
        { get { return driver.FindElement(By.CssSelector("a.btn.btn-primary")); } }
        public IWebElement LogOutButton
        { get { return driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Logout']")); } }
        public IWebElement SuccessMessage
        { get { return driver.FindElement(By.CssSelector("div[id='content'] > h1")); } }



        public SuccessfullyRegisterPage(IWebDriver driver) : base(driver)
        {


        }

        public void ClickContinueButton()
        {
            ContinueButton.Click();
        }

        public void ClickLogOutButton()
        {
            LogOutButton.Click();
        }

        public AccountLogoutPage LogOut()
        {
            ClickLogOutButton();
            return new AccountLogoutPage(driver);
        }
        public AccountLogoutPage ContinueAccountRegisterPage()
        {
            ClickContinueButton();
            return new AccountLogoutPage(driver);
        }

        public IWebElement GetSuccessMessage()
        {
            return SuccessMessage;
        }

        public string GetExpectedSuccessMessage()
        {
            return GetSuccessMessage().Text;
        }

    }
}
