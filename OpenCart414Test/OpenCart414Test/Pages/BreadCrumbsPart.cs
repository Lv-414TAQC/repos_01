using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class BreadCrumbsPart : TopPart
    {
        public IWebElement BreadCrumbs
        { get { return driver.FindElement(By.CssSelector("ul.breadcrumb")); } }
        //private IList<IWebElement> links;

        public BreadCrumbsPart(IWebDriver driver) : base(driver)
        {
        }

        private void InitElements()
        {
            // TODO Develop Custom Exception
            IWebElement temp = BreadCrumbs; // TODO All Web Elements
            //links = new List<ProductComponent>();
            //foreach (IWebElement current in temp.FindElements(By.CssSelector(PRODUCT_COMPONENT_CSSSELECTOR)))
            //{
            //    productComponents.Add(new ProductComponent(current));
            //}
        }

        // Page Object

        // BreadCrum
        public string GetBreadCrumbsText()
        {
            return BreadCrumbs.Text;
        }

        public void ClickBreadCrumbs(string name) // TODO Develop Enum, List<WebElement>, Check
        {
            // $x("//ul[@class='breadcrumb']//a[text()='Search']")
            BreadCrumbs.FindElement(By.XPath(".//a[text()='"+ name + "']"));
        }

        // Functional

        // Business Logic

        public SearchSuccessPage GotoBreadCrumbsSearchSuccessPage()
        {
            ClickBreadCrumbs("Search");
            return new SearchSuccessPage(driver);
        }

        public SearchUnsuccessPage GotoBreadCrumbsSearchUnsuccessPage()
        {
            ClickBreadCrumbs("Search");
            return new SearchUnsuccessPage(driver);
        }

    }
}
