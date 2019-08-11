using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class ChangePasswordPage : RightLoginPart
    {
        public IWebElement PasswordField
        { get { return driver.FindElement(By.Id("input-password")); } }
        public IWebElement PasswordConfirmField
        { get { return driver.FindElement(By.Id("input-confirm")); } }
        public IWebElement BackButton
        { get { return driver.FindElement(By.CssSelector("input.btn.btn-primary")); } }
        public IWebElement ContinueButton
        { get { return driver.FindElement(By.LinkText("Back")); } }
        public ChangePasswordPage(IWebDriver driver) : base(driver)
        {

        }
        // Password Field
        public string GetRegisterPasswordFieldText()
        {
            return PasswordField.GetAttribute(TAG_ATTRIBUTE_VALUE);
        }

        public void SetRegisterPasswordField(string text)
        {
            PasswordField.SendKeys(text);
        }

        public void ClearRegisterPasswordField()
        {
            PasswordField.Clear();
        }

        public void ClickRegisterPasswordField()
        {
            PasswordField.Click();
        }
        // PasswordConfim Field
        public string GetRegisterPasswordConfirmFieldText()
        {
            return PasswordConfirmField.GetAttribute(TAG_ATTRIBUTE_VALUE);
        }

        public void SetRegisterPasswordConfirmField(string text)
        {
            PasswordConfirmField.SendKeys(text);
        }

        public void ClearRegisterPasswordConfirmField()
        {
            PasswordConfirmField.Clear();
        }

        public void ClickRegisterPasswordConfirmField()
        {
            PasswordConfirmField.Click();
        }
        // BackButton
        public void ClickBackButton()
        {
            BackButton.Click();
        }
        // ContinueButton
        public void ClickContinueButton()
        {
            ContinueButton.Click();
        }

        //Functional

        public void SetNewPassword(string password)
        {
            ClickRegisterPasswordField();
            SetRegisterPasswordField(password);
        }
        public void ConfirmNewPassword(string password)
        {
            ClickRegisterPasswordConfirmField();
            SetRegisterPasswordConfirmField(password);
        }

        // Business Logic
        public AccountPage ChangePassword(string password)
        {
            SetNewPassword(password);
            ConfirmNewPassword(password);
            ClickContinueButton();
            return new AccountPage(driver);
        }
    }
}
