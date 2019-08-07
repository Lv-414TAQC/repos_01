using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class SearchCriteriaPart : BreadCrumPart
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
        { get { return driver.FindElement(By.Id("description")); } }

        public SearchCriteriaPart(IWebDriver driver) : base(driver)
        {
            CheckElements();
        }

        private void CheckElements()
        {
            // TODO Develop Custom Exception
            IWebElement temp = CriteriaSearchField; // TODO All Web Elements
        }

        // Page Object TestCommitOne

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
            {x`
                // TODO Develop Custom Exception
                throw new Exception("Error, CriteriaSubCategory had disabled");
            }
            CriteriaSubCategory.Click();
        }

        public void ClickCriteriaSubCategory(string subcategory)
        {
            SetCriteriaCategory(subcategory);
            ClickCriteriaSubCategory(); // TODO for first
        }

        // CriteriaDescription
        public void ClickCriteriaDescription()
        {
            CriteriaDescription.Click();
        }

        // CriteriaSearchButton
        public void ClickCriteriaSearchButton()
        {
            CriteriaSearchButton.Click();
        }

        // Functional
        // TODO Choose/Click WebElements
        //protected void MakeCriteriaSearch(SearchCriteria searchCriteria...)

        // Business Logic

        //public SearchSuccessPage SearchSuccessfully(SearchCriteria searchCriteria Product string searchText)
        //public SearchUnsuccessPage SearchUnsuccessfully(SearchCriteria searchCriteria Product string searchText) // TODO
    }
}
