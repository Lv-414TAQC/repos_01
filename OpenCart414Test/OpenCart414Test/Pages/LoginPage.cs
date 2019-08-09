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
        public IWebElement EmailInputField
        { get { return driver.FindElement(By.Id("input-email")); } }
        public IWebElement PasswordInputField
        { get { return driver.FindElement(By.Id("input-password")); } }
        public IWebElement LoginButton
        { get { return driver.FindElement(By.CssSelector("input.btn.btn-primary")); } }
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        // Page Object

        // Functional
        public void InputEmail(string email)
        {
            EmailInputField.Clear();
            EmailInputField.SendKeys(email);
        }
        public void InputPassword(string passWord)
        {
            PasswordInputField.Clear();
            PasswordInputField.SendKeys(passWord);
        }
        // Business Logic
        public AccountPage LoggingIn(string email, string passWord)
        {
            string testerPassword = Environment.GetEnvironmentVariable(passWord);
            InputEmail(email);
            InputPassword(testerPassword);
            LoginButton.Click();
            return new AccountPage(driver);
        }
    }
}
