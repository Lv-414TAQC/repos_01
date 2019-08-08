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
        // DataProvider
        private static readonly object[] ProductSearch =
        {
            new object[] {
                SearchCriteriaRepository.GetMacBookD(),
                },
        };

        // [Test, TestCaseSource(nameof(ProductSearch))]
        //[Test]
        public void CheckSearchByDefaultCategory(/*SearchCriteria searchCriteria*/)
        {
            //Переробити , забрати атомарні методи і переробити в бізнес логіку
            HomePage homePage = LoadApplication();
            SearchUnsuccessPage searchUnsuccessPage = homePage.GetUnsuccessPage();
            Thread.Sleep(2000);
            SearchSuccessPage searchSuccessPage = searchUnsuccessPage.MakeCriteriaSearch();
            Thread.Sleep(2000);

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
            //searchUnsuccessPage.ClickCriteriaSearchField();
            //searchUnsuccessPage.ClearCriteriaSearchField();
            //searchUnsuccessPage.SetCriteriaSearchField("Mac");

            //SearchSuccessPage searchSuccessPage = searchUnsuccessPage.ClickCriteriaSearchButtonD();
            //Thread.Sleep(2000);

            ///////////////////////////////////////////////////////////////////////////////////////////////////
            //SearchSuccessPage searchSuccessPage = LoadApplication().SearchSuccessfully(searchCriteria);
            //searchSuccessPage.ProductsCriteria.GetProductComponentsCount();

            //Console.WriteLine(searchSuccessPage.ProductsCriteria.GetProductComponentsCount());
            //Thread.Sleep(2000);

        }
        [Test]
        public void CheckSearchBySeparateCategory(/*SearchCriteria searchCriteria*/)
        {
            //Переробити , забрати атомарні методи і переробити в бізнес логіку
            HomePage homePage = LoadApplication();
            SearchUnsuccessPage searchUnsuccessPage = homePage.GetUnsuccessPage();
            Thread.Sleep(2000);
            SearchSuccessPage searchSuccessPage = searchUnsuccessPage.MakeSearchBySeparateCategory();
            Thread.Sleep(2000);


        }
    }
}
