using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class RegisterUserPage : RightLogoutPart
    {
        public IWebElement FirstNameField
        { get { return driver.FindElement(By.Id("input-firstname")); } }
        public IWebElement LastNameField
        { get { return driver.FindElement(By.Id("input-lastname")); } }
        public IWebElement EMailField
        { get { return driver.FindElement(By.Id("input-email")); } }
        public IWebElement TelephoneField
        { get { return driver.FindElement(By.Id("input-telephone")); } }
        public IWebElement Address1Field
        { get { return driver.FindElement(By.Id("input-address-1")); } }
        public IWebElement CityField
        { get { return driver.FindElement(By.Id("input-city")); } }
        public IWebElement PostCodeField
        { get { return driver.FindElement(By.Id("input-postcode")); } }
        public SelectElement CountryCategory
        { get { return new SelectElement(driver.FindElement(By.Id("input-country"))); } }
        // Region after Country(?)
        public SelectElement RegionCategory
        { get { return new SelectElement(driver.FindElement(By.Id("input-zone"))); } }
        public IWebElement PasswordField
        { get { return driver.FindElement(By.Id("input-password")); } }
        public IWebElement PasswordConfirmField
        { get { return driver.FindElement(By.Id("input-confirm")); } }
        public IWebElement PrivacyAgreement
        { get { return driver.FindElement(By.CssSelector("input[type=checkbox]")); } }
        public IWebElement SubmitButton
        { get { return driver.FindElement(By.CssSelector("input.btn.btn-primary")); } }


        public RegisterUserPage(IWebDriver driver) :base(driver)
        {
            CheckElements();
        }

        private void CheckElements()
        {
            // TODO Develop Custom Exception
            IWebElement temp = FirstNameField, LastNameField, EMailField; //TODO
        }
        //First Name Field
        public string GetRegisterFirstNameFieldText()
        {
            return FirstNameField.GetAttribute(TAG_ATTRIBUTE_VALUE);
        }

        public void SetRegisterFirstNameField(string text)
        {
            FirstNameField.SendKeys(text);
        }

        public void ClearRegisterFirstNameField()
        {
            FirstNameField.Clear();
        }

        public void ClickRegisterFirstNameField()
        {
            FirstNameField.Click();
        }

        //Last Name Field
        public string GetRegisterLastNameFieldText()
        {
            return LastNameField.GetAttribute(TAG_ATTRIBUTE_VALUE);
        }

        public void SetRegisterLastNameField(string text)
        {
            LastNameField.SendKeys(text);
        }

        public void ClearRegisterLastNameField()
        {
            LastNameField.Clear();
        }

        public void ClickRegisterLastNameField()
        {
           LastNameField.Click();
        }

        // Email Field
        public string GetRegisterEmailFieldText()
        {
            return EMailField.GetAttribute(TAG_ATTRIBUTE_VALUE);
        }
        
        public void SetRegisterEmailField(string text)
        {
            EMailField.SendKeys(text);
        }

        public void ClearRegisterEmailField()
        {
            EMailField.Clear();
        }

        public void ClickRegisterEmailField()
        {
            EMailField.Click();
        }


        // Telephone Field
        public string GetRegisterTelephoneFieldText()
        {
            return TelephoneField.GetAttribute(TAG_ATTRIBUTE_VALUE);
        }

        public void SetRegisterTelephoneField(string text)
        {
            TelephoneField.SendKeys(text);
        }

        public void ClearRegisterTelephoneField()
        {
           TelephoneField.Clear();
        }

        public void ClickRegisterTelephoneField()
        {
            TelephoneField.Click();
        }

        // Address1 Field
        public string GetRegisterAddress1FieldText()
        {
            return Address1Field.GetAttribute(TAG_ATTRIBUTE_VALUE);
        }

        public void SetRegisterAddress1Field(string text)
        {
            Address1Field.SendKeys(text);
        }

        public void ClearRegisterAddress1Field()
        {
            Address1Field.Clear();
        }

        public void ClickRegisterAddress1Field()
        {
            Address1Field.Click();
        }

        //City Field
        public string GetRegisterCityFieldText()
        {
            return CityField.GetAttribute(TAG_ATTRIBUTE_VALUE);
        }

        public void SetRegisterCityField(string text)
        {
            CityField.SendKeys(text);
        }

        public void ClearRegisterCityField()
        {
            CityField.Clear();
        }

        public void ClickRegisterCityField()
        {
            CityField.Click();
        }

        //PostCodeField
        public string GetRegisterPostCodeFieldText()
        {
            return PostCodeField.GetAttribute(TAG_ATTRIBUTE_VALUE);
        }

        public void SetRegisterPostCodeField(string text)
        {
            PostCodeField.SendKeys(text);
        }

        public void ClearRegisterPostCodeField()
        {
            PostCodeField.Clear();
        }

        public void ClickRegisterPostCodeField()
        {
            PostCodeField.Click();
        }

        // CountryCategory
        public IWebElement GetCountryCategoryIWebElement()
        {
            return CountryCategory.WrappedElement;
        }

        public string GetCountryCategoryText()
        {
            return CountryCategory.SelectedOption.Text;
        }

        public void SetCountryCategory(string text)
        {
            CountryCategory.SelectByText(text);
        }

        public void ClickCountryCategory()
        {
            GetCountryCategoryIWebElement().Click();
        }

        // RegionCategory
        public IWebElement GetRegionCategoryIWebElement()
        {
            return RegionCategory.WrappedElement;
        }

        public string GetRegionCategoryText()
        {
            return RegionCategory.SelectedOption.Text;
        }

        public void SetRegionCategory(string text)
        {
            RegionCategory.SelectByText(text);
        }

        public void ClickRegionCategory()
        {
            GetRegionCategoryIWebElement().Click();
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

        // PrivacyAgreement
        public void ClickPrivacyAgreement()
        {
            PrivacyAgreement.Click();
        }

        // SubmitButton
        public void ClickSubmitButton()
        {
            SubmitButton.Click();
        }

        //Functional

        public void InitElements(string FirstNameField, string LastNameField,
            string Email,string Telephone,string Address1,string City,string PostCode,string Country,
            string Region,string Password,string ConfirmPassword)
        {
            ClearRegisterFirstNameField();
            SetRegisterFirstNameField(FirstNameField);
            ClearRegisterLastNameField();
            SetRegisterLastNameField(LastNameField);
            ClearRegisterEmailField();
            SetRegisterEmailField(Email);
            ClearRegisterTelephoneField();
            SetRegisterTelephoneField(Telephone);
            ClearRegisterAddress1Field();
            SetRegisterAddress1Field(Address1);
            ClearRegisterCityField();
            SetRegisterCityField(City);
            ClearRegisterPostCodeField();
            SetRegisterPostCodeField(PostCode);
            ClickCountryCategory();
            SetCountryCategory(Country);
            ClickRegionCategory();
            SetRegionCategory(Region);
            ClearRegisterPasswordField();
            SetRegisterPasswordField(Password);
            ClearRegisterPasswordConfirmField();
            SetRegisterPasswordConfirmField(ConfirmPassword);
            ClickPrivacyAgreement();
            ClickSubmitButton();
        }

    }
}
