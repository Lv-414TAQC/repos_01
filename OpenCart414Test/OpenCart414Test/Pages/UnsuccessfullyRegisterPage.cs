using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
     public class UnsuccessfullyRegisterPage : RegisterUserPage
    {
        public const string Expected_Warning_First_Name = "First Name must be between 1 and 32 characters!";
        public static readonly string Expected_Warning_Last_Name = "Last Name must be between 1 and 32 characters!";
        public static readonly string Expected_Warning_Email = "E-Mail Address does not appear to be valid!";
        public static readonly string Expected_Warning_Telephone = "Telephone must be between 3 and 32 characters!";
        public static readonly string Expected_Warning_Address1 = "Address 1 must be between 3 and 128 characters!";
        public static readonly string Expected_Warning_City = "City must be between 2 and 128 characters!";
        public static readonly string Expected_Warning_Region = "Please select a region / state!";
        public static readonly string Expected_Warning_Password = "Password must be between 4 and 20 characters!";

        public IWebElement ActualFirstNameError
        { get { return driver.FindElement(By.CssSelector("#account "+ "> div:nth-child(3) > div > div")); } }
        public IWebElement ActualLastNameError
        { get { return driver.FindElement(By.CssSelector("#account " + "> div:nth-child(4) > div > div")); } }
        public IWebElement ActualEMailError
        { get { return driver.FindElement(By.CssSelector("#account " + "> div:nth-child(5) > div > div")); } }
        public IWebElement ActualTelephoneError
        { get { return driver.FindElement(By.CssSelector("#account " + "> div:nth-child(6) > div > div")); } }
        public IWebElement ActualAddress1Error
        { get { return driver.FindElement(By.CssSelector("#address > div:nth-child(3) > div > div")); } }
        public IWebElement ActualCityError
        { get { return driver.FindElement(By.CssSelector("#address " + "> div:nth-child(5) > div > div")); } }
        public IWebElement ActualRegionError
        { get { return driver.FindElement(By.CssSelector("#address" + " > div:nth-child(8) > div > div")); ; } }
        public IWebElement ActualPasswordError
        { get { return driver.FindElement(By.CssSelector("#content >" + " form > fieldset:nth-child(3) >"
                + " div.form-group.required.has-error >"
                + " div > div")); } }

        public UnsuccessfullyRegisterPage(IWebDriver driver) : base(driver)
        {

        }
        //Actual First Namee error
        public string GetActualFirstNameError()
        {
            return ActualFirstNameError.Text;
        }

       // Actual Last Name Error
        public string GetActualLastNameError()
        {
            return ActualLastNameError.Text;
        }

        
        public string GetActualEmailError()
        {
            return ActualEMailError.Text;
        }

        public string GetActualTelephoneError()
        {
            return ActualTelephoneError.Text;
        }

        public string GetActualAddressError()
        {
            return ActualAddress1Error.Text;
        }

        public string GetActualCityError()
        {
            return ActualCityError.Text;
        }

       
        public string GetActualRegionError()
        {
            return ActualRegionError.Text;
        }

        public string GetActualPasswordError()
        {
            return ActualPasswordError.Text;
        }

        public string GetActualPolicyErrorText()
        {
            return driver.FindElement(By.CssSelector("div[class*='alert']")).Text;
        }

    }
}
