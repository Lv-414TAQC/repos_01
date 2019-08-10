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
        private static readonly object[] ProductSearchMac = 
            {
                new object []{SearchCriteriaRepository.GetMacBookD()}
            };
        private static readonly object[] ProductSearchAll =
            {
                new object []{SearchCriteriaRepository.GetAllProducts()}
            };

        [Test, TestCaseSource (nameof(ProductSearchMac))]
        public void CheckSearch(SearchCriteria searchCriteria)
        {
            SearchSuccessPage searchSuccessPage = LoadApplication()
                .SearchSuccessfully(searchCriteria);
            CollectionAssert.AreEqual(searchSuccessPage.ProductsCriteria.GetNamesByGrid()
                ,searchSuccessPage.ProductsCriteria.GetNamesByList());
        }

        [Test, TestCaseSource(nameof(ProductSearchAll))]
        public void SortTest(SearchCriteria searchCriteria)
        {
            SearchSuccessPage searchSuccessPage = LoadApplication()
                .SearchSuccessfully(searchCriteria)
                .ProductsCriteria.SetSortLowHigh();
            Assert.IsTrue(searchSuccessPage.ProductsCriteria.IsSortedAscList());
        }
    }
}