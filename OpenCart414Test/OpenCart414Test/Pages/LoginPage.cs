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
        public void ClearEmailField()
        {
            EmailInputField.Clear();
        }
        public void TypeIntoEmailField(string email)
        {
            EmailInputField.SendKeys(email);
        }
        public void ClearPasswordField()
        {
            PasswordInputField.Clear();
        }
        public void TypeIntoPasswordField(string passWord)
        {
            PasswordInputField.SendKeys(passWord);
        }
        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        // Functional
        public void InputEmail(string email)
        {
            ClearEmailField();
            TypeIntoEmailField(email);
        }
        public void InputPassword(string passWord)
        {
            ClearPasswordField();
            TypeIntoPasswordField(passWord);
        }
        // Business Logic
        public AccountPage LoggingIn(string email, string passWord)
        {
            InputEmail(email);
            InputPassword(passWord);
            ClickLoginButton();
            return new AccountPage(driver);
        }
    }
}
