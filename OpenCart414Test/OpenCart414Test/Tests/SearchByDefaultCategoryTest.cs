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
                SearchCriteriaRepository.GetHpSearchCriteria(),
                },
        };
        private static readonly object[] ProductSearch2 =
        {
            new object[] {
                SearchCriteriaRepository.GetImac(),
                },
        };
        private static readonly object[] ProductSearch4 =
        {
            new object[] {
                SearchCriteriaRepository.GetAllProducts(),
                SortShowRepository.ShowBy15(),
                SortShowRepository.ShowBy25(),             
                },
        };
        //
        [Test, TestCaseSource(nameof(ProductSearch))]
        public void CheckSearchByDefaultCategory(SearchCriteria searchCriteria)
        {
            SearchSuccessPage searchSuccessPage = LoadApplication().GetUnsuccessPage().SearchSuccessfullyByDefault(searchCriteria);
            Thread.Sleep(2000);  //Only for Presentation
            Assert.IsTrue(searchSuccessPage.ProductsCriteria.IsContainNameText(searchCriteria));
            Thread.Sleep(2000);  //Only for Presentation
        }
        //
        [Test, TestCaseSource(nameof(ProductSearch))]
        public void CheckSearchBySeparateCategory(SearchCriteria searchCriteria)
        {
            SearchSuccessPage searchSuccessPage = LoadApplication().GetUnsuccessPage().SearchSuccessfullyByCategory(searchCriteria);
            Thread.Sleep(2000);  //Only for Presentation            
            Assert.IsTrue(searchSuccessPage.ProductsCriteria.IsContainNameText(searchCriteria));
            Thread.Sleep(2000);  //Only for Presentation 

            //HomePage homePage = LoadApplication();
            //SearchUnsuccessPage searchUnsuccessPage = homePage.GetUnsuccessPage();
            //SearchSuccessPage searchSuccessPage = searchUnsuccessPage.SearchSuccessfullyByCategory(searchCriteria);
        }
        //
        [Test, TestCaseSource(nameof(ProductSearch1))]
        public void CheckSearchByDescription(SearchCriteria searchCriteria)
        {
            SearchSuccessPage searchSuccessPage = LoadApplication().GetUnsuccessPage().SearchSuccessfullyByDescription(searchCriteria);     
            Thread.Sleep(2000);  //Only for Presentation                        
            //
            Assert.IsTrue(searchSuccessPage.ProductsCriteria.IsContainTextByDescription(searchCriteria));
            Thread.Sleep(2000);  //Only for Presentation  

        }
        //
        [Test, TestCaseSource(nameof(ProductSearch2))]
        public void CheckSearchBySubCategory(SearchCriteria searchCriteria)
        {
            SearchSuccessPage searchSuccessPage = LoadApplication().GetUnsuccessPage().SearchSuccessfullyBySubCategory(searchCriteria);
            Thread.Sleep(2000);  //Only for Presentation                        
            //
            Assert.IsTrue(searchSuccessPage.ProductsCriteria.IsContainNameText(searchCriteria));
            Thread.Sleep(2000);  //Only for Presentation
        }
        //
        [Test, TestCaseSource(nameof(ProductSearch4))]
        public void ShowElementsTest(SearchCriteria searchCriteria,SortShowCriteria sortShowCriteria, SortShowCriteria sortShowCriteriaA)
        {
            SearchSuccessPage searchSuccessPage = LoadApplication().SearchSuccessfully(searchCriteria);        
            Thread.Sleep(2000);  //Only for Presentation
            Assert.AreEqual(searchSuccessPage.ProductsCriteria.GetProductComponentsCount(), Convert.ToInt32(sortShowCriteria.ShowValue));
            //
            searchSuccessPage = searchSuccessPage.ProductsCriteria.SortAndShowSuccessfully(sortShowCriteriaA);
            Assert.AreEqual(searchSuccessPage.ProductsCriteria.GetProductComponentsCount(), Convert.ToInt32(sortShowCriteriaA.ShowValue));
            Thread.Sleep(2000);  //Only for Presentation

        }
    }
}
