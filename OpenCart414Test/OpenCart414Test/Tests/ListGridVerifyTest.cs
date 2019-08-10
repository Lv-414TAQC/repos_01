using NUnit.Framework;
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
        private static readonly object[] ProductSearchAll =
            {
                new object []{SearchCriteriaRepository.GetAllProducts()}
            };
        private static readonly object[] ProductUnsuccessSearch =
            {
                new object []{SearchCriteriaRepository.GetUnsuccessSearch()}
            };

        [Test, TestCaseSource (nameof(ProductSearchMac))]
        public void CheckSearch(SearchCriteria searchCriteria)
        {
            SearchSuccessPage searchSuccessPage = LoadApplication()
                .SearchSuccessfully(searchCriteria);
            CollectionAssert.AreEqual(searchSuccessPage.ProductsCriteria.GetNamesByGrid()
                ,searchSuccessPage.ProductsCriteria.GetNamesByList());
        }

        [Test, TestCaseSource(nameof(ProductUnsuccessSearch))]
        public void CheckUnsuccessSearch(SearchCriteria searchCriteria)
        {
            SearchUnsuccessPage searchUnsuccessPage = LoadApplication()
                .SearchUnsuccessfully(searchCriteria);
            Assert.NotNull(searchUnsuccessPage.GetInfoMessageText());
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