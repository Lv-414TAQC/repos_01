using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenCart414Test.Pages;
using OpenCart414Test.Pages.AdminPanel;
using OpenCart414Test.Data;

namespace OpenCart414Test.Tests
{
    [TestFixture]
    class CurrencyConversionTests : TestRunner
    {
        decimal EuroRate;
        decimal GbpRate;
        string  UsdPrice;
        string  EuroPrice;
        string  GbpPrice;

        [SetUp]
        public override void SetUp()
        {
            AdminLoginPage ALoginPage = LoadAdminLoginPage();
            AdminHomePage AHomePage = ALoginPage.LogInAdmin();
            CurrenciesPage CurrencyPage = AHomePage.ClickCurrenciesMenu();
            EuroRate = CurrencyPage.GetCurrencyRate("Euro");
            GbpRate = CurrencyPage.GetCurrencyRate("Pound Sterling");
            HomePage UserHomePage = LoadHomePage();
            UserHomePage = UserHomePage.ChooseCurrency(Currency.US_DOLLAR);
            UsdPrice = UserHomePage.GetProductNewPrice("Canon EOS 5D");
            UserHomePage = UserHomePage.ChooseCurrency(Currency.EURO);
            EuroPrice = UserHomePage.GetProductNewPrice("Canon EOS 5D");
            UserHomePage = UserHomePage.ChooseCurrency(Currency.POUND_STERLING);
            GbpPrice = UserHomePage.GetProductNewPrice("Canon EOS 5D");

        }

        [Test]
        public void CheckCurrenciesConvertion()
        {
            Console.WriteLine(EuroRate);
            Console.WriteLine(GbpRate);
            Console.WriteLine(EuroPrice);
            Console.WriteLine(UsdPrice);
            Console.WriteLine(GbpPrice);
        }
    }
}
