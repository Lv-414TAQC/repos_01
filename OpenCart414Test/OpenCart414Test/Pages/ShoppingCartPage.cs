using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart414Test.Data;
using OpenCart414Test.Pages;
using System.Threading;

namespace OpenCart414Test.Pages
{
<<<<<<< HEAD
    public class ShoppingCartPage : BreadCrumPart
=======
    class ShoppingCartPage : BreadCrumbsPart
>>>>>>> 06cc0ee49a793feda83055819c415caada4fd5ad
    {
        private const string SHOPPING_CART_XPATH = "//div[@class = 'table-responsive']/table/tbody";
        private const string TABLE_PRICE_COMPONENT_XPATH = "//div[@class='row']/div/table/tbody";
        //

        public IWebElement ShoppingCartTitle
        { get { return driver.FindElement(By.CssSelector("#content > h1")); } }
        public IWebElement ContinueShoppingButton
        { get { return driver.FindElement(By.CssSelector("button.btn.btn-primary")); } }
        public IWebElement ChecoutButton
        { get { return driver.FindElement(By.CssSelector("a.btn.btn-primary")); } }
        public IWebElement DiscountCode //??????????
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
<<<<<<< HEAD
            shopppingcartComponents = new List<ShoppingCartComponent>();
=======
        //     tablePrice = new TablePriceComponent(driver);

            shopppingcartComponents = new List<ShoppingCartPageComponent>();
>>>>>>> 06cc0ee49a793feda83055819c415caada4fd5ad
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
        //public void EnterVAlidDataQuantity(Product product)
        //{
        //    GetShoppingCartComponentByName(product.Title).SandKeysQuantityField(ShoppingCartData.VALID_CHECK);

        //}
        //public int EnterZeroQuantity(Product product, string data)
        //{
        //    GetShoppingCartComponentByName(product.Title).SandKeysQuantityField(data);
        //    return GetShoppingCartComponentByName(product.Title).GetTextQuantityField();
        //}
        public void ClearQuantity(Product product)
        {
            GetShoppingCartComponentByName(product.Title).ClearQuantityField();

        }
        // Business Logic

        public ShoppingCartMessage UpdateMessage(Product product)
        {
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
    

