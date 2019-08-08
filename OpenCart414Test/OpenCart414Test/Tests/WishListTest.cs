using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenCart414Test.Data;
using OpenCart414Test.Pages;

namespace OpenCart414Test.Tests
{
    [TestFixture]
    public class WishListTest : TestRunner
    {
        // DataProvider
        private static readonly object[] ProductToTestOn =
        {
            new object[] { ProductRepository.GetIPhone() },
        };
        [Test, TestCaseSource(nameof(ProductToTestOn))]
        public void CheckAdding(Product addingProduct)
        {
            HomePage homePage = LoadApplication()
                .GotoLoginPage()
                .LoggingIn("roman_my@ukr.net", "TESTER_PASWORD")
                .GotoHomePage();
            Thread.Sleep(2000); //for presentation only
            ProductComponent productComponent = homePage
                .getProductComponentsContainer()
                .GetProductComponentByName(addingProduct.Title);
            Thread.Sleep(2000); //for presentation only
            productComponent.AddItemToWishList();
            Thread.Sleep(2000); //for presentation only
            WishListPage wishListPage = homePage
                .GotoWishListPage();
            Thread.Sleep(2000); //for presentation only
            Assert.IsTrue(wishListPage
                .getWishListComponentsContainer()
                .GetWishListComponentNames()
                .Contains(addingProduct.Title));
            wishListPage.removeLastItemFromWishList(addingProduct);
            AccountLogoutPage accountLogoutPage = wishListPage
                .Logout();
        }

        [Test, TestCaseSource(nameof(ProductToTestOn))]
        public void CheckRemoving(Product productToRemove)
        {
            HomePage homePage = LoadApplication()
                .GotoLoginPage()
                .LoggingIn("roman_my@ukr.net", "TESTER_PASWORD")
                .GotoHomePage();
            Thread.Sleep(2000); //for presentation only
            ProductComponent productComponent = homePage
                .getProductComponentsContainer()
                .GetProductComponentByName(productToRemove.Title);
            Thread.Sleep(2000); //for presentation only
            productComponent.AddItemToWishList();
            Thread.Sleep(2000); //for presentation only
            WishListEmptyPage wishListEmptyPage = homePage
                .GotoWishListPage()
                .removeLastItemFromWishList(productToRemove);
            Thread.Sleep(2000); //for presentation only
            Assert.IsTrue(wishListEmptyPage.WishListIsEmptyParagraph.Displayed);
            AccountLogoutPage accountLogoutPage = wishListEmptyPage
                .Logout();
        }

        [Test, TestCaseSource(nameof(ProductToTestOn))]
        public void CheckToCartFromWishList(Product productToCart)
        {
            HomePage homePage = LoadApplication()
                .GotoLoginPage()
                .LoggingIn("roman_my@ukr.net", "TESTER_PASWORD")
                .GotoHomePage();
            Thread.Sleep(2000); //for presentation only
            ProductComponent productComponent = homePage
                .getProductComponentsContainer()
                .GetProductComponentByName(productToCart.Title);
            Thread.Sleep(2000); //for presentation only
            productComponent.AddItemToWishList();
            Thread.Sleep(2000); //for presentation only
            WishListPage wishListPage = homePage
                .GotoWishListPage();
            WishListComponent wishListComponent = wishListPage
                .getWishListComponentsContainer()
                .GetWishListComponentByName(productToCart.Title);
            wishListComponent.ClickWishListComponentAddToCartButton();
            Thread.Sleep(2000); //for presentation only
            Assert.IsTrue(wishListPage.WishListAlertMessage.Displayed);
            AccountLogoutPage accountLogoutPage = wishListPage
                .Logout();
        }
    }
}
