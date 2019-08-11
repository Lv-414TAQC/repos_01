using OpenQA.Selenium;

namespace OpenCart414Test.Pages
{
    public class WishListEmptyPage : WishListPart
    {
        public IWebElement WishListIsEmptyParagraph =>
        driver.FindElement(By.XPath("//div[@id='content']/p"));

        public WishListEmptyPage(IWebDriver driver) : base(driver)
        {
        }

        // Atomic
        public string GetWishListIsEmpltyParagraphText()
        {
            return WishListIsEmptyParagraph.Text;
        }
        public bool IsWishListIsEmptyParagraphDisplayed()
        {
            return WishListIsEmptyParagraph.Displayed;
        }
    }
}
