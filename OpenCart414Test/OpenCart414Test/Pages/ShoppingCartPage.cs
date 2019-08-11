using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart414Test.Data;
using OpenCart414Test.Pages;
using System.Threading;
using OpenCart414Test.Tools;

namespace OpenCart414Test.Pages
{

    public class ShoppingCartPage : BreadCrumbsPart

    {
        private const string SHOPPING_CART_XPATH = "//div[@class = 'table-responsive']/table/tbody";
        private const string TABLE_PRICE_COMPONENT_XPATH = "//div[@class='row']/div/table/tbody/tr/td";
        //

        public IWebElement ShoppingCartTitle
        { get { return driver.FindElement(By.CssSelector("#content > h1")); } }
        public IWebElement ContinueShoppingButton
        { get { return driver.FindElement(By.CssSelector("button.btn.btn-primary")); } }
        public IWebElement ChecoutButton
        { get { return driver.FindElement(By.CssSelector("a.btn.btn-primary")); } }
        public IWebElement DiscountCode 
        { get { return driver.FindElement(By.Id("accordion")); } }

        public IList<ShoppingCartComponent> shopppingcartComponents;
        public TablePriceComponent tablePrice;

        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
            InitElements();
            CheckElements();
        }


        private void InitElements()
        {

            shopppingcartComponents = new List<ShoppingCartComponent>();

            foreach (IWebElement current in driver.FindElements(By.XPath(SHOPPING_CART_XPATH)))
            {
                shopppingcartComponents.Add(new ShoppingCartComponent(current));
            }
        }

        private void CheckElements()
        {
            // TODO Develop Custom Exception
            IWebElement temp = ContinueShoppingButton;
            temp = ChecoutButton;
            temp = ShoppingCartTitle;
        }


        //Page Object
        public IList<ShoppingCartComponent> GetShoppingCartComponents()
        {
            return shopppingcartComponents;
        }

        public int GetShoppingCartComponentsCount()
        {
            return GetShoppingCartComponents().Count;
        }
        public string GetShoppingCartTitleText()
        {
            return ShoppingCartTitle.Text.Substring(0, 13);
        }
        public string GetContinueShoppingText()
        {
            return ContinueShoppingButton.Text;
        }
        public void ClickContinueShopping()
        {
            ContinueShoppingButton.Click();
        }
        public string GetCheoutText()
        {
            return ChecoutButton.Text;
        }
        public void ClickCheckout()
        {
            ChecoutButton.Click();
        }

        // Functional

        public IList<string> GetAllTablePriceComponents()
        {
            CreateTablePriceComponent(By.XPath(TABLE_PRICE_COMPONENT_XPATH));
            return GetTablePriceComponent().GetTablePriceListText();

        }

        public ShoppingCartComponent GetShoppingCartComponentByName(string productName)
        {
            ShoppingCartComponent result = null;
            foreach (ShoppingCartComponent current in shopppingcartComponents)
            {
                if (current.GetProductName().ToLower()
                        .Equals(productName.ToLower()))
                {
                    result = current;
                    break;
                }
            }
            if (result == null)
            {
                throw new Exception("ProductName: " + productName + " not Found.");
            }
            return result;
        }
        public RegularExpressions GetRegularExpressions()
        {
            return new RegularExpressions();
        }
        public decimal GetTablePriceTotal()
        {
            CreateTablePriceComponent(By.XPath(TABLE_PRICE_COMPONENT_XPATH));
            Console.WriteLine(GetRegularExpressions().RegexCurrency(GetTablePriceComponent().GetTotal())); //Only for presentation
            return GetRegularExpressions().RegexCurrency(GetTablePriceComponent().GetTotal());
        }


        protected TablePriceComponent GetTablePriceComponent()
        {
            if (tablePrice == null)
            {
                // TODO Develop Custom Exception 
                throw new Exception("TablePriceComponent is null.");
            }
            return tablePrice;
        }

        private TablePriceComponent CreateTablePriceComponent(By searchLocator)
        {
            tablePrice = new TablePriceComponent(driver, searchLocator);
            return GetTablePriceComponent();
        }
        //public string EnterData(Product product, string data)
        //{
        //    GetShoppingCartComponentByName(product.Title).GetUnitPrice();
        //    return GetShoppingCartComponentByName(product.Title).GetTextQuantityFieldString();

        //}
        public string EnterData(Product product, string data)
        {
            GetShoppingCartComponentByName(product.Title).SandKeysQuantityField(data);
            return GetShoppingCartComponentByName(product.Title).GetTextQuantityFieldString();

        }
        public int EnterDataForSum(Product product, string data)
        {
            GetShoppingCartComponentByName(product.Title).SandKeysQuantityField(data);
            return GetShoppingCartComponentByName(product.Title).GetTextQuantityField();
        }
        public ShoppingCartEmptyPage ClearQuantity(Product product)
        {
            GetShoppingCartComponentByName(product.Title).ClearQuantityField();
            return NotUpdateMessage(product, GetShoppingCartComponentByName(product.Title).GetTextQuantityFieldString());

        }
        // Business Logic

        public ShoppingCartMessage UpdateMessage(Product product, string data)
        {
            EnterData(product, data);
            GetShoppingCartComponentByName(product.Title).ClickUpdateButton();
            return new ShoppingCartMessage(driver);
        }

        public ShoppingCartEmptyPage NotUpdateMessage(Product invalidProduct, string data)
        {
            ShoppingCartComponent shoppingCartComponent = GetShoppingCartComponentByName(invalidProduct.Title);
            shoppingCartComponent.SandKeysQuantityField(data);
            shoppingCartComponent.ClickUpdateButton();
            
            return new ShoppingCartEmptyPage(driver);
        }

        public ShoppingCartEmptyPage GoToEmptyPage(Product product)
        {
            GetShoppingCartComponentByName(product.Title).ClickRemoveButton();
            return new ShoppingCartEmptyPage(driver);
        }

    }
}
    

