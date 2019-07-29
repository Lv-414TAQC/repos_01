using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace OpencartWishlistTests
{
    [TestFixture]
    public class OpencartWishlistAdd
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        
        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            //driver = new FirefoxDriver();
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
        public void SetupTest()
        {
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheOpencartWishlistAddTest()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://192.168.20.128/opencart/upload/");
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("My Account")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Login")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("input-email")).Clear();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("input-email")).SendKeys("roman_my@ukr.net");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("input-password")).Clear();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("input-password")).SendKeys("performingtesting");
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Desktops")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Show All Desktops")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("(//button[@type='button'])[22]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("wish list")).Click();
            Thread.Sleep(2000);
            Assert.AreEqual("iPhone", driver.FindElement(By.LinkText("iPhone")).Text);
            Thread.Sleep(2000);
            Assert.AreEqual("product 11", driver.FindElement(By.CssSelector("tbody .text-left:nth-child(3)")).Text);
            Thread.Sleep(2000);
            Assert.AreEqual("In Stock", driver.FindElement(By.CssSelector("tbody .text-right:nth-child(4)")).Text);
            Thread.Sleep(2000);
            Assert.AreEqual("$101.00", driver.FindElement(By.CssSelector(".price")).Text);
            Thread.Sleep(2000);
        }
    }
}
