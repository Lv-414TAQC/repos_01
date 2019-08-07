using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class DropdownComponent
    {
        private IWebDriver driver;
        //
        public IList<IWebElement> ListOptions
        { get; private set; }

        public DropdownComponent(IWebDriver driver, By searchLocator)
        {
            this.driver = driver;
            InitListOptions(searchLocator);
        }

        private void InitListOptions(By searchLocator)
        {
            ListOptions = driver.FindElements(searchLocator);
            // ListOptions = search.GetWebElements(searchLocator); // for Strategy
        }

        // Page Object

        // ListOptions

        // Functional

        // ListOptions
        public IWebElement getDropdownOptionByPartialName(string optionName)
        {
            IWebElement result = null;
            foreach (IWebElement current in ListOptions)
            {
                if (current.Text.ToLower().Contains(optionName.ToLower()))
                {
                    result = current;
                    break;
                }
            }
            if (result == null)
            {
                // TODO Develop Custom Exception 
                throw new Exception("OptionName not Found.");
            }
            return result;
        }

        public IList<string> GetListOptionsText()
        {
            IList<string> result = new List<string>();
            foreach (IWebElement current in ListOptions)
            {
                result.Add(current.Text);
            }
            return result;
        }

        public bool IsExistDropdownOptionByPartialName(string optionName)
        {
            bool isFound = false;
            foreach (string current in GetListOptionsText())
            {
                if (current.ToLower().Contains(optionName.ToLower()))
                {
                    isFound = true;
                }
            }
            return isFound;
        }

        public void ClickDropdownOptionByPartialName(string optionName)
        {
            getDropdownOptionByPartialName(optionName).Click();
        }

        // Business Logic
    }
}
