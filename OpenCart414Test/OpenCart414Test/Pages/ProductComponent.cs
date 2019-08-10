using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class ProductComponent
    {
        private IWebElement productLayout;
        //
        public IWebElement Name
        { get { return productLayout.FindElement(By.CssSelector("h4 a")); } }
        public IWebElement PartialDescription
        { get { return productLayout.FindElement(By.CssSelector("h4 + p")); } }
        public IWebElement Price
        { get { return productLayout.FindElement(By.CssSelector(".price")); } }
        public IWebElement AddToCartButton
        { get { return productLayout.FindElement(By.CssSelector(".fa.fa-shopping-cart")); } }
        public IWebElement AddToWishButton
        { get { return productLayout.FindElement(By.CssSelector(".fa.fa-heart")); } }
        public IWebElement AddToCompareButton
        { get { return productLayout.FindElement(By.CssSelector(".fa.fa-exchange")); } }
        Dictionary<string, decimal> prices;

        public ProductComponent(IWebElement productLayout)
        {
            this.productLayout = productLayout;
            CheckElements();
        }

        private void CheckElements()
        {
            // TODO Develop Custom Exception
            IWebElement temp = Name; // TODO All Web Elements
        }

        // Page Object

        //Name
        public string GetNameText()
        {
            return Name.Text;
        }

        public void ClickName()
        {
            Name.Click();
        }

        //PartialDescription
        public string GetPartialDescriptionText()
        {
            return PartialDescription.Text;
        }

        //Price
        public string GetPriceText()
        {
            return Price.Text;
        }

        //AddToCartButton
        public string GetAddToCartButtonText()
        {
            return AddToCartButton.Text;
        }

        public void ClickAddToCartButton()
        {
            AddToCartButton.Click();
        }

        //AddToWishButton
        public void ClickAddToWishButton()
        {
            AddToWishButton.Click();
        }

        //AddToCompareButton
        public void ClickAddToCompareButton()
        {
            AddToCompareButton.Click();
        }

        // Functional

        // Business Logic
        public void AddItemToWishList()
        {
            ClickAddToWishButton();
        }

        public string GetNewPrice()
        {
            string newPrice = Price.FindElement(By.CssSelector("span[class='price-new']")).Text;
            return newPrice;
        }

        public string GetOldPrice()
        {
            string oldPrice = Price.FindElement(By.CssSelector("span[class='price-old']")).Text;
            return oldPrice;
        }

        public string GetExTax()
        {
            string exTax = Regex.Match( Price.FindElement(By.CssSelector("span[class='price-tax']")).Text, @"[\$£]?\d+\.\d{2}\€?").Value;

            return exTax;
        }
    }
}
