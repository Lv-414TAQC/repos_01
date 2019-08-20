using System;
using OpenQA.Selenium;

namespace OpenCart414Test.Pages
{
    public class CartEmptyContainerComponent
    {
        private IWebDriver driver;

        public IWebElement InfoMessage =>
        driver.FindElement(By.CssSelector("li p.text-center"));

        public CartEmptyContainerComponent(IWebDriver driver)
        {
            this.driver = driver;
            CheckElements();
        }

        private void CheckElements()
        {
            try
            { 
                IWebElement temp = InfoMessage;
            }
            catch(Exception)
            {
                throw new Exception("Custom exception: CheckElements()");
            }
        }

        // Page Object

        // InfoMessage
        public string GetInfoMessageText()
        {
            return InfoMessage.Text;
        }

        // Functional

        // Business Logic
    }
}
