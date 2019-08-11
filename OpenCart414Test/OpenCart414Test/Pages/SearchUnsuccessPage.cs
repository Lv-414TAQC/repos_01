using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class SearchUnsuccessPage : SearchCriteriaPart
    {
        public IWebElement InfoMessage
        { get { return driver.FindElement(By.CssSelector("#button-search + h2 + p")); } }

        public SearchUnsuccessPage(IWebDriver driver) : base(driver)
        {
            CheckElements();
        }

        private void CheckElements()
        {
            // TODO Develop Custom Exception
            IWebElement temp = InfoMessage; // TODO All Web Elements
        }

        // Page Object

        // InfoMessage
        public string GetInfoMessageText()
        {
            return InfoMessage.Text;
        }

        // Functional

        // Business Logic
        //public SearchSuccessPage MakeCriteriaSearch(string searchText)
        //{
        //    ClickCriteriaSearchField();
        //    ClearCriteriaSearchField();
        //    SetCriteriaSearchField(searchText);
        //    ClickCriteriaSearchButton();
        //    return new SearchSuccessPage(driver);
        //}

        //public SearchSuccessPage MakeSearchBySeparateCategory(string searchText)
        //{
        //    ClickCriteriaCategory();
        //    SetCriteriaCategory(searchText);
        //    ClickCriteriaSearchField();
        //    ClearCriteriaSearchField();
        //    SetCriteriaSearchField(searchText);
        //    ClickCriteriaSearchButton();
        //    return new SearchSuccessPage(driver);
        //}

    }
}
