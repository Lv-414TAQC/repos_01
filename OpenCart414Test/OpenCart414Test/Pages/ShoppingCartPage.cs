using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    class ShoppingCartPage : BreadCrumPart
    {
        public const string CART_IS_EMPTY = "Your shopping cart is empty!";

        public IWebElement ContinueShoppingButton
        { get { return driver.FindElement(By.CssSelector("button.btn.btn-primary")); } }
        public IWebElement ChecoutButton
        { get { return driver.FindElement(By.CssSelector("a.btn.btn-primary")); } }
        public IWebElement DiscountCode
        { get { return driver.FindElement(By.Id("accordion")); } }

        private IList<ShoppingCartPageComponent> shopppingcartComponents;
        public IList<ShoppingCartPageComponent> GetShoppingCartComponents()
        {
            return shopppingcartComponents;
        }
        public IWebElement EmptyListMessage
        {
            get
            {
                if (GetShoppingCartComponentsCount() > 0)
                {
                    // TODO Develop Custom Exception 
                    throw new Exception("Message not Found.");
                }
                return driver.FindElement(By.XPath("//div[@id = 'content']/p"));
            }
        }

        public int GetShoppingCartComponentsCount()
        {
            return GetShoppingCartComponents().Count;
        }

        public void ClickContinueShopping()
        {
            ContinueShoppingButton.Click();
        }
        public void ClickCheckout()
        {
            ChecoutButton.Click();
        }

    }
}
