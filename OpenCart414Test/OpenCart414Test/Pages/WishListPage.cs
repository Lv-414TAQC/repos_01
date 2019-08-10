using OpenCart414Test.Data;
using OpenQA.Selenium;

namespace OpenCart414Test.Pages
{
    public class WishListPage : WishListPart
    {
        private WishListComponentContainer wishListTable;
        
        public WishListPage(IWebDriver driver) : base(driver)
        {
            InitElements();
        }
        private void InitElements()
        {
            wishListTable = new WishListComponentContainer(driver);
        }

        // Page Object
        public WishListComponentContainer getWishListComponentsContainer()
        {
            return wishListTable;
        }

        // Business Logic
        public WishListMessageEmptyPage removeLastItemFromWishList(Product removingProduct)
        {
            getWishListComponentsContainer()
                .ClickWishListComponentRemoveButtonByName(removingProduct.Title);
            return new WishListMessageEmptyPage(driver);
        }
        public WishListMessagePage AddWishListComponentToCart(Product toCartProduct)
        {
            getWishListComponentsContainer()
                .ClickWishListComponentAddToCartButtonByName(toCartProduct.Title);
            return new WishListMessagePage(driver);
        }
    }
}
