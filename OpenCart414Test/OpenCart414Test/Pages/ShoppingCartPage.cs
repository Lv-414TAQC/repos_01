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
        private const string TABLE_PRICE_COMPONENT_XPATH= "//div[@class='row']/div/table/tbody";
        //
        
        public IWebElement ContinueShoppingButton
        { get { return driver.FindElement(By.CssSelector("button.btn.btn-primary")); } }
        public IWebElement ChecoutButton
        { get { return driver.FindElement(By.CssSelector("a.btn.btn-primary")); } }
        public IWebElement DiscountCode
        { get { return driver.FindElement(By.Id("accordion")); } }
        private TablePriceComponent tablePrice;
        private void InitElements()
        {
            tablePrice = new TablePriceComponent(driver);
            shopppingcartComponents = new List<ShoppingCartPageComponent>();
            foreach (IWebElement current in shopppingcartComponents)
            {
                shopppingcartComponents.Add(new ShoppingCartPageComponent());
            }
        }
        private IList<ShoppingCartPageComponent> shopppingcartComponents;
        public IList<ShoppingCartPageComponent> GetShoppingCartComponents()
        {
            return shopppingcartComponents;
        }
       

        private void CheckElements()
        {
            // TODO Develop Custom Exception
            IWebElement temp = ContinueShoppingButton;
            temp = ChecoutButton;

        }

        
        //Page Object


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
        //Functional
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
                // TODO Develop Custom Exception
                throw new Exception("ProductName: " + productName + " not Found.");
            }
            return result;
        }
        
    }
}
