using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCart414Test
{
    [TestFixture]
    public class SeleniumSecond
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
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            Thread.Sleep(1000); // BAD Practic, don't use.
        }

        [TearDown]
        public void TearDown()
        {
            // Return to previous state
            // Check if Loggined and logout driver.Navigate().GoToUrl(".../logout");
        }

        [Test]
        public void TheFirstTest()
        {
            // Test Steps
            driver.FindElement(By.Name("q")).Clear();
            driver.FindElement(By.Name("q")).SendKeys("Selenium" + Keys.Enter);
            Thread.Sleep(1000); // BAD Practic
            //
            //driver.FindElement(By.Name("btnK")).Click();
            //Thread.Sleep(1000); // BAD Practic
            //
            //driver.FindElement(By.LinkText("Selenium - Web Browser Automation")).Click();
            driver.FindElement(By.PartialLinkText("Web Browser Automation")).Click();
            Thread.Sleep(1000); // BAD Practic
            //
            driver.FindElement(By.LinkText("Download")).Click();
            //
            // Check
            IWebElement actual = driver.FindElement(By.CssSelector("a[name='selenium_ide'] > p"));
            Assert.AreEqual("Selenium I1DE is a Chrome and Firefox plugin which records and plays back user interactions with the browser. Use this to either create simple scripts or assist in exploratory testing.",
                actual.Text);
            Thread.Sleep(1000); // BAD Practic
            //
        }
    }
}
