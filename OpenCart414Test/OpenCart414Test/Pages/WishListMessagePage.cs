using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class WishListMessagePage : WishListPage
    {
        public IWebElement WishListAlertMessage
        { get { return driver.FindElement(By.CssSelector(".alert.alert-success")); } }
        public WishListMessagePage(IWebDriver driver) : base(driver)
        {
        }
        public string GetWishListAlertMessageText()
        {
            return WishListAlertMessage.Text;
        }
        public bool IsWishListAlertMessageDisplayed()
        {
            return WishListAlertMessage.Displayed;
        }
        public void ClickCloseWishListAlertMessage()
        {
            WishListAlertMessage.FindElement(By.CssSelector(".close")).Click();
        }
    }
}
