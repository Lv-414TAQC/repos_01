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
        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            CheckElements();
            InitElements();
        }
        private const string SHOPPING_CART_XPATH = "//div[@class = 'table-responsive']/table/tbody";
        private const string TABLE_PRICE_COMPONENT_XPATH= "//div[@class='row']/div/table/tbody";
        //


        public IWebElement ContinueShoppingButton
        { get { return driver.FindElement(By.CssSelector("button.btn.btn-primary")); } }
        public IWebElement ChecoutButton
        { get { return driver.FindElement(By.CssSelector("a.btn.btn-primary")); } }
        public IWebElement DiscountCode //??????????
        { get { return driver.FindElement(By.Id("accordion")); } }
        private IList<ShoppingCartPageComponent> shopppingcartComponents;
        private TablePriceComponent tablePrice;
        
        private void InitElements()
        {
        //     tablePrice = new TablePriceComponent(driver);

            shopppingcartComponents = new List<ShoppingCartPageComponent>();
            foreach (IWebElement current in driver.FindElements(By.XPath(SHOPPING_CART_XPATH)))
            {
                shopppingcartComponents.Add(new ShoppingCartPageComponent(current));
            }
        }
        
       
        private void CheckElements()
        {
            // TODO Develop Custom Exception
            IWebElement temp = ContinueShoppingButton;
            temp = ChecoutButton;

        }


        //Page Object
        public IList<ShoppingCartPageComponent> GetShoppingCartComponents()
        {
            return shopppingcartComponents;
        }

        public int GetShoppingCartComponentsCount()
        {
            return GetShoppingCartComponents().Count;
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
            CreateTablePriceComponent(By.CssSelector(TABLE_PRICE_COMPONENT_XPATH));
            IList<string> result = GetTablePriceComponent().GetTablePriceListText();
            return result;
        }

        public ShoppingCartPageComponent GetShoppingCartComponentByName(string productName)
        {
            ShoppingCartPageComponent result = null;
            foreach (ShoppingCartPageComponent current in shopppingcartComponents)
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

        // Business Logic


    }
}
    

