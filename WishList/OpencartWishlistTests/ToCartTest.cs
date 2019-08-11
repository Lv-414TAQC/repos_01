using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpencartWishlistTests
{
    [TestFixture]
    class ToCartTest : TestRunner
    {   
        [SetUp]
        public void SetupTest()
        {
            driver.Navigate().GoToUrl("http://192.168.20.128/opencart/upload/");
        }

        [TearDown]
        public void TeardownTest()
        {
            driver.FindElement(By.XPath("//ul[@class='dropdown-menu pull-right']")).FindElement(By.CssSelector(".btn-danger")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/div[@class='table-responsive']" +
                "/table/tbody/tr")).FindElement(By.CssSelector(".btn.btn-danger")).Click();
        }
        
        [Test]
        public void TheOpencartWishlistToCartCheck()
        {
            LoggingIn();
            Thread.Sleep(1000); // for presentation only
            AddingIPhoneToWishlist();
            Thread.Sleep(1000); // for presentation only
            driver.FindElement(By.LinkText("wish list")).Click();
            Thread.Sleep(1000); // for presentation only
            driver.FindElement(By.XPath("//div[@id='content']/div[@class='table-responsive']/table/tbody/tr"))
                .FindElement(By.CssSelector(".btn.btn-primary")).Click();
            Assert.IsTrue(driver.FindElement(By.CssSelector(".alert.alert-success")).Displayed);
            Thread.Sleep(1000); // for presentaion only
            driver.FindElement(By.CssSelector("#cart-total")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//ul[@class='dropdown-menu pull-right']"))
                .FindElement(By.LinkText("iPhone")).Displayed);
        }
    }
}
