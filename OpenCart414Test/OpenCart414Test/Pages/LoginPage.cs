using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class LoginPage : RightLogoutPart
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        // Page Object

        // Functional
        public AccountPage LoggingIn(string email, string passWord)
        {
            string testerPassword = Environment.GetEnvironmentVariable(passWord);
            IWebElement listUpperRight = driver.FindElement(By.ClassName("list-inline"));
            listUpperRight.FindElement(By.ClassName("dropdown-toggle")).Click();
            listUpperRight.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys(email);
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys(testerPassword);
            driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
            GotoHomePage();
            return new AccountPage(driver);
        }
        // Business Logic
    }
}
