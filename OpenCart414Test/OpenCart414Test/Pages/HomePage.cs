using OpenCart414Test.Data;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OpenCart414Test.Pages
{
    public class HomePage : TopPart
    {
        public const string IPHONE6 = "iPhone6";
        public const string ZERO_PRODUCT = "0 item(s)";
        public const string ONE_PRODUCT = "1 item(s)";
        public const string TWO_PRODUCT = "2 item(s)";
        //
        public IWebElement Slideshow0
        { get { return driver.FindElement(By.Id("slideshow0")); } }

        private ProductsContainerComponent productsContainerComponent;

        public HomePage(IWebDriver driver) : base(driver)
        {
            productsContainerComponent = new ProductsContainerComponent(driver);
        }

        // Page Object

        // Slideshow0
        public IWebElement GetSlideshow0FirstImage()
        {
            //return Slideshow0.FindElement(By.CssSelector("a > img"));
            return Slideshow0.FindElement(By.XPath(".//a/img"));
            //return Slideshow0.FindElement(By.XPath("//a/img")); // ERROR
            //return driver.FindElement(By.XPath("//div[@id='slideshow0']//a/img"));
        }

        public string GetSlideshow0FirstImageAttributeText(string attribute)
        {
            return GetSlideshow0FirstImage().GetAttribute(attribute).Trim();
        }

        public string GetSlideshow0FirstImageAttributeSrcText()
        {
            return GetSlideshow0FirstImageAttributeText(TAG_ATTRIBUTE_SRC);
        }

        // productComponentsContainer
        public ProductsContainerComponent getProductComponentsContainer()
        {
            return productsContainerComponent;
        }

        // Functional
        public string GetProductOldPrice(Product product)
        {
            ProductComponent searchedProduct =  productsContainerComponent.GetProductComponentByName(product.Title);
            return searchedProduct.GetOldPrice();
        }

        public string GetProductNewPrice(Product product)
        {
            ProductComponent searchedProduct = productsContainerComponent.GetProductComponentByName(product.Title);
            return searchedProduct.GetNewPrice();
        }

        public string GetProductExTax(Product product)
        {
            ProductComponent searchedProduct = productsContainerComponent.GetProductComponentByName(product.Title);
            return searchedProduct.GetExTax();
        }

        public decimal GetProductNewPriceValue(Product product)
        {
            string newPrice = Regex.Match(GetProductNewPrice(product), @"\d+\.\d{2}").Value;
            NumberStyles style = NumberStyles.AllowDecimalPoint;
            CultureInfo provider = new CultureInfo("en-US");
            decimal value = Decimal.Parse(newPrice, style, provider);
            return value;

        }

        public decimal GetProductOldPriceValue(Product product)
        {
            string oldPrice = Regex.Match(GetProductOldPrice(product), @"\d+\.\d{2}").Value;
            NumberStyles style = NumberStyles.AllowDecimalPoint;
            CultureInfo provider = new CultureInfo("en-US");
            decimal value = Decimal.Parse(oldPrice, style, provider);
            return value;

        }

        public decimal GetProductExTaxValue(Product product)
        {
            string exTax = Regex.Match(GetProductExTax(product), @"\d+\.\d{2}").Value;
            NumberStyles style = NumberStyles.AllowDecimalPoint;
            CultureInfo provider = new CultureInfo("en-US");
            decimal value = Decimal.Parse(exTax, style, provider);
            return value;

        }

        // Business Logic
        public HomePage ChooseCurrency(Currency currency)
        {
            ClickCurrencyByPartialName(currency);
            return new HomePage(driver);
        }
        public SearchUnsuccessPage GetUnsuccessPage()
        {
            ClickSearchButton();
            return new SearchUnsuccessPage(driver);
        }


        //internal CartContainerComponent GetCartContainerComponent()
        //{
        //    ClickCartButton();
        //    return new CartContainerComponent(driver);
        //}

        //internal CartEmptyContainerComponent GetCartEmptyContainerComponent()
        //{
        //    ClickCartButton();
        //    return new CartEmptyContainerComponent(driver);
        //}

        public void AddProductToCart(Product product)
        {
            productsContainerComponent.GetProductComponentByName(product.Title)
                .ClickAddToCartButton();
        }

        
       
    }
}
