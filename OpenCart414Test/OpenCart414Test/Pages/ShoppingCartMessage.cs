using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace OpenCart414Test.Pages
{
    public class ShoppingCartMessage : ShoppingCartPage
    {
       
        public IWebElement UpdateMess
        { get { return driver.FindElement(By.CssSelector("div.alert.alert-success")); } }
        public ShoppingCartMessage(IWebDriver driver) : base(driver)
        {
          
        }

        public string GetUpdateMessage()
        {
            return UpdateMess.Text;
        }

        // Business Logic
        
    }
}
