using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenCart414Test.Data;
using OpenCart414Test.Pages;

namespace OpenCart414Test.Tests
{
    [TestFixture]
    class SearchByDefaultCategoryTest : TestRunner
    {
        //DataProvider
        private static readonly object[] ProductSearch =
        {
            new object[] {
                SearchCriteriaRepository.GetMacBookD(),
                }
        };
        private static readonly object[] ProductSearch1 =
        {
            new object[] {
                SearchCriteriaRepository.GetHp(),
                }
        };

        //[Test, TestCaseSource(nameof(ProductSearch))]
        public void CheckSearchByDefaultCategory(SearchCriteria searchCriteria)
        {
            HomePage homePage = LoadApplication();
            SearchUnsuccessPage searchUnsuccessPage = homePage.GetUnsuccessPage();
            Thread.Sleep(2000);  //Only for Presentation
            SearchSuccessPage searchSuccessPage = searchUnsuccessPage.SearchSuccessfullyByDefault(searchCriteria);
            Thread.Sleep(2000);  //Only for Presentation

            bool temp = true;
            foreach (var a in searchSuccessPage.ProductsCriteria.GetProductComponentNames())
            {
                Console.WriteLine(a);
                Console.WriteLine(searchSuccessPage.GetCriteriaSearchFieldText());
                if (!a.Contains(searchSuccessPage.GetCriteriaSearchFieldText()))
                {
                    temp = false;
                }
            }
            Assert.IsTrue(temp);

            ///////////////////////////////////////////////////////////////////////////////////////////////////
            //SearchSuccessPage searchSuccessPage = LoadApplication().SearchSuccessfully(searchCriteria);
            //searchSuccessPage.ProductsCriteria.GetProductComponentsCount();
            //Console.WriteLine(searchSuccessPage.ProductsCriteria.GetProductComponentsCount());
            //Thread.Sleep(2000);

        }
        //[Test, TestCaseSource(nameof(ProductSearch))]
        public void CheckSearchBySeparateCategory(SearchCriteria searchCriteria)
        {
            HomePage homePage = LoadApplication();
            SearchUnsuccessPage searchUnsuccessPage = homePage.GetUnsuccessPage();
            Thread.Sleep(2000);  //Only for Presentation
            SearchSuccessPage searchSuccessPage = searchUnsuccessPage.SearchSuccessfullyByCategory(searchCriteria);
            Thread.Sleep(2000);  //Only for Presentation
            //
            bool temp = true;
            foreach (var a in searchSuccessPage.ProductsCriteria.GetProductComponentNames())
            {
                if (!a.Contains(searchSuccessPage.GetCriteriaSearchFieldText()))
                {
                    temp = false;
                }
            }
            Assert.IsTrue(temp);
        }
        //[Test, TestCaseSource(nameof(ProductSearch1))]
        public void CheckSearchByDescription(SearchCriteria searchCriteria)
        {
            HomePage homePage = LoadApplication();
            SearchUnsuccessPage searchUnsuccessPage = homePage.GetUnsuccessPage();
            Thread.Sleep(2000);  //Only for Presentation
            SearchSuccessPage searchSuccessPage = searchUnsuccessPage.SearchSuccessfullyByDescription(searchCriteria);
            Thread.Sleep(2000);  //Only for Presentation
            //
            bool temp = true;
            for(int a=0; a < searchSuccessPage.ProductsCriteria.GetProductComponentsCount(); a++) 
            {
                if (!searchSuccessPage.ProductsCriteria.GetProductComponentDescriptionByName("HP LP3065").Contains("with the stunning new 30-inch diagonal"))
                {
                    temp = false;
                }
            }
            Assert.IsTrue(temp);
        }
    }
}
