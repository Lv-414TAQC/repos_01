using System;
using NUnit.Framework;
using OpenCart414Test.Pages;
using OpenCart414Test.Pages.AdminPanel;
using OpenCart414Test.Data;
using System.Threading;

namespace OpenCart414Test.Tests
{
    [TestFixture]
    class CurrencyAditionalTaxesTests : TestRunner
    {
        ShoppingCartPage cartPage;
        string SubTotal;
        string FlatShippingRate;
        string FixedTestTax;
        string PercentageTestTax;
        string Total;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            AdminLoginPage ALoginPage = LoadAdminLoginPage();
            AdminHomePage AHomePage = ALoginPage.LogInAdmin();
            AHomePage.ClickSystemMenu();
            AHomePage.ClickLocalizationMenu();
            GeoZonesPage zonesPage = AHomePage.GoToGeoZonePage();
            zonesPage.AddNewGeoZone(GeoZonesRepository.GetUAGeoZone());
            zonesPage.ClickSystemMenu();
            zonesPage.ClickTaxesMenu();
            TaxRatesPage ratesPage = zonesPage.GoToTaxRatesPage();
            ratesPage.AddNewTaxRate(TaxRateRepository.GetFixTaxRate());
            ratesPage.AddNewTaxRate(TaxRateRepository.GetPercentageTaxRate());
            ratesPage.ClickSystemMenu();
            TaxClassesPage classesPage = ratesPage.GoToTaxClassesPage();
            classesPage = classesPage.EditTaxClass(TaxClassesRepository.GetTaxebleProductsTaxClass(), TaxRateRepository.GetFixTaxRate());
            classesPage = classesPage.EditTaxClass(TaxClassesRepository.GetTaxebleProductsTaxClass(), TaxRateRepository.GetPercentageTaxRate());
            Thread.Sleep(2000);             // for presentation ONLY



        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

            AdminLoginPage ALoginPage = LoadAdminLoginPage();
            ALoginPage.ClickLoginButton();
            AdminHomePage adminHomePage = ALoginPage.LogInAdmin();
            adminHomePage.ClickSystemMenu();
            adminHomePage.ClickLocalizationMenu();
            adminHomePage.ClickTaxesMenu();
            TaxClassesPage taxClassesPage = adminHomePage.GoToTaxClassesPage();
            taxClassesPage = taxClassesPage.RemoveRuleFromTaxClass(TaxClassesRepository.GetTaxebleProductsTaxClass(), TaxRateRepository.GetFixTaxRate());
            taxClassesPage = taxClassesPage.RemoveRuleFromTaxClass(TaxClassesRepository.GetTaxebleProductsTaxClass(), TaxRateRepository.GetPercentageTaxRate());
            Thread.Sleep(3000);         // for presentation ONLY
            taxClassesPage.ClickSystemMenu();
            TaxRatesPage taxRatesPage = taxClassesPage.GoToTaxRatesPage();
            taxRatesPage = taxRatesPage.DeleteTaxRate(TaxRateRepository.GetFixTaxRate().Name);
            taxRatesPage = taxRatesPage.DeleteTaxRate(TaxRateRepository.GetPercentageTaxRate().Name);
            Thread.Sleep(3000);         // for presentation ONLY
            taxClassesPage.ClickSystemMenu();
            GeoZonesPage geoZonesPage = taxClassesPage.GoToGeoZonePage();
            geoZonesPage.DeleteGeoZone(GeoZonesRepository.GetUAGeoZone().Name);
            Thread.Sleep(1000);         // for presentation ONLY


        }

        [TestCase(Currency.US_DOLLAR, @"^\$\d+\.\d{2}")]
        [TestCase(Currency.EURO, @"\d+\.\d{2}€$")]
        [TestCase(Currency.POUND_STERLING, @"^£\d+\.\d{2}")]
        public void CheckCurrencyFormat(Currency currency, string puttern)
        {
            HomePage homePage = LoadHomePage();
            homePage = homePage.ChooseCurrency(currency);
            homePage.AddProductToCart(ProductRepository.GetIPhone());
            cartPage = homePage.GotoShoppingCartPage();
            SelectShippingMethodComponent ShippingMethod = cartPage.ApplySippingAndTaxes(ShippingDetailsRepository.GetUADetails());
            cartPage = ShippingMethod.ApllyShippingMethod();
            Thread.Sleep(2000);                                          // for presentation ONLY
            Total = cartPage.GetPriceOption("Total:");
            SubTotal = cartPage.GetPriceOption("Sub-Total:");
            FlatShippingRate = cartPage.GetPriceOption("Flat Shipping Rate:");
            FixedTestTax = cartPage.GetPriceOption(TaxRateRepository.GetFixTaxRate().Name + ":");
            PercentageTestTax = cartPage.GetPriceOption(TaxRateRepository.GetPercentageTaxRate().Name + ":");

            StringAssert.IsMatch(puttern, Total);
            StringAssert.IsMatch(puttern, SubTotal);
            StringAssert.IsMatch(puttern, FlatShippingRate);
            StringAssert.IsMatch(puttern, FixedTestTax);
            StringAssert.IsMatch(puttern, PercentageTestTax);

            // for presentation ONLY
            Console.WriteLine(Total);
            Console.WriteLine(SubTotal);
            Console.WriteLine(FlatShippingRate);
            Console.WriteLine(PercentageTestTax);
            Console.WriteLine(FixedTestTax);
        }
        
        [Test]
        public void CheckFixedTaxHasTheSameValueAsInAdminPanel()
        {
            HomePage homePage = LoadHomePage();
            homePage.AddProductToCart(ProductRepository.GetIPhone());
            cartPage = homePage.GotoShoppingCartPage();
            SelectShippingMethodComponent ShippingMethod = cartPage.ApplySippingAndTaxes(ShippingDetailsRepository.GetUADetails());
            cartPage = ShippingMethod.ApllyShippingMethod();
            Thread.Sleep(2000);                                          // for presentation ONLY
           
            decimal fixedTestTax = cartPage.GetPriceOptionValue(TaxRateRepository.GetFixTaxRate().Name + ":");
            decimal expectedResult = 2m;
            Assert.AreEqual(expectedResult,fixedTestTax);
        }
    }
}
