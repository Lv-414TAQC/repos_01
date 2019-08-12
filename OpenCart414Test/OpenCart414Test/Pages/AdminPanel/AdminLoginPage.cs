using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCart414Test.Pages.AdminPanel
{
    public class AdminLoginPage
    {
        protected IWebDriver driver;
        public static readonly string AdminName = Environment.GetEnvironmentVariable("ADMIN_NAME");
        public static readonly string AdminPassword = Environment.GetEnvironmentVariable("ADMIN_PASSWORD");
        public IWebElement Logo { get { return driver.FindElement(By.CssSelector("#header a")); } }
        public IWebElement UserNameInput { get { return driver.FindElement(By.Id("input-username")); } }
        public IWebElement PasswordInput { get { return driver.FindElement(By.Id("input-password")); } }
        public IWebElement LoginButton { get { return driver.FindElement(By.CssSelector("button")); } }

        public AdminLoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClearUserNameInput()
        {
            UserNameInput.Clear();
        }

        public void EnterUserName(string name)
        {
            ClearUserNameInput();
            UserNameInput.SendKeys(name);
        }

        public void ClearPasswordInput()
        {
            PasswordInput.Clear();
        }

        public void EnterPassword(string password)
        {
            ClearPasswordInput();
            PasswordInput.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public AdminHomePage LogInAdmin()
        {
            EnterUserName(AdminName);
            EnterPassword(AdminLoginPage.AdminPassword);
            ClickLoginButton();
            return new AdminHomePage(driver);

        }
    }
}

