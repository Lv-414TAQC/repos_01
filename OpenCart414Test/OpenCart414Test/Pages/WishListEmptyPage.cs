using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class WishListEmptyPage : WishListPart
    {
        public IWebElement WishListIsEmptyParagraph
        { get { return driver.FindElement(By.XPath("//div[@id='content']/p")); } }
        public WishListEmptyPage(IWebDriver driver) : base(driver)
        {
        }
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
