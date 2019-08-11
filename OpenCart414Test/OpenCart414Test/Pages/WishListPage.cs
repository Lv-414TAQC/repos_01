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

        // Atomic
        public WishListComponentContainer GetWishListComponentsContainer()
        {
            return wishListTable;
        }

        // Business Logic
        public WishListMessageEmptyPage RemoveLastItemFromWishList(Product removingProduct)
        {
            GetWishListComponentsContainer()
                .ClickWishListComponentRemoveButtonByName(removingProduct.Title);
            return new WishListMessageEmptyPage(driver);
        }
        public WishListMessagePage AddWishListComponentToCart(Product toCartProduct)
        {
            GetWishListComponentsContainer()
                .ClickWishListComponentAddToCartButtonByName(toCartProduct.Title);
            return new WishListMessagePage(driver);
        }

    }
}
