using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class WishListPart : RightLoginPart
    {
        public IWebElement WishListTitle
        { get { return driver.FindElement(By.XPath("//div[@id='content']/h2")); } }
        public IWebElement ContinueButton
        { get { return driver.FindElement(By.XPath("//div[@class='buttons clearfix']//a[@class='btn btn-primary']")); } }
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
