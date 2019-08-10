using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace OpenCart414Test.Pages
{
    class SelectShippingMethodComponent
    {
        IWebDriver driver;
        IWebElement radioButton { get { return driver.FindElement(By.Name("shipping_method")); } }
        string label { get { return driver.FindElement(By.CssSelector(".modal-content .radio label")).Text; } }
        IWebElement applyButton { get { return driver.FindElement(By.Id("button-shipping")); } }
        IWebElement cancelButton { get { return driver.FindElement(By.CssSelector(".modal-content .btn.btn-default")); } }

        public SelectShippingMethodComponent(IWebDriver driver)
        {    
            this.driver = driver;
        }

        void SelectRadioButton()
        {
            radioButton.Click();
        }

        void ClickApplyButton()
        {
            applyButton.Click();
        }

        public void ClickCancelButton()
        {
            cancelButton.Click();
        }

        public void ApllyShippingMethod()
        {
            SelectRadioButton();
            ClickApplyButton();
        }
    }
}
