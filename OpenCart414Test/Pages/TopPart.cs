using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class TopPart
    {
        protected const string TAG_ATTRIBUTE_VALUE = "value";
        protected const string TAG_ATTRIBUTE_SRC = "src";
        //
        protected IWebDriver driver;
        //
        public IWebElement Currency
        { get { return driver.FindElement(By.CssSelector(".btn.btn-link.dropdown-toggle")); } }
        public IWebElement MyAccount
        { get { return driver.FindElement(By.CssSelector(".list - inline > li > a.dropdown - toggle")); } }
        public IWebElement WishList
        { get { return driver.FindElement(By.Id("wishlist-total")); } }
        public IWebElement ShoppingCart
        { get { return driver.FindElement(By.CssSelector("a[title='Shopping Cart']")); } }
        public IWebElement Checkout
        { get { return driver.FindElement(By.CssSelector("a[title='Checkout']")); } }
        public IWebElement Logo
        { get { return driver.FindElement(By.CssSelector("#logo img")); } }
        public IWebElement SearchField
        { get { return driver.FindElement(By.Name("search")); } }
        public IWebElement SearchButton
        { get { return driver.FindElement(By.CssSelector(".btn.btn-default.btn-lg")); } }
        public IWebElement CartButton
        { get { return driver.FindElement(By.CssSelector("#cart > button")); } }
        //
        public IList<IWebElement> TopMenu;  // TODO

        public TopPart(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}
