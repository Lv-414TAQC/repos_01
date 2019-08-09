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
    public class WishListRemoveTest : TestRunner
    {
        private WishListMessageEmptyPage wishListMessageEmptyPage;

        [TearDown]
        public void InnerTearDown()
        {
            AccountLogoutPage accountLogoutPage = wishListMessageEmptyPage
                .Logout();
        }

        // DataProvider
        private static readonly object[] ProductToTestOn =
        {
            new object[] { ProductRepository.GetIPhone() },
        };

        [Test, TestCaseSource(nameof(ProductToTestOn))]
        public void CheckRemoving(Product productToRemove)
        {
            HomePage homePage = LoadApplication()
                .GotoLoginPage()
                .LoggingIn("roman_my@ukr.net", "TESTER_PASWORD")
                .GotoHomePage();
            Thread.Sleep(2000); //for presentation only
            homePage.getProductComponentsContainer()
                .GetProductComponentByName(productToRemove.Title)
                .AddItemToWishList();
            Thread.Sleep(2000); //for presentation only
            wishListMessageEmptyPage = homePage
                .GotoWishListPage()
                .removeLastItemFromWishList(productToRemove);
            Thread.Sleep(2000); //for presentation only
            Assert.IsTrue(wishListMessageEmptyPage.IsWishListAlertMessageDisplayed());
            Assert.IsTrue(wishListMessageEmptyPage.IsWishListIsEmptyParagraphDisplayed());
        }
    }
}
