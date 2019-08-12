using OpenQA.Selenium;

namespace OpenCart414Test.Pages
{
    public class WishListPart : RightLoginPart
    {
        public IWebElement WishListTitle =>
        driver.FindElement(By.XPath("//div[@id='content']/h2"));
        public IWebElement ContinueButton =>
        driver.FindElement(By.XPath("//div[@class='buttons clearfix']//a[@class='btn btn-primary']"));

        public WishListPart(IWebDriver driver) : base(driver)
        {
        }

        public string GetWishListTitleText()
        {
            return WishListTitle.Text;
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
