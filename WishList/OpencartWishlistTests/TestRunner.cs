using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpencartWishlistTests
{
    public abstract class TestRunner
    {
        protected IWebDriver driver;

        protected void LoggingIn()
        {
            string testerPassword = Environment.GetEnvironmentVariable("TESTER_PASWORD");
            IWebElement listUpperRight = driver.FindElement(By.ClassName("list-inline"));
            listUpperRight.FindElement(By.ClassName("dropdown-toggle")).Click();
            Thread.Sleep(1000); // for presentation only
            listUpperRight.FindElement(By.LinkText("Login")).Click();
            Thread.Sleep(1000); // for presentation only
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("roman_my@ukr.net");
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys(testerPassword);
            driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
        }
        protected void AddingIPhoneToWishlist()
        {
            driver.FindElement(By.CssSelector(".img-responsive")).Click();
            Thread.Sleep(1000); // for presentation only
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]" +
                "//h4/a[contains(text(), 'iPhone')]/../../following-sibling::div/" +
                "button[contains(@onclick, 'wishlist')]")).Click();
        }

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }
    }
}
