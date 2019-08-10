using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class ShoppingCartEmptyPage : BreadCrumPart
    {
        
        public const string CART_IS_EMPTY = "Your shopping cart is empty!";
        public IWebElement CartEmptyMessage
        { get { return driver.FindElement(By.XPath("//div[@id = 'content']/p")); } }

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

        // InfoMessage
        public string GetInfoMessageText()
        {
            return CartEmptyMessage.Text;
        }

    }
}
