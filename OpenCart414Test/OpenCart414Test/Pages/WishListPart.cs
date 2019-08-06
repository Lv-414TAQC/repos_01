using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    class WishListPart : RightLogInPart
    {
        public IWebElement WishListTitle
        { get { return driver.FindElement(By.XPath("//div[@id='content']/h2")); } }
        public IWebElement WishListAlertMessage
        { get { return driver.FindElement(By.CssSelector(".alert.alert-success")); } }
        public IWebElement ContinueButton
        { get { return driver.FindElement(By.CssSelector(".btn.btn-primary")); } }
        public WishListPart(IWebDriver driver) : base(driver)
        {
        }
        public string GetWishListTitleText()
        {
            return WishListTitle.Text;
        }
        public string GetWishListAlertMessageText()
        {
            return WishListAlertMessage.Text;
        }
        public void ClickCloseWishListAlertMessage()
        {
            WishListAlertMessage.FindElement(By.CssSelector(".close")).Click();
        }
        public string GetContinueButtonText()
        {
            return ContinueButton.Text;
        }
        public void ClickContinueButton()
        {
            ContinueButton.Click();
        }
    }
}
