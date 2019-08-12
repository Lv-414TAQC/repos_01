using System;
using NUnit.Framework;
using OpenCart414Test.Pages;
using OpenCart414Test.Pages.AdminPanel;
using OpenCart414Test.Data;

namespace OpenCart414Test.Tests
{
    [TestFixture]
    class CurrencyConversionTests : TestRunner
    {
        decimal euroRate;
        decimal gbpRate;
        decimal  usdPrice;
        decimal  euroPrice;
        decimal  gbpPrice;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            AdminLoginPage ALoginPage = LoadAdminLoginPage();
            AdminHomePage AHomePage = ALoginPage.LogInAdmin();
            CurrenciesPage CurrencyPage = AHomePage.ClickCurrenciesMenu();
            euroRate = CurrencyPage.GetCurrencyRate("Euro");
            gbpRate = CurrencyPage.GetCurrencyRate("Pound Sterling");
            HomePage UserHomePage = LoadHomePage();
            UserHomePage = UserHomePage.ChooseCurrency(Currency.US_DOLLAR);
            UserHomePage = LoadHomePage();
            usdPrice = UserHomePage.GetProductNewPriceValue(ProductRepository.GetCanonEos5D());
            UserHomePage = UserHomePage.ChooseCurrency(Currency.EURO);
            UserHomePage = LoadHomePage();
            euroPrice = UserHomePage.GetProductNewPriceValue(ProductRepository.GetCanonEos5D());
            UserHomePage = UserHomePage.ChooseCurrency(Currency.POUND_STERLING);
            UserHomePage = LoadHomePage();
            gbpPrice = UserHomePage.GetProductNewPriceValue(ProductRepository.GetCanonEos5D());

        }

        [Test]
        public void CheckConversion()
        {
            Console.WriteLine(euroRate);                                    //for presentation ONLY!
            decimal Conversion = Math.Round(usdPrice * euroRate, 2);
            Console.WriteLine(Conversion);                                  //for presentation ONLY!
            Assert.AreEqual(Conversion, euroPrice);
        }
        [Test]
        public void CheckGbpConversion()
        {
            decimal Conversion = Math.Round(usdPrice * gbpRate, 2);
            Assert.AreEqual(Conversion, gbpPrice);
        }
    }
}
