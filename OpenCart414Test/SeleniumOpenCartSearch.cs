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
    class SeleniumOpenCartSearch
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
            driver.Navigate().GoToUrl("http://10.26.34.230/opencart/upload/");
            Thread.Sleep(1000); // BAD Practic, don't use.
        }

        [TearDown]
        public void TearDown()
        {
            // Return to previous state
            // Check if Loggined and logout driver.Navigate().GoToUrl(".../logout");
        }

        //[Test]
        public void TheFirstTest()
        {
            // Test Steps
            // Search Field
            driver.FindElement(By.CssSelector("#search input")).Clear();
            driver.FindElement(By.CssSelector("#search input")).SendKeys("mac");
            Thread.Sleep(1000); // BAD Practic
            Console.WriteLine("Search Field DONE");
            //
            // Click Button
            driver.FindElement(By.CssSelector(".btn.btn-default.btn-lg")).Click();
            Thread.Sleep(1000); // BAD Practic
            Console.WriteLine("Button DONE");
            //
            // Search Block
            // $("div.caption:has(> p:contains('Intel Core 2 Duo processor'))")
            // Search Price
            // $("div.caption > p:contains('Intel Core 2 Duo processor') + p")
            IWebElement currentSearch = driver.FindElement(By.CssSelector("div.caption > p:contains(\"Intel Core 2 Duo processor\") + p"));
            Thread.Sleep(1000); // BAD Practic
            Console.WriteLine("Search Price DONE");
            String allPrice = currentSearch.Text;
            Console.WriteLine("allPrice = " + allPrice);
            //
            // Get Price
            int position = allPrice.IndexOf("$");
            String price = allPrice.Substring(position + 1, 6);
            Console.WriteLine("price = " + price);
            // 
            // Check
            //Assert.AreEqual("", price);
            Thread.Sleep(1000); // BAD Practic
            //
        }

        [Test]
        public void TheFirstXPathTest()
        {
            // Test Steps
            // Search Field
            driver.FindElement(By.XPath("//input[@name='search']")).Clear();
            driver.FindElement(By.XPath("//input[@name='search']")).SendKeys("mac");
            Thread.Sleep(1000); // BAD Practic
            Console.WriteLine("Search Field DONE");
            //
            // Click Button
            driver.FindElement(By.XPath("//button[@class='btn btn-default btn-lg']")).Click();
            Thread.Sleep(1000); // BAD Practic
            Console.WriteLine("Button DONE");
            //
            // Search Block
            // $("div.caption:has(> p:contains('Intel Core 2 Duo processor'))")
            // Search Price
            // $("div.caption > p:contains('Intel Core 2 Duo processor') + p")
            // $x("//div[contains(@class, 'product-layout')]//h4/a[contains(text(),'iPhone')]/../../following-sibling::div/button[contains(@onclick,'cart')]")
            // $x("//a[text()='MacBook']/../following-sibling::p[@class]")
            //
            //IWebElement currentSearch = driver.FindElement(By.XPath("//a[text()='MacBook']/../following-sibling::p[@class]"));
            //
            // $x("//div[contains(@class, 'product-layout')]")
            // $x("//div[contains(@class, 'product-layout')]//a[text()='MacBook']")
            // $x("//div[contains(@class, 'product-layout')]//a[text()='MacBook']/../../../../..")
            IWebElement macBookContainer = driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]//a[text()='MacBook']/../../../../.."));
            IWebElement currentSearch = macBookContainer.FindElement(By.XPath(".//p[@class]"));
            Thread.Sleep(1000); // BAD Practic
            macBookContainer.FindElement(By.XPath(".//button[contains(@onclick, 'cart')]")).Click();
            Thread.Sleep(1000); // BAD Practic
            //
            Thread.Sleep(1000); // BAD Practic
            Console.WriteLine("Search Price DONE");
            String allPrice = currentSearch.Text;
            Console.WriteLine("allPrice = " + allPrice);
            //
            // Get Price
            int position = allPrice.IndexOf("$");
            String price = allPrice.Substring(position + 1, 6);
            Console.WriteLine("price = " + price);
            // 
            // Check
            //Assert.AreEqual("", price);
            Thread.Sleep(4000); // BAD Practic
            //
        }
    }
}
