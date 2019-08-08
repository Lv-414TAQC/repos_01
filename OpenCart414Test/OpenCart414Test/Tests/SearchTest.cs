using System;
using System.IO;
using System.Text;
using System.Threading;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenCart414Test.Data;
using OpenCart414Test.Pages;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.Interactions;

namespace OpenCart414Test.Tests
{
    [TestFixture]
    public class SearchTest : TestRunner
    {
        // DataProvider
        private static readonly object[] ProductSearch =
        {
            new object[] { ProductRepository.GetMacBook(),
                SearchCriteriaRepository.GetMacBook(),
                Currency.EURO },
            new object[] { ProductRepository.GetMacBook(),
                SearchCriteriaRepository.GetMacBook(),
                Currency.POUND_STERLING },
        };

        [Test, TestCaseSource(nameof(ProductSearch))]
        public void CheckSearch(Product expectedProduct, SearchCriteria searchCriteria, Currency currency)
        {
            // Steps
            SearchSuccessPage searchSuccessPage = LoadApplication()
                .SearchSuccessfully(searchCriteria)
                .ChooseCurrency(currency);
            ProductComponent actualPoductComponent = searchSuccessPage
                .ProductsCriteria
                .ProductsContainer
                .GetProductComponentByName(expectedProduct.Title);
            //
            // Check
            Assert.IsTrue(actualPoductComponent
                .GetPartialDescriptionText()
                .Contains(expectedProduct.Description));
            Assert.IsTrue(actualPoductComponent
                .GetPriceText()
                .Contains(expectedProduct.GetPrice(currency)));
            //
            Thread.Sleep(5000); // For Presentation ONLY
            //
            // Continue Searching. Use SearchCriteria from SearchCriteriaPart
            //
            // Return to Previous State
            HomePage homePage = searchSuccessPage.GotoHomePage();
            //
            // Check (optional)
            Assert.IsTrue(homePage
                .GetSlideshow0FirstImageAttributeSrcText()
                .Contains(HomePage.IPHONE6));
            //
            Thread.Sleep(3000); // For Presentation ONLY
        }

        //[Test]
        public void CheckLogin()
        {
            // Steps
            //HomePage homePage = LoadApplication();
            //LoginPage loginPage = homePage.GotoLoginPage();
            LoginPage loginPage = LoadApplication()
                .GotoLoginPage();
                //.Login(user);
            //
            // Check
            //
            // Return to Previous State
            //
            // Check (optional)
            //
            Thread.Sleep(5000); // For Presentation ONLY
        }
    }
}
