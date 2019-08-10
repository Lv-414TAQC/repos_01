using OpenCart414Test.Data;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OpenCart414Test.Pages
{
     class CartProductContainer
    {
        private const string ITEMS_TABLE_CSSSELECTOR = "table.table-striped tr";
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
            IList<string> result = GetTablePriceComponent().GetTablePriceListText();
            return result;
        }

        public string GetTablePriceTotal()
        {
            CreateTablePriceComponent(By.CssSelector(TABLE_PRICE_COMPONENT_CSSSELECTOR));
            string result = GetTablePriceComponent().GetTotal();
            Console.WriteLine(result);
            return result;
        }


        public void RemoveProductByName(Product product)
         {
            foreach (ShoppingCartContainerComponent cur in GetItemsTable())
            {
                 if (cur.GetProductNameText() == product.Title)
                 {
                    cur.ClickProductRemoveButton();
                    break;
                 }
            }
         }

        public ShoppingCartContainerComponent GetItemByName(Product product)
        {
            foreach (ShoppingCartContainerComponent currency in GetItemsTable())
            {
                if (currency.GetProductNameText() == product.Title)
                {
                    Console.WriteLine(currency.GetProductNameText());
                    return currency;
                }
            }
            return null;
        }

        public double GetTotalSumProducts()
        {
            double totalSum = 0.0;
            string toStringVar = string.Empty;
            foreach (ShoppingCartContainerComponent cur in GetItemsTable())
            {
                Regex regex = new Regex(@"\d*[.|,]\d*");  //class in tools
                MatchCollection matches = regex.Matches(cur.GetProductPriceText());

                foreach (Match match in matches)
                {
                   // Console.WriteLine(match.Value);
                    toStringVar = Convert.ToString(match.Value);
                }

                totalSum += double.Parse(toStringVar, System.Globalization.CultureInfo.InvariantCulture);
            }
            Console.WriteLine(totalSum); //Only for presentation
            return totalSum;

        }

            // Business Logic


        }
    }
