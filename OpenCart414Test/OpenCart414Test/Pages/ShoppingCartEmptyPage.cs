using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{

    public class ShoppingCartEmptyPage : BreadCrumbsPart
        
    {
        
        public const string CART_IS_EMPTY = "Your shopping cart is empty!";

        public IWebElement CartEmptyMessage
        { get { return driver.FindElement(By.XPath("//div[@id = 'content']/p")); } }
        public IWebElement Continue
        { get { return driver.FindElement(By.LinkText("Continue")); } }
        
        public ShoppingCartEmptyPage(IWebDriver driver) : base(driver)
        {
            CheckElements();
        }

        private void CheckElements()
        {
            // TODO Develop Custom Exception
            IWebElement temp = CartEmptyMessage; 
        }

        // Page Object
        public void ContinueClick()
        {
            Continue.Click();
        }
        // Function
        public string GetInfoMessageText()
        {
            return CartEmptyMessage.Text;
        }
        public bool Equal()
        {
            if (GetInfoMessageText() == CART_IS_EMPTY)
                return true;
            else
                return false;
        }
        //Business Logic
        public HomePage GoToHomePage()
        {
            ContinueClick();
            return new HomePage(driver);
        }

    }
}
