using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpencartWishlistTests
{
    [TestFixture]
    class RemoveTest : TestRunner
    {   
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
        public void TheOpencartWishlistRemoveCheck()
        {
            LoggingIn();
            Thread.Sleep(1000); // for presentation only
            AddingIPhoneToWishlist();
            Thread.Sleep(1000); // for presentation only
            driver.FindElement(By.LinkText("wish list")).Click();
            Thread.Sleep(1000); // for presentation only
            IWebElement wishlistTableContent = driver.FindElement(By.XPath("//div[@id='content']/div[@class='table-responsive']/table/tbody/tr"));
            wishlistTableContent.FindElement(By.CssSelector(".btn.btn-danger")).Click();
            Assert.IsTrue(driver.FindElement(By.CssSelector(".alert.alert-success")).Displayed);
        }
    }
}
