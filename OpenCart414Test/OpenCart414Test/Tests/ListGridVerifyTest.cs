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
    public class GridListTest : TestRunner
    {
        //[Test]
        public void CheckSearch()
        {
            HomePage homePage = LoadApplication(); //open home
            SearchSuccessPage searchSuccessPage = homePage.SearchTopSuccessfully();

            Assert.AreEqual(searchSuccessPage.SwitchToGrid(), searchSuccessPage.SwitchToList());
        }

        [Test]
        public void SortTest()
        {
            HomePage homePage = LoadApplication(); //open home
            SearchSuccessPage searchSuccessPage = homePage.SearchAllProductsSuccessfully();
            searchSuccessPage.ProductsCriteria.SetSortLowHigh();
            bool actual = searchSuccessPage.ProductsCriteria.IsSortedList(searchSuccessPage.ProductsCriteria.GetProductComponentIntPrices());
            Assert.IsTrue(actual);
        }
    }
}