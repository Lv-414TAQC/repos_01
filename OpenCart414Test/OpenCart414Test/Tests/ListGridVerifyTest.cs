﻿using NUnit.Framework;
using OpenCart414Test.Data;
using OpenCart414Test.Pages;


namespace OpenCart414Test.Tests
{
    [TestFixture]
    public class GridListTest : TestRunner
    {
        private static readonly object[] ProductSearchMac = 
            {
                new object []{SearchCriteriaRepository.GetMacBookD()}
            };

        private static readonly object[] ProductUnsuccessSearch =
            {
                new object []{SearchCriteriaRepository.GetUnsuccessSearch()}
            };

        private static readonly object[] ProductEmptySearch =
            {
                new object []{SearchCriteriaRepository.GetEmptySearch()}
            };

        private static readonly object[] ProductSearchAll =
            {
                new object []{SearchCriteriaRepository.GetAllProducts(),
                SortShowRepository.SortByAsc()}
            };
        
        // Mac Search
        [Test, TestCaseSource (nameof(ProductSearchMac))]
        public void CheckSearch(SearchCriteria searchCriteria)
        {
            SearchSuccessPage searchSuccessPage = LoadApplication()
                .SearchSuccessfully(searchCriteria);
            CollectionAssert.AreEqual(searchSuccessPage.ProductsCriteria.GetNamesByGrid()
                ,searchSuccessPage.ProductsCriteria.GetNamesByList());
        }

        // qweqwe search
        [Test, TestCaseSource(nameof(ProductUnsuccessSearch))]
        public void CheckUnsuccessSearch(SearchCriteria searchCriteria)
        {
            SearchUnsuccessPage searchUnsuccessPage = LoadApplication()
                .SearchUnsuccessfully(searchCriteria);
            Assert.NotNull(searchUnsuccessPage.GetInfoMessageText());
        }

        // empty search
        [Test, TestCaseSource(nameof(ProductEmptySearch))]
        public void CheckEmptySearch(SearchCriteria searchCriteria)
        {
            SearchUnsuccessPage searchUnsuccessPage = LoadApplication()
                .SearchUnsuccessfully(searchCriteria);
            Assert.NotNull(searchUnsuccessPage.GetInfoMessageText());
        }

        // Sort test
        [Test, TestCaseSource(nameof(ProductSearchAll))]
        public void SortTest(SearchCriteria searchCriteria , SortShowCriteria sortShowCriteria)
        {
            SearchSuccessPage searchSuccessPage = LoadApplication()
             .SearchSuccessfully(searchCriteria)
             .ProductsCriteria.SortAndShowSuccessfully(sortShowCriteria);
            Assert.IsTrue(searchSuccessPage.ProductsCriteria.IsSortedAscList());
        }
    }
}