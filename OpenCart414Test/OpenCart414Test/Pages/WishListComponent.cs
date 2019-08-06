using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    class WishListComponent
    {
        protected IWebDriver driver;

        public IWebElement WishListComponentImage;
        public IWebElement WishListComponentProductName;
        public IWebElement WishListComponentModel;
        public IWebElement WishListComponentStock;
        public IWebElement WishListComponentUnitPrice;
        public IWebElement WishListComponentAddToCartButton;
        public IWebElement WishListComponentRemoveButton;
        
        public ??? GetWishListComponentImage()
        {

        }
        public void ClickWishListComponentImage()
        {
            WishListComponentImage.Click();
        }
        public string GetWishListComponentProductNameText()
        {
            return WishListComponentProductName.Text;
        }
        public void ClickWishListComponentProductName()
        {
            WishListComponentProductName.Click();
        }
        public string GetWishListComponentModelText()
        {
            return WishListComponentModel.Text;
        }
        public string GetWishListComponentStockText()
        {
            return WishListComponentStock.Text;
        }
        public string GetWishListComponentUnitPriceText()
        {
            return WishListComponentUnitPrice.Text;
        }
        public void ClickWishListComponentAddToCartButton()
        {
            WishListComponentAddToCartButton.Click();
        }
        public void ClickWishListComponentRemoveButton()
        {
            WishListComponentRemoveButton.Click();
        }
    }
}
