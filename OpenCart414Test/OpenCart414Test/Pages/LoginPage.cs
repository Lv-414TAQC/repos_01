using OpenCart414Test.Data;
using OpenQA.Selenium;

namespace OpenCart414Test.Pages
{
    public class LoginPage : RightLogoutPart
    {
        public IWebElement EmailInputField =>
        driver.FindElement(By.Id("input-email"));
        public IWebElement PasswordInputField =>
        driver.FindElement(By.Id("input-password"));
        public IWebElement LoginButton =>
        driver.FindElement(By.CssSelector("input.btn.btn-primary"));

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        // Atomic
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
        //My version (Ferid)
        protected void FillLoginForm(IUser user)
        {
            InputEmail(user.Email);
            InputPassword(user.Password);          
            ClickLoginButton();
        }

        // Business Logic
        public AccountPage LoggingIn(string email, string passWord)
        {
            InputEmail(email);
            InputPassword(passWord);
            ClickLoginButton();
            return new AccountPage(driver);
        }

        //My version(Ferid)
        public AccountPage SuccessLogin(IUser user)
        {
            FillLoginForm(user);
            return new AccountPage(driver);
        }
    }
}
