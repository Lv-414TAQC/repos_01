using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCart414Test.Tests
{
    [TestFixture]
    class SimpleRegistationTest
    {
        private IWebDriver driver;
        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            //IWebDriver driver = new FirefoxDriver();
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            //driver.Close();
            driver.Quit();
        }
        [SetUp]
        public void SetUp()
        {
            // Precondition
            // Goto Application Start Page
            driver.Navigate().GoToUrl("http://172.20.10.2/opencart/upload/");
            Thread.Sleep(1000); // BAD Practic, don't use.
        }
        [TearDown]
        public void TearDown()
        {
        }
        [Test]
        public void TheFirstTest()
        {
            driver.FindElement(By.CssSelector(".list-inline > li > a.dropdown-toggle")).Click();
            driver.FindElement(By.CssSelector("#top-links > ul > li.dropdown.open > ul > li:nth-child(1) > a")).Click();
            //First Name input
            driver.FindElement(By.Id("input-firstname")).Click();
            driver.FindElement(By.Id("input-firstname")).Clear();
            driver.FindElement(By.Id("input-firstname")).SendKeys("Meowy");
            //Last name input
            driver.FindElement(By.Id("input-lastname")).Click();
            driver.FindElement(By.Id("input-lastname")).Clear();
            driver.FindElement(By.Id("input-lastname")).SendKeys("Woohoo");
            //Email input
            driver.FindElement(By.Id("input-email")).Click();
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("Donald@mgail.com");
            //Telephone
            driver.FindElement(By.Id("input-telephone")).Click();
            driver.FindElement(By.Id("input-telephone")).Clear();
            driver.FindElement(By.Id("input-telephone")).SendKeys("3805959594");
            //Address
            driver.FindElement(By.Id("input-address-1")).Click();
            driver.FindElement(By.Id("input-address-1")).Clear();
            driver.FindElement(By.Id("input-address-1")).SendKeys("Richardsa"); ;
            //City
            driver.FindElement(By.Id("input-city")).Click();
            driver.FindElement(By.Id("input-city")).Clear();
            driver.FindElement(By.Id("input-city")).SendKeys("Dream");
            //Post Code
            driver.FindElement(By.Id("input-postcode")).Click();
            driver.FindElement(By.Id("input-postcode")).Clear();
            driver.FindElement(By.Id("input-postcode")).SendKeys("322");
            //Country select
            driver.FindElement(By.Id("input-country")).Click();
            driver.FindElement(By.Id("input-country")).SendKeys("Denmark");
            //City select
            driver.FindElement(By.Id("input-zone")).Click();
            driver.FindElement(By.Id("input-zone")).SendKeys("Fyn");
            //password
            driver.FindElement(By.Id("input-password")).Click();
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("Password");
            //password confirm
            driver.FindElement(By.Id("input-confirm")).Click();
            driver.FindElement(By.Id("input-confirm")).Clear();
            driver.FindElement(By.Id("input-confirm")).SendKeys("Password");
            //Privacy Agreement button
            driver.FindElement(By.CssSelector("input[type=checkbox]")).Click();
            //Continue button
            driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
    }
    }
}