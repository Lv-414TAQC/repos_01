using OpenQA.Selenium;

namespace OpenCart414Test.Pages
{
    public class WishListComponent
    {
        private IWebElement wishListComponentLayout;
        
        public IWebElement WishListComponentImage =>
        wishListComponentLayout.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td[@class='text-center']/a/img/.."));
        public IWebElement WishListComponentProductName =>
        wishListComponentLayout.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td[@class='text-left']/a"));
        public IWebElement WishListComponentModel =>
        WishListComponentProductName.FindElement(By.XPath("//../following-sibling::td[@class='text-left']"));
        public IWebElement WishListComponentStock =>
        wishListComponentLayout.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td[@class='text-right']"));
        public IWebElement WishListComponentUnitPrice =>
        wishListComponentLayout.FindElement(By.CssSelector(".price"));
        public IWebElement WishListComponentAddToCartButton =>
        wishListComponentLayout.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td[@class='text-right']/button[@class='btn btn-primary']"));
        public IWebElement WishListComponentRemoveButton =>
        wishListComponentLayout.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td[@class='text-right']/a[@class='btn btn-danger']"));

        public WishListComponent(IWebElement wishListComponentLayout)
        {
            this.wishListComponentLayout = wishListComponentLayout;
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
