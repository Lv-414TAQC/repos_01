using System;
using NUnit.Framework;
using OpenCart414Test.Pages;
using OpenCart414Test.Pages.AdminPanel;
using OpenCart414Test.Data;
using System.Threading;

namespace OpenCart414Test.Tests
{
    [TestFixture]
    class CurrencyWishListTests : TestRunner
    {
        HomePage homePage;

        [OneTimeSetUp]
        public  override void SetUp()
        {
            IUser user = UserRepository.GetTestUser();
            homePage = LoadHomePage().GotoLoginPage().LoggingIn(user.Email, user.Password).GotoHomePage();
            homePage.getProductComponentsContainer().AddProductToWishList(ProductRepository.GetIPhone());
            Thread.Sleep(1000);

        }

        [TestCase(Currency.US_DOLLAR, @"^\$\d+\.\d{2}")]
        [TestCase(Currency.EURO, @"\d+\.\d{2}€$")]
        [TestCase(Currency.POUND_STERLING, @"^£\d+\.\d{2}")]
        public void CheckPriceIsInCorrectCurrencyFormat(Currency currency, string puttern)
        {
            homePage = homePage.ChooseCurrency(currency);
            homePage.ClickWishList();
            WishListPage wishListPage = homePage.GotoWishListPage();
            WishListComponent iPhone = wishListPage.GetWishListComponentsContainer().GetWishListComponentByName(ProductRepository.GetIPhone().GetName());
            string actualResult = iPhone.GetWishListComponentUnitPriceText();
            Console.WriteLine(actualResult);
            StringAssert.IsMatch(puttern, actualResult);
        }
    }
}
