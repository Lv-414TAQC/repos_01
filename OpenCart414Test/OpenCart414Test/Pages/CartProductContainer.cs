using OpenCart414Test.Data;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    class CartProductContainer
    {
        private const string ITEMS_TABLE_CSSSELECTOR = "table.table-striped";

        protected IWebDriver driver;

        public IWebElement ViewCartLink
        { get { return driver.FindElement(By.XPath("//p[@class='text-right']//strong/i[@class='fa fa-shopping-cart']//..")); } }
        public IWebElement CheckOutLink
        { get { return driver.FindElement(By.XPath("//p[@class='text-right']//strong/i[@class='fa fa-share']//..")); } }
        IList<ShoppingCartContainerComponent> itemsTable;

        public CartProductContainer(IWebDriver driver)
        {
            this.driver = driver;
            CheckElements();
            InitElements();
        }

        private void CheckElements()
        {
            // TODO Develop Custom Exception
            IWebElement temp = ViewCartLink; 
            temp = CheckOutLink; // TODO All Web Elements
        }

        private void InitElements()
        {
            itemsTable = new List<ShoppingCartContainerComponent>();
            foreach (IWebElement current in driver.FindElements(By.CssSelector(ITEMS_TABLE_CSSSELECTOR)))
            {
                itemsTable.Add(new ShoppingCartContainerComponent(current));
            }
        }
        // Page Object
        public IList<ShoppingCartContainerComponent> GetItemsTable()
        {
            return itemsTable;
        }

        //ViewCartLink
        public string GetViewCartLinkText()
        {
            return ViewCartLink.Text;
        }

        public void ClickViewCartLink()
        {
            ViewCartLink.Click();
        }

        //CheckOutLink
        public string GetCheckOutLinkText()
        {
            return CheckOutLink.Text;
        }

        public void ClickCheckOutLink()
        {
            CheckOutLink.Click();
        }

        // Functional

        // Business Logic
       

    }
}
