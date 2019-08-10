using System.Threading;
using NUnit.Framework;
using OpenCart414Test.Data;
using OpenCart414Test.Pages;


namespace OpenCart414Test.Tests
{
    [TestFixture]
    public class WishListRemoveTest : TestRunner
    {/*
        private WishListMessageEmptyPage wishListMessageEmptyPage;

        [TearDown]
        public void InnerTearDown()
        {
            AccountLogoutPage accountLogoutPage = wishListMessageEmptyPage
                .Logout();
        }

        // DataProvider
        private static readonly object[] DataToTestOn =
        {
            new object[] { ProductRepository.GetIPhone(), UserRepository.Get().WishListTester() },
        };

        [Test, TestCaseSource(nameof(DataToTestOn))]
        public void CheckRemoving(Product productToRemove, IUser user)
        {
            HomePage homePage = LoadApplication()
                .GotoLoginPage()
                .LoggingIn(user.Email, user.Password)
                .GotoHomePage();
            Thread.Sleep(2000); //for presentation only
            homePage.getProductComponentsContainer()
                .GetProductComponentByName(productToRemove.Title)
                .AddItemToWishList();
            Thread.Sleep(2000); //for presentation only
            wishListMessageEmptyPage = homePage
                .GotoWishListPage()
                .RemoveLastItemFromWishList(productToRemove);
            Thread.Sleep(2000); //for presentation only
            Assert.IsTrue(wishListMessageEmptyPage.IsWishListAlertMessageDisplayed());
            Assert.IsTrue(wishListMessageEmptyPage.IsWishListIsEmptyParagraphDisplayed());
        }*/
    }
}
