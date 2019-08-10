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
    public class WishListToCartTest : TestRunner
    {
        private WishListPage wishListPage;
        private Product productToAdd = ProductRepository.GetIPhone();

        [TearDown]
        public void InnerTearDown()
        {
            wishListPage.removeLastItemFromWishList(productToAdd);
            AccountLogoutPage accountLogoutPage = wishListPage
                .Logout();
        }

        // DataProvider
        private static readonly object[] DataToTestOn =
        {
            new object[] { ProductRepository.GetIPhone(), UserRepository.Get().WishListTester() },
        };

        [Test, TestCaseSource(nameof(DataToTestOn))]
        public void CheckToCartFromWishList(Product productToCart, IUser user)
        {
            HomePage homePage = LoadApplication()
                .GotoLoginPage()
                .LoggingIn(user.Email, user.Password)
                .GotoHomePage();
            Thread.Sleep(2000); //for presentation only
            homePage.getProductComponentsContainer()
                .GetProductComponentByName(productToCart.Title)
                .AddItemToWishList();
            Thread.Sleep(2000); //for presentation only
            wishListPage = homePage
                .GotoWishListPage();
            WishListMessagePage wishListMessagePage = wishListPage
                .AddWishListComponentToCart(productToCart);
            Thread.Sleep(2000); //for presentation only
            Assert.IsTrue(wishListMessagePage.IsWishListAlertMessageDisplayed());
        }
    }
}
