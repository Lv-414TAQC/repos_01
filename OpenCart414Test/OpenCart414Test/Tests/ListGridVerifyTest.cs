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
        [Test]
        public void CheckSearch()
        {
            SearchSuccessPage searchSuccessPage = LoadApplication().SearchTopSuccessfully();
            CollectionAssert.AreEqual(searchSuccessPage.GetListByGrid(), searchSuccessPage.GetListByList());
        }

        [Test]
        public void SortTest()
        {
            SearchSuccessPage searchSuccessPage = LoadApplication().SearchAllProductsSuccessfully()
                .ProductsCriteria.SetSortLowHigh();
            Assert.IsTrue(searchSuccessPage.ProductsCriteria.IsSortedAscList());
        }
    }
}