using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class BreadCrumPart : TopPart
    {
        public IWebElement BreadCrum
        { get { return driver.FindElement(By.CssSelector("ul.breadcrumb")); } }
        //private IList<IWebElement> links;

        public BreadCrumPart(IWebDriver driver) : base(driver)
        {
        }

        private void InitElements()
        {
            // TODO Develop Custom Exception
            IWebElement temp = BreadCrum; // TODO All Web Elements
            //links = new List<ProductComponent>();
            //foreach (IWebElement current in temp.FindElements(By.CssSelector(PRODUCT_COMPONENT_CSSSELECTOR)))
            //{
            //    productComponents.Add(new ProductComponent(current));
            //}
        }

        // Page Object

        // BreadCrum
        public string GetBreadCrumText()
        {
            return BreadCrum.Text;
        }

        public void ClickBreadCrum(string name) // TODO Develop Enum, List<WebElement>, Check
        {
            // $x("//ul[@class='breadcrumb']//a[text()='Search']")
            BreadCrum.FindElement(By.XPath(".//a[text()='"+ name + "']"));
        }

        // Functional

        // Business Logic

        public SearchSuccessPage GotoBreadCrumSearchSuccessPage()
        {
            ClickBreadCrum("Search");
            return new SearchSuccessPage(driver);
        }

        public SearchUnsuccessPage GotoBreadCrumSearchUnsuccessPage()
        {
            ClickBreadCrum("Search");
            return new SearchUnsuccessPage(driver);
        }

    }
}
