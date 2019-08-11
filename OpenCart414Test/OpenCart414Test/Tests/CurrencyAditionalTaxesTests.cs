using System;
using NUnit.Framework;
using OpenCart414Test.Pages;
using OpenCart414Test.Pages.AdminPanel;
using OpenCart414Test.Data;

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


        }

        [Test]
        public void CheckCurrencyFormat()
        {

        }
    }
}
