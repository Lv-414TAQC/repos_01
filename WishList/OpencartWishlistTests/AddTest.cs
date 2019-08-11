using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpencartWishlistTests
{
    [TestFixture]
    class AddTest : TestRunner
    {   
        [SetUp]
        public void SetupTest()
        {
            driver.Navigate().GoToUrl("http://192.168.20.128/opencart/upload/");
        }

        [TearDown]
        public void TeardownTest()
        {
            driver.FindElement(By.XPath("//div[@id='content']/div[@class='table-responsive']" +
                "/table/tbody/tr")).FindElement(By.CssSelector(".btn.btn-danger")).Click();
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
        }
    }
}
