using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class WishListComponent
    {
        private IWebElement wishListComponentLayout;
        
        public IWebElement WishListComponentImage
        { get { return wishListComponentLayout.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td[@class='text-center']/a/img/..")); } }
        public IWebElement WishListComponentProductName
        { get { return wishListComponentLayout.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td[@class='text-left']/a")); } }
        public IWebElement WishListComponentModel
        { get { return WishListComponentProductName.FindElement(By.XPath("//../following-sibling::td[@class='text-left']")); } }
        public IWebElement WishListComponentStock
        { get { return wishListComponentLayout.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td[@class='text-right']")); } }
        public IWebElement WishListComponentUnitPrice
        { get { return wishListComponentLayout.FindElement(By.CssSelector(".price")); } }
        public IWebElement WishListComponentAddToCartButton
        { get { return wishListComponentLayout.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td[@class='text-right']/button[@class='btn btn-primary']")); } }
        public IWebElement WishListComponentRemoveButton
        { get { return wishListComponentLayout.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td[@class='text-right']/button[@class='btn btn-danger']")); } }

        public WishListComponent(IWebElement wishListComponentLayout)
        {
            this.wishListComponentLayout = wishListComponentLayout;
            //CheckElements();
        }

        //public string GetWishListComponentImage()
        //{
        //    return WishListComponentImage.FindElement(By.XPath(".//")); ;
        //}
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
