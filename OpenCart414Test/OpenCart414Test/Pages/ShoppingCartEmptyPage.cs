using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    class ShoppingCartEmptyPage : BreadCrumPart
    {
        public ShoppingCartEmptyPage(IWebDriver driver) : base(driver)
        {
        }
        public const string CART_IS_EMPTY = "Your shopping cart is empty!";

        //public IWebElement EmptyListMessage
        //{
        //    get
        //    {
        //        if (GetShoppingCartComponentsCount() > 0)
        //        {
        //            // TODO Develop Custom Exception 
        //            throw new Exception("Message not Found.");
        //}
        //        return driver.FindElement(By.XPath("//div[@id = 'content']/p"));
        //    }
        //}

    }
}
