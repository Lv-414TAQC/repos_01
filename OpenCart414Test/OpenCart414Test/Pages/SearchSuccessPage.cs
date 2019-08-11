using OpenCart414Test.Data;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace OpenCart414Test.Pages
{
    public class SearchSuccessPage : SearchCriteriaPart
    {
        public ProductsCriteriaComponent ProductsCriteria { get; private set; }
        public SearchSuccessPage(IWebDriver driver) : base(driver)
        {
            CheckElements();
            InitElements();
        }

        private void CheckElements()
        {
            
        }

        private void InitElements()
        {
            ProductsCriteria = new ProductsCriteriaComponent(driver);
        }

        // Page Object

        // ProductsCriteria

        // Functional

        // Business Logic
        public SearchSuccessPage ChooseCurrency(Currency currency)
        {
            ClickCurrencyByPartialName(currency);
            return new SearchSuccessPage(driver);
        }

        public SearchSuccessPage SortProductsByCriteria(string text) // TODO Use Enum
        {
            ProductsCriteria.SetInputSort(text);
            return new SearchSuccessPage(driver);
        }

        public SearchSuccessPage ShowProductsByCount(string text) // TODO Use Enum
        {
            ProductsCriteria.SetInputLimit(text);
            return new SearchSuccessPage(driver);
        }
    }
}
