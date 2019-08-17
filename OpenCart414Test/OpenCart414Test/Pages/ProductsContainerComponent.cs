using OpenCart414Test.Data;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace OpenCart414Test.Pages
{
    public class ProductsContainerComponent
    {
        public const string PRODUCT_NOT_FOUND = "There is no product that matches the search criteria.";
        private const string PRODUCT_COMPONENT_CSSSELECTOR = ".product-layout";

        protected IWebDriver driver;
        //
        public IWebElement EmptyListMessage
        {
            get
            {
                if (GetProductComponentsCount() > 0)
                {
                    // TODO Develop Custom Exception 
                    throw new Exception("Message not Found.");
                }
                return driver.FindElement(By.CssSelector("#button-search + h2 + p"));
            }
        }
        //
        private IList<ProductComponent> productComponents;
      
        public ProductsContainerComponent(IWebDriver driver)
        {
            this.driver = driver;
            InitElements();
        }

        private void InitElements()
        {
            productComponents = new List<ProductComponent>();
            foreach (IWebElement current in driver.FindElements(By.CssSelector(PRODUCT_COMPONENT_CSSSELECTOR)))
            {
                productComponents.Add(new ProductComponent(current));
            }
        }

        // Page Object

        // productComponents
        public IList<ProductComponent> GetProductComponents()
        {
            return productComponents;
        }

        // Functional

        protected bool IsContainTextByDescription(string text)
        {
            foreach (var current in GetProductComponents())
            {
                if (!current.GetPartialDescriptionText().Contains(text))
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsContainTextByDescription(SearchCriteria searchCriteria)
        {
            return IsContainTextByDescription(searchCriteria.SearchValue);
        }
        //
        protected bool IsContainText(string text)
        {
            bool result = true;
            foreach (var current in GetProductComponentNames())
            {
                if (!current.Contains(text))
                {
                    result = false;
                }
            }
            return result;
        }
        public bool IsContainNameText(SearchCriteria searchCriteria)
        {
            return IsContainText(searchCriteria.SearchValue);
        }
        
        public IList<string> GetProductComponentNames()
        {
            IList<string> productComponentNames = new List<string>();
            foreach (ProductComponent current in GetProductComponents())
            {
                productComponentNames.Add(current.GetNameText());
                Console.WriteLine(current.GetNameText()); // For presentation only
            }
            return productComponentNames;
        }

        public IList<string> GetProductComponentPrices()
        {
            IList<string> productComponentPrices = new List<string>();
            foreach (ProductComponent current in GetProductComponents())
            {
                productComponentPrices.Add(current.GetPriceText());
            }
            return productComponentPrices;
        }

        public ProductComponent GetProductComponentByName(string productName)
        {
            ProductComponent result = null;
            foreach (ProductComponent current in GetProductComponents())
            {
                if (current.GetNameText().ToLower()
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

        //___________
       /* public ProductComponent GetProductComponentByName1(Data.Product productName)
        {
            ProductComponent result = null;
            foreach (ProductComponent current in GetProductComponents())
            {
                if (current.GetNameText().ToLower()
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
        //______________________________
        */
        public string GetProductComponentPriceByName(string productName)
        {
            return GetProductComponentByName(productName).GetPriceText();
        }

        public string GetProductComponentDescriptionByName(string productName)
        {
            return GetProductComponentByName(productName).GetPartialDescriptionText();
        }

        public void ClickProductComponentAddToCartButtonByName(String productName)
        {
            GetProductComponentByName(productName).ClickAddToCartButton();
        }

        public void ClickProductComponentAddToWishButtonByName(String productName)
        {
            GetProductComponentByName(productName).ClickAddToWishButton();
        }

        public int GetProductComponentsCount()
        {
            return GetProductComponents().Count;
        }

        public bool IsSortedAscList()
        {
            bool result = true;
            decimal previous = 0;
            CultureInfo culture = new CultureInfo("en-US");
            foreach (string element in GetProductComponentPrices())
            {
                decimal currentPrice = Convert.ToDecimal(Regex.Match(element, @"\d*[.|,]\d*").Value, culture);
                if (currentPrice < previous)
                {
                    result = false;
                }
                previous = currentPrice;
                Console.WriteLine(currentPrice);
            }
            return result;
        }

        public void AddProductToWishList(Product product)
        {
            GetProductComponentByName(product.Title).ClickAddToWishButton();
        }

        // Business Logic

        public string  GetProductComponentDescriptionByProduct(Product product)
        {
            return GetProductComponentDescriptionByName(product.GetName());
        }

    }
}
