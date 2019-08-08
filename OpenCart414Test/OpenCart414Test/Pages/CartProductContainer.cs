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
        private const string TABLE_PRICE_COMPONENT_CSSSELECTOR = "ul.dropdown-menu.pull-right table.table-bordered td.text-right";

        public IWebDriver driver;

        public IWebElement ViewCartLink
        { get { return driver.FindElement(By.XPath("//p[@class='text-right']//strong/i[@class='fa fa-shopping-cart']//..")); } }
        public IWebElement CheckOutLink
        { get { return driver.FindElement(By.XPath("//p[@class='text-right']//strong/i[@class='fa fa-share']//..")); } }
        private TablePriceComponent tablePriceComponent;
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
            temp = CheckOutLink;
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

      

        protected TablePriceComponent GetTablePriceComponent()
        {
            if (tablePriceComponent == null)
            {
                // TODO Develop Custom Exception 
                throw new Exception("TablePriceComponent is null.");
            }
            return tablePriceComponent;
        }

        private TablePriceComponent CreateTablePriceComponent(By searchLocator)
        {
            tablePriceComponent = new TablePriceComponent(driver, searchLocator);
            return GetTablePriceComponent();
        }

        // Functional

        public IList<string> GetAllTablePriceComponents()
        {
            CreateTablePriceComponent(By.CssSelector(TABLE_PRICE_COMPONENT_CSSSELECTOR));

            //Click on Button Shopping cart or in test click ?
            IList<string> result = GetTablePriceComponent().GetTablePriceListText();
            return result;
        }

        // Business Logic


    }
}
