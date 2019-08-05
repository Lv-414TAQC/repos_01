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
        public SearchUnsuccessPage(IWebDriver driver) : base(driver)
        {
            CheckElements();
        }

        private void CheckElements()
        {
            // TODO Develop Custom Exception
            //IWebElement temp = CriteriaSearchField; // TODO All Web Elements
        }
    }
}
