using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    class WishListComponentContainer
    {
        protected IWebDriver driver;

        public IWebElement TableHeadImage
        { get { return driver.FindElement(By.XPath("//td[text()='Image']")); } }
        public IWebElement TableHeadProductName
        { get { return driver.FindElement(By.XPath("//td[text()='Product Name']")); } }
        public IWebElement TableHeadModel
        { get { return driver.FindElement(By.XPath("//td[text()='Model']")); } }
        public IWebElement TableHeadStock
        { get { return driver.FindElement(By.XPath("//td[text()='Stock']")); } }
        public IWebElement TableHeadUnitPrice
        { get { return driver.FindElement(By.XPath("//td[text()='Unit Price']")); } }
        public IWebElement TableHeadAction
        { get { return driver.FindElement(By.XPath("//td[text()='Action']")); } }

        public IList<WishListComponent> TableRows;
    }
}
