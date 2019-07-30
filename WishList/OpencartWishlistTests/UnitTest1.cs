using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace OpencartWishlistTests
{
    [TestFixture]
    public class OpencartWishlistAdd
    {
        private IWebDriver driver;
        
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
            driver.Quit();
        }

        [SetUp]
        public void SetupTest()
        {
            driver.Navigate().GoToUrl("http://192.168.20.128/opencart/upload/");
        }

        [TearDown]
        public void TeardownTest()
        {   
        }

        [Test]
        public void TheOpencartWishlistAddTest()
        {
            IWebElement select1 = driver.FindElement(By.ClassName("list-inline"));
            select1.FindElement(By.ClassName("dropdown-toggle")).Click();
            Thread.Sleep(1000);
            select1.FindElement(By.LinkText("Login")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("input-email")).Clear();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("input-email")).SendKeys("roman_my@ukr.net");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("input-password")).Clear();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("input-password")).SendKeys("performingtesting");
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Desktops")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Show All Desktops")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("(//button[@type='button'])[22]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("wish list")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("iPhone", driver.FindElement(By.LinkText("iPhone")).Text);
            Assert.AreEqual("product 11", driver.FindElement(By.CssSelector("tbody .text-left:nth-child(3)")).Text);
            Assert.AreEqual("In Stock", driver.FindElement(By.CssSelector("tbody .text-right:nth-child(4)")).Text);
            Assert.AreEqual("$101.00", driver.FindElement(By.CssSelector(".price")).Text);
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".btn.btn-danger")).Click();
        }
    }
}
