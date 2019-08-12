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
       

        public IWebElement ShoppingCartTitle =>
        driver.FindElement(By.CssSelector("#content > h1")); 
        public IWebElement ContinueShoppingButton =>
        driver.FindElement(By.CssSelector("button.btn.btn-primary")); 
        public IWebElement ChecoutButton =>
        driver.FindElement(By.CssSelector("a.btn.btn-primary")); 
        public IWebElement DiscountCode =>
        driver.FindElement(By.Id("accordion")); 
        ShippingAndTaxesComponent shippingAndTaxesDetails;


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
        public string GetChecoutText()
        {
            return ChecoutButton.Text;
        }
        public void ClickCheckoutSc()
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
            return GetRegularExpressions().ConvertStringCurrency(GetTablePriceComponent().GetTotalForPageSC());

        }
        public decimal GetTablePriceSubTotal()
        {
            CreateTablePriceComponent(By.XPath(TABLE_PRICE_COMPONENT_XPATH));
            return GetRegularExpressions().ConvertStringCurrency(GetTablePriceComponent().GetSubTotal());

        }
        public decimal GetTablePriceEcoTax()
        {
            CreateTablePriceComponent(By.XPath(TABLE_PRICE_COMPONENT_XPATH));
            return GetRegularExpressions().ConvertStringCurrency(GetTablePriceComponent().GetEcoTax());

        }
        public decimal GetTablePriceVat()
        {
            CreateTablePriceComponent(By.XPath(TABLE_PRICE_COMPONENT_XPATH));
            return GetRegularExpressions().ConvertStringCurrency(GetTablePriceComponent().GetVat());

        }

        protected TablePriceComponent GetTablePriceComponent()
        {
            if (tablePrice == null)
            {
                throw new Exception("TablePriceComponent is null.");
            }
            return tablePrice;
        }

        protected TablePriceComponent CreateTablePriceComponent(By searchLocator)
        {
            tablePrice = new TablePriceComponent(driver, searchLocator);
            return GetTablePriceComponent();
        }

        public decimal UnitPrice(Product product)
        {
            return GetShoppingCartComponentByName(product.Title).GetUnitPrice();
        }
        public decimal TotalPrice(Product product)
        {
            return GetShoppingCartComponentByName(product.Title).GetTotal();
        }
       
        public string GetData(Product product)
        {
            return GetShoppingCartComponentByName(product.Title).GetTextQuantityField();
        }
        public int GetIntData(Product product)
        {
            return Convert.ToInt32(GetShoppingCartComponentByName(product.Title).GetTextQuantityField());
        }

        public string EnterData(Product product, string data)
        {
            GetShoppingCartComponentByName(product.Title).SandKeysQuantityField(data);
            return GetShoppingCartComponentByName(product.Title).GetTextQuantityField();
        }
        public ShoppingCartEmptyPage ClearQuantity(Product product)
        {
            GetShoppingCartComponentByName(product.Title).ClearQuantityField();
            return NotUpdateMessage(product, GetShoppingCartComponentByName(product.Title).GetTextQuantityField());

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

        public  SelectShippingMethodComponent ApplySippingAndTaxes(ShippingDetails details)
        {
            shippingAndTaxesDetails = new ShippingAndTaxesComponent(driver);
            return shippingAndTaxesDetails.ApplyShippingDetails(details);
        }
    }
}
    

