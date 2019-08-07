using CurrencyTests.Stetsula.Pages;
using NUnit.Framework;
using OpenCartTests.Stetsula.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;

namespace OpenCartTests.Stetsula
{
    [TestFixture]
    class MyTest
    {
        IWebDriver Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        [Test]
        public void CheckLogInAdmin()
        {
            //ChromeOptions options = new ChromeOptions();
            //options.AddArguments(@"C:\Users\Oleg\AppData\Local\Google\Chrome\User Data");
            //Console.WriteLine(Page.AdminName);
            Driver.Navigate().GoToUrl(@"http://192.168.17.128/opencart/upload/admin/");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Maximize();
            AdminLoginPage Page = new AdminLoginPage(Driver);
            Page.LogInAdmin();
            AdminHomePage HomePage = new AdminHomePage(Driver);
            //HomePage.ClickGeoZonesMenu();
            //GeoZonesPage GZ = new GeoZonesPage(Driver);
            //GZ.AddNewGeoZone("UA New Tax", "Cool tax for people", "Ukraine");
            //HomePage.ClickTaxRatesMenu();
            //TaxRatesPage TaxRates = new TaxRatesPage(Driver);
            //TaxRates.AddNewTaxRate("MyFixedTestTax", 5, "Fixed Amount", "UA New Tax");
            //TaxRates.DeleteTaxrate("FixedTestTax");
            HomePage.ClickTaxClassesMenu();
            TaxClassesPage TX = new TaxClassesPage(Driver);
            TX.ClickTaxClassEditButton("Taxable Goods");
        }

    }
}
