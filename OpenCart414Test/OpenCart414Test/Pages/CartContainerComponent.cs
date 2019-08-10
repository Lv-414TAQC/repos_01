using OpenCart414Test.Data;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using OpenCart414Test.Tools;

namespace OpenCart414Test.Pages
{
    public class CartContainerComponent
    {
        private const string PRODUCT_LIST_CSSSELECTOR = "table.table-striped tr";
        private const string TABLE_PRICE_COMPONENT_CSSSELECTOR = "ul.dropdown-menu.pull-right table.table-bordered td.text-right";

        public IWebDriver driver;

        public IWebElement ViewCartLink
        { get { return driver.FindElement(By.XPath("//p[@class='text-right']//strong/i[@class='fa fa-shopping-cart']//..")); } }
        public IWebElement CheckOutLink
        { get { return driver.FindElement(By.XPath("//p[@class='text-right']//strong/i[@class='fa fa-share']//..")); } }
        private TablePriceComponent tablePriceComponent;
        IList<ProductListContainerComponent> productList;

          public CartContainerComponent(IWebDriver driver)
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
            productList = new List<ProductListContainerComponent>();
            foreach (IWebElement current in driver.FindElements(By.CssSelector(PRODUCT_LIST_CSSSELECTOR)))
            {
                productList.Add(new ProductListContainerComponent(current));
            }
        }

        // Page Object
        internal IList<ProductListContainerComponent> GetProductList()
        {
            return productList;
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

        //tablePriceComponent
        protected TablePriceComponent GetTablePriceComponent()
        {
            if (tablePriceComponent == null)
            {
                throw new Exception("TablePriceComponent is null.");
            }
            return tablePriceComponent;
        }

        private TablePriceComponent CreateTablePriceComponent(By searchLocator)
        {
            tablePriceComponent = new TablePriceComponent(driver, searchLocator);
            return GetTablePriceComponent();
        }


        public RegularExpressions GetRegularExpressions()
        {
            return new RegularExpressions();
        }

            // Functional

        public IList<string> GetAllTablePriceComponents()
        {
            CreateTablePriceComponent(By.CssSelector(TABLE_PRICE_COMPONENT_CSSSELECTOR));
            IList<string> result = GetTablePriceComponent().GetTablePriceListText();
            return result;
        }

        public decimal GetTablePriceTotal()
        {
            CreateTablePriceComponent(By.CssSelector(TABLE_PRICE_COMPONENT_CSSSELECTOR));
            Console.WriteLine(GetRegularExpressions().RegexCurrency(GetTablePriceComponent().GetTotal())); //Only for presentation
            return GetRegularExpressions().RegexCurrency(GetTablePriceComponent().GetTotal());
        }

        public void RemoveProductByName(Product product)
        {
            foreach (ProductListContainerComponent cur in GetProductList())
            {
                 if (cur.GetProductNameText() == product.Title)
                 {
                    cur.ClickProductRemoveButton();
                    break;
                 }
            }
         
        }

        internal ProductListContainerComponent GetProductByName(Product product)
        {
            foreach (ProductListContainerComponent currency in GetProductList())
            {
                if (currency.GetProductNameText() == product.Title)
                {
                    Console.WriteLine(currency.GetProductNameText());
                    return currency;
                }
            }
            return null;
        }

        public decimal GetTotalSumProducts()
        {
            decimal total = 0;
            foreach (ProductListContainerComponent cur in GetProductList())
            {
               total += GetRegularExpressions().RegexCurrency(cur.GetProductPriceText());
            }
            Console.WriteLine(total); //Only for presentation
            
            return total;
        }

        // Business Logic

     }
}
