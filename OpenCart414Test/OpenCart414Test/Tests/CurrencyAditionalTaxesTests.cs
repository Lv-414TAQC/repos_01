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
            GeoZonesPage zonesPage =  AHomePage.GoToGeoZonePage();
            zonesPage.AddNewGeoZone(GeoZonesRepository.GetUAGeoZone());
            TaxRatesPage ratesPage = zonesPage.GoToTaxRatesPage();
            ratesPage.AddNewTaxRate(TaxRateRepository.GetFixTaxRate());
            ratesPage.AddNewTaxRate(TaxRateRepository.GetPercentageTaxRate());
            TaxClassesPage classesPage =  ratesPage.GoToTaxClassesPage();
            classesPage.EditTaxClass(TaxClassesRepository.GetTaxebleProductsTaxClass(), TaxRateRepository.GetFixTaxRate());
            HomePage homePage = LoadHomePage();
            homePage.AddProductToCart(ProductRepository.GetIPhone());
            ShoppingCartPage cartPage = homePage.GotoShoppingCartPage();
            SelectShippingMethodComponent ShippingMethod = cartPage.ApplySippingAndTaxes(ShippingDetailsRepository.GetUkDetails());
            Thread.Sleep(2000);
            ShippingMethod.ApllyShippingMethod();
            Thread.Sleep(2000);

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            AdminLoginPage ALoginPage = LoadAdminLoginPage();
            AdminHomePage AHomePage = ALoginPage.LogInAdmin();
        }

        [Test]
        public void CheckCurrencyFormat()
        {

        }
    }
}
