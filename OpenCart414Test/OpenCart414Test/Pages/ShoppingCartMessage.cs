using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenCart414Test.Tools;

namespace OpenCart414Test.Pages
{
    

    public class ShoppingCartMessage : ShoppingCartPage
    {
        
        public IWebElement UpdateMess =>
        driver.FindElement(By.CssSelector("div.alert.alert-success")); 

        public ShoppingCartMessage(IWebDriver driver) : base(driver)
        {
          
        }

        //Page Object
        public string GetUpdateMessage()
        {
            return UpdateMess.Text;
        }

        //Business Logic
        public HomePage GoToHomePage()
        {
            ClickContinueShopping();
            return new HomePage(driver);
        }
       
        
    }
}
