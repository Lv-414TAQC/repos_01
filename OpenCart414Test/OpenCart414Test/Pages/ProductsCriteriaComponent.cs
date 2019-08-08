using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class ProductsCriteriaComponent : ProductsContainerComponent
    {
        public IWebElement ListViewButton
        { get { return driver.FindElement(By.Id("list-view")); } }
        public IWebElement GridViewButton
        { get { return driver.FindElement(By.Id("grid-view")); } }
        //TODO ProductCompare
        public SelectElement InputSort
        { get { return new SelectElement(driver.FindElement(By.Id("input-sort"))); } }
        public SelectElement InputLimit
        { get { return new SelectElement(driver.FindElement(By.Id("input-limit"))); } }
        public ProductsContainerComponent ProductsContainer
        { get; private set; }
        // TODO Pagination

        public ProductsCriteriaComponent(IWebDriver driver) : base(driver)
        {
            CheckElements();
            InitElements();
        }

        private void CheckElements()
        {
            // TODO Develop Custom Exception
            //IWebElement temp = CriteriaSearchField; // TODO All Web Elements
        }

        private void InitElements()
        {
            ProductsContainer = new ProductsContainerComponent(driver);
        }

        // Page Object

        // ListViewButton
        public void ClickListViewButton()
        {
            ListViewButton.Click();
        }

        // GridViewButton
        public void ClickGridViewButton()
        {
            GridViewButton.Click();
        }

        // ProductCompare

        // InputSort
        public IWebElement GetInputSortIWebElement()
        {
            return InputSort.WrappedElement;
        }

        public string GetInputSortText()
        {
            return InputSort.SelectedOption.Text;
        }

        public void SetInputSort(string text)
        {
            InputSort.SelectByText(text);
            Thread.Sleep(2000); // for presentation only
        }

        public void ClickInputSort()
        {
            GetInputSortIWebElement().Click();
        }

        // InputLimit
        public IWebElement GetInputLimitIWebElement()
        {
            return InputLimit.WrappedElement;
        }

        public string GetInputLimitText()
        {
         return InputLimit.SelectedOption.Text;
}

        public void SetInputLimit(string text)
        {
            InputLimit.SelectByText(text);
        }

        public void ClickInputLimit()
        {
            GetInputLimitIWebElement().Click();
        }

        // ProductsContainer

        // Pagination

        // Functional

        // Business Logic
        public SearchSuccessPage SetSortLowHigh()
        {
            SetInputSort("Price (Low > High)");
            return new SearchSuccessPage(driver);
        }
        public ProductsCriteriaComponent ViewProductsByList()
        {
            ClickListViewButton();
            InitElements();
            return this;
        }

        public ProductsCriteriaComponent ViewProductsByGrid()
        {
            ClickGridViewButton();
            InitElements();
            return this;
        }

    }
}
