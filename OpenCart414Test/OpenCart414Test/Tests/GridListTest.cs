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
        // DataProvider
        private static readonly object[] ProductSearch =
        {
            new object[] { ProductRepository.GetMacBook(),
                SearchCriteriaRepository.GetMacBook() }
        };

        [Test]
        public void CheckSearch()
        {
            HomePage homePage = LoadApplication(); //open home
            SearchSuccessPage searchSuccessPage = homePage.SearchTopSuccessfully();

            Assert.AreEqual(searchSuccessPage.SwitchToGrid(), searchSuccessPage.SwitchToList());

        }
    }
}