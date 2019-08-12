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
        private static readonly object[] ProductSearchBydescription =
        {
            new object[] {
                SearchCriteriaRepository.GetHp(),
                },
        };
        private static readonly object[] ProductSearchBySubCategory =
        {
            new object[] {
                SearchCriteriaRepository.GetImac(),
                },
        };
        private static readonly object[] ProductSearchShowItems =
        {
            new object[] {
                SearchCriteriaRepository.GetAllProducts(),
                SortShowRepository.ShowBy15(),
                SortShowRepository.ShowBy25(),             
                },
        };
        
        [Test, TestCaseSource(nameof(ProductSearch))]
        public void ByDefaultCategoryTest(SearchCriteria searchCriteria)
        {                                                
            SearchSuccessPage searchSuccessPage = LoadApplication().GetUnsuccessPage().SearchSuccessfullyByDefault(searchCriteria);
            Thread.Sleep(2000);     //Only for Presentation
            Assert.IsTrue(searchSuccessPage.ProductsCriteria.IsContainNameText(searchCriteria));
            Thread.Sleep(2000);     //Only for Presentation
        }
        
        [Test, TestCaseSource(nameof(ProductSearch))]
        public void SearchBySeparateCategoryTest(SearchCriteria searchCriteria)
        {
            SearchSuccessPage searchSuccessPage = LoadApplication().GetUnsuccessPage().SearchSuccessfullyByCategory(searchCriteria);
            Thread.Sleep(2000);      //Only for Presentation                         
            Assert.IsTrue(searchSuccessPage.ProductsCriteria.IsContainNameText(searchCriteria));
            Thread.Sleep(2000);      //Only for Presentation 
        }
        
        [Test, TestCaseSource(nameof(ProductSearchBydescription))]
        public void SearchByDescriptionTest(SearchCriteria searchCriteria)
        {
            SearchSuccessPage searchSuccessPage = LoadApplication().GetUnsuccessPage().SearchSuccessfullyByDescription(searchCriteria);     
            Thread.Sleep(2000);     //Only for Presentation                        
            //
            Assert.IsTrue(searchSuccessPage.ProductsCriteria.IsContainTextByDescription(searchCriteria));
            Thread.Sleep(2000);     //Only for Presentation  

        }
        
        [Test, TestCaseSource(nameof(ProductSearchBySubCategory))]
        public void SearchBySubCategoryTest(SearchCriteria searchCriteria)
        {
            SearchSuccessPage searchSuccessPage = LoadApplication().GetUnsuccessPage().SearchSuccessfullyBySubCategory(searchCriteria);
            Thread.Sleep(2000);      //Only for Presentation                        
            //
            Assert.IsTrue(searchSuccessPage.ProductsCriteria.IsContainNameText(searchCriteria));
            Thread.Sleep(2000);      //Only for Presentation
        }
        
        [Test, TestCaseSource(nameof(ProductSearchShowItems))]
        public void ShowElementsTest(SearchCriteria searchCriteria,SortShowCriteria sortShowCriteria, SortShowCriteria sortShowCriteriaA)
        {
            SearchSuccessPage searchSuccessPage = LoadApplication().SearchSuccessfully(searchCriteria);        
            Thread.Sleep(2000);  //Only for Presentation
            Assert.AreEqual(searchSuccessPage.ProductsCriteria.GetProductComponentsCount(), Convert.ToInt32(sortShowCriteria.ShowValue));
            //
            searchSuccessPage=searchSuccessPage.ProductsCriteria.SortAndShowSuccessfully(sortShowCriteriaA);
            Assert.AreEqual(searchSuccessPage.ProductsCriteria.GetProductComponentsCount(), Convert.ToInt32(sortShowCriteriaA.ShowValue));
            Thread.Sleep(2000);  //Only for Presentation
        }
    }
}
