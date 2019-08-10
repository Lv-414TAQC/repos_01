using OpenQA.Selenium;

namespace OpenCart414Test.Pages
{
    public class WishListMessagePage : WishListPage
    {
        public IWebElement WishListAlertMessage =>
        driver.FindElement(By.CssSelector(".alert.alert-success"));

        public WishListMessagePage(IWebDriver driver) : base(driver)
        {
        }

        // Atomic
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
