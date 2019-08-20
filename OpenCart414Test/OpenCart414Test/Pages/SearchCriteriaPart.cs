using OpenCart414Test.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class SearchCriteriaPart : BreadCrumbsPart
    {

        public IWebElement CriteriaSearchField
        { get { return driver.FindElement(By.Id("input-search")); } }
        public SelectElement CriteriaCategory
        { get { return new SelectElement(driver.FindElement(By.Name("category_id"))); } }
        public IWebElement CriteriaSubCategory
        { get { return driver.FindElement(By.Name("sub_category")); } }
        public IWebElement CriteriaDescription
        { get { return driver.FindElement(By.Id("description")); } }
        public IWebElement CriteriaSearchButton
        { get { return driver.FindElement(By.Id("button-search")); } }

        public SearchCriteriaPart(IWebDriver driver) : base(driver)
        {
            CheckElements();
        }
         
        public void CheckElements()
        {
            // Develop Custom Exception
            IWebElement temp = CriteriaSearchField;
            SelectElement tempS = CriteriaCategory;
            temp = CriteriaSubCategory;
            temp = CriteriaDescription;
            temp = CriteriaSearchButton;          
        }
        // Page Object
        // CriteriaSearchField
        public string GetCriteriaSearchFieldText()
        {
            return CriteriaSearchField.GetAttribute(TAG_ATTRIBUTE_VALUE);
        }

        public void SetCriteriaSearchField(string text)
        {
            CriteriaSearchField.SendKeys(text);
        }

        public void ClearCriteriaSearchField()
        {
            CriteriaSearchField.Clear();
        }

        public void ClickCriteriaSearchField()
        {
            CriteriaSearchField.Click();
        }
        // CriteriaCategory
        public IWebElement GetCriteriaCategoryIWebElement()
        {
            return CriteriaCategory.WrappedElement;
        }

        public string GetCriteriaCategoryText()
        {
            return CriteriaCategory.SelectedOption.Text;
        }

        public void SetCriteriaCategory(string text)
        {
            CriteriaCategory.SelectByText(text);
        }

        public void ClickCriteriaCategory()
        {
            GetCriteriaCategoryIWebElement().Click();
        }
        // CriteriaSubCategory
        public void ClickCriteriaSubCategory()
        {
            if (!CriteriaSubCategory.Enabled)
            {
                //Develop Custom Exception
                throw new Exception("Error, CriteriaSubCategory had disabled");
            }
            CriteriaSubCategory.Click();
        }

        public void ClickCriteriaSubCategory(bool temp)
        {
            if (!temp == true)
            {
                Console.WriteLine("eror");
            }
            else
            {
                ClickCriteriaSubCategory();
            }
        }
        // CriteriaDescription
        public void ClickCriteriaDescription()
        {
            CriteriaDescription.Click();
        }

        public void GetCriteriaDescription(bool temp)
        {
            if (!temp == true)
            {
                Console.WriteLine("eror");
            }
            else
            {
                ClickCriteriaDescription();
            }
            
        }
        // CriteriaSearchButton
        public void ClickCriteriaSearchButton()
        {
            CriteriaSearchButton.Click();
        }

        // Functional
        protected void MakeCriteriaSearchByDefault(string searchText)
        {
            ClickCriteriaSearchField();
            ClearCriteriaSearchField();
            SetCriteriaSearchField(searchText);
            ClickCriteriaSearchButton();
        }

        protected void MakeCriteriaSearchByCategory(string searchText, string searchCategory)
        {
            ClickCriteriaSearchField();
            ClearCriteriaSearchField();
            SetCriteriaSearchField(searchText);
            ClickCriteriaCategory();
            SetCriteriaCategory(searchCategory);
            ClickCriteriaSearchButton();
        }

        protected void MakeCriteriaSearchByDescription(string searchText, string searchCategory, bool IsSearchInDescription)
        {
            ClickCriteriaSearchField();
            ClearCriteriaSearchField();
            SetCriteriaSearchField(searchText);
            ClickCriteriaCategory();
            SetCriteriaCategory(searchCategory);
            GetCriteriaDescription(IsSearchInDescription);
            ClickCriteriaSearchButton();
        }

        protected void MakeCriteriaSearchBySubCategory(string searchText, string searchCategory, bool isSearchInSubcategories)
        {
            ClickCriteriaSearchField();
            ClearCriteriaSearchField();
            SetCriteriaSearchField(searchText);
            ClickCriteriaCategory();
            SetCriteriaCategory(searchCategory);
            ClickCriteriaSubCategory(isSearchInSubcategories);
            ClickCriteriaSearchButton();
        }

        // Business Logic

        public SearchSuccessPage SearchSuccessfullyByDefault(SearchCriteria searchCriteria)
        {
            MakeCriteriaSearchByDefault(searchCriteria.SearchValue);
            return new SearchSuccessPage(driver);
        }    

        public SearchSuccessPage SearchSuccessfullyByCategory(SearchCriteria searchCriteria)
        {
            MakeCriteriaSearchByCategory(searchCriteria.SearchValue, searchCriteria.SearchCategory);
            return new SearchSuccessPage(driver);
        }

        public SearchSuccessPage SearchSuccessfullyByDescription(SearchCriteria searchCriteria)
        {
            MakeCriteriaSearchByDescription(searchCriteria.SearchValue, searchCriteria.SearchCategory,searchCriteria.IsSearchInDescription);
            return new SearchSuccessPage(driver);
        }

        public SearchSuccessPage SearchSuccessfullyBySubCategory(SearchCriteria searchCriteria)
        {
            MakeCriteriaSearchBySubCategory(searchCriteria.SearchValue, searchCriteria.SearchCategory,searchCriteria.IsSearchInSubcategories);
            return new SearchSuccessPage(driver);
        }
    }
}
