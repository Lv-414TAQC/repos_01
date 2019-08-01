using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace OpencartWishlistTests
{
    [TestFixture]
    public class OpencartWishlistTest
    {
        private IWebDriver driver;
        
        private void LoggingIn()
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
        private void AddingIPhoneToWishlist()
        {
            driver.FindElement(By.LinkText("Phones & PDAs")).Click();
            Thread.Sleep(1000); // for presentation only
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]" +
                "//h4/a[contains(text(), 'iPhone')]/../../following-sibling::div/" +
                "button[contains(@onclick, 'wishlist')]")).Click();
        }

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
        public void TheOpencartWishlistAddCheck()
        {
            LoggingIn();
            Thread.Sleep(1000); // for presentation only
            AddingIPhoneToWishlist();
            Thread.Sleep(1000); // for presentation only
            Assert.IsTrue(driver.FindElement(By.CssSelector(".alert.alert-success")).Displayed);
            driver.FindElement(By.LinkText("wish list")).Click();
            Thread.Sleep(1000); // for presentation only
            IWebElement wishlistTableContent = driver.FindElement(By.XPath("//div[@id='content']/div[@class='table-responsive']/table/tbody/tr"));
            Assert.IsTrue(wishlistTableContent.FindElement(By.XPath(".//td/a/img[@src='http://192.168.20.128/opencart/upload/image/cache/catalog/demo/iphone_1-47x47.jpg']")).Displayed);
            Assert.IsTrue(wishlistTableContent.FindElement(By.LinkText("iPhone")).Displayed);
            Assert.IsTrue(wishlistTableContent.FindElement(By.XPath(".//td[contains(text(), 'product 11')]")).Displayed);
            Assert.IsTrue(wishlistTableContent.FindElement(By.XPath(".//td[contains(text(), 'In Stock')]")).Displayed);
            Assert.AreEqual("$101.00", wishlistTableContent.FindElement(By.CssSelector(".price")).Text);
            Thread.Sleep(1000); // for presentation only
            wishlistTableContent.FindElement(By.CssSelector(".btn.btn-danger")).Click();
        }
        [Test]
        public void TheOpencartWishlistRemoveCheck()
        {
            //LoggingIn();
            Thread.Sleep(1000); // for presentation only
            AddingIPhoneToWishlist();
            Thread.Sleep(1000); // for presentation only
            driver.FindElement(By.LinkText("wish list")).Click();
            Thread.Sleep(1000); // for presentation only
            IWebElement wishlistTableContent = driver.FindElement(By.XPath("//div[@id='content']/div[@class='table-responsive']/table/tbody/tr"));
            wishlistTableContent.FindElement(By.CssSelector(".btn.btn-danger")).Click();
            Assert.IsTrue(driver.FindElement(By.CssSelector(".alert.alert-success")).Displayed);
        }
        [Test]
        public void TheOpencartWishlistToCartCheck()
        {
            //LoggingIn();
            Thread.Sleep(1000); // for presentation only
            AddingIPhoneToWishlist();
            Thread.Sleep(1000); // for presentation only
            driver.FindElement(By.LinkText("wish list")).Click();
            Thread.Sleep(1000); // for presentation only
            IWebElement wishlistTableContent = driver.FindElement(By.XPath("//div[@id='content']/div[@class='table-responsive']/table/tbody/tr"));
            wishlistTableContent.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            Assert.IsTrue(driver.FindElement(By.CssSelector(".alert.alert-success")).Displayed);
            Thread.Sleep(1000); // for presentation only
            wishlistTableContent.FindElement(By.CssSelector(".btn.btn-danger")).Click();
        }
    }
}
