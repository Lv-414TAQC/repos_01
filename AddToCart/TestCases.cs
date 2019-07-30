using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;

namespace AddToCart
{
    [TestFixture]
    class TestCases
    {
        private static IWebDriver driver;
        public static string ShoppingCartButton = "button.btn.btn-inverse.btn-block.btn-lg.dropdown-toggle";

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://192.168.61.128/opencart/upload/");
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            Thread.Sleep(1500);//Only for demonstration
            driver.Quit();
        }

        private static bool IsElementPresent(By by)
        {
            try
            {
                IWebElement i = driver.FindElement(by);
                if (i.Displayed)
                    return true;
                else return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        [Test]
        public static void DeleteProduct() //ATQCNET_166()
        {
            //Pre-condition
            Assert.True(driver.FindElement(By.CssSelector("div#logo a img.img-responsive")).GetAttribute("src").Contains("http://192.168.61.128/opencart/upload/image/catalog/logo.png"));

            driver.FindElement(By.Name("search")).SendKeys("%" + Keys.Enter);

            //Add the first product(iPod Touch)
            string IPodTouchAddButton = "//div[contains(@class, 'product-layout')]//h4/a[contains(text(),'iPod Touch')]/../../following-sibling::div/button[contains(@onclick,'cart')]";
            driver.FindElement(By.XPath(IPodTouchAddButton)).Click();
            Thread.Sleep(1500);

            //Add the second product(Palm Treo Pro)
            string PalmTreoProAddButton = "//div[contains(@class, 'product-layout')]//h4/a[contains(text(),'Palm Treo Pro')]/../../following-sibling::div/button[contains(@onclick,'cart')]";
            driver.FindElement(By.XPath(PalmTreoProAddButton)).Click();
            Thread.Sleep(1500);

            //1 step - click on cart
            driver.FindElement(By.CssSelector(ShoppingCartButton)).Click();
            Thread.Sleep(1500);

            Assert.AreEqual("Sub-Total", driver.FindElement(By.CssSelector("table.table-bordered td > strong")).Text);

            //2 step
            driver.FindElement(By.CssSelector(".btn.btn-danger.btn-xs")).Click();
            Thread.Sleep(1500);

            Assert.IsFalse(IsElementPresent(By.CssSelector("table.table-bordered td > strong")));

            IWebElement CartButtonText = driver.FindElement(By.Id("cart-total"));
            Assert.IsTrue(CartButtonText.Text.Contains("1 item(s)"));

            //step 3
            driver.FindElement(By.CssSelector(ShoppingCartButton)).Click();
            Thread.Sleep(1500);

            //Verify count elements in cart
            IList<IWebElement> ListElementsInCart = driver.FindElements(By.CssSelector("table.table-striped tr"));
            Assert.IsTrue(ListElementsInCart.Count == 1);

            //step 4
            driver.FindElement(By.CssSelector(".btn.btn-danger.btn-xs")).Click();
            Thread.Sleep(1500);

            Assert.IsFalse(IsElementPresent(By.CssSelector("table.table-bordered td > strong")));
            Assert.IsTrue(driver.FindElement(By.Id("cart-total")).Text.Contains("0 item(s)"));

            // step 5
            driver.FindElement(By.CssSelector(ShoppingCartButton)).Click();
            Thread.Sleep(1500);

            Assert.IsTrue(driver.FindElement(By.CssSelector(".text-center")).Text.Contains("Your shopping cart is empty!"));
        }


        [Test]
        public static void SuccessMessage() //ATQCNET_170
        {
            Assert.True(driver.FindElement(By.CssSelector("div#logo a img.img-responsive")).GetAttribute("src").Contains("http://192.168.61.128/opencart/upload/image/catalog/logo.png"));

            driver.FindElement(By.Name("search")).SendKeys("%" + Keys.Enter);

            string IMacAddButton = "//div[contains(@class, 'product-layout')]//h4/a[contains(text(),'iMac')]/../../following-sibling::div/button[contains(@onclick,'cart')]";
            driver.FindElement(By.XPath(IMacAddButton)).Click();
            Thread.Sleep(1500);

            Assert.IsTrue(IsElementPresent(By.CssSelector("div.alert.alert-success")));

            IWebElement name_product = driver.FindElement(By.XPath(IMacAddButton + "/parent::div/parent::div//h4//a"));
            IWebElement name_message = driver.FindElement(By.CssSelector("div.alert.alert-success"));
            Assert.IsTrue(name_message.Text.Contains(name_product.Text));
        }

        [Test]
        public static void ReopenBrowser() //ATQCNET_171
        {
            driver.FindElement(By.Name("search")).SendKeys("%" + Keys.Enter);
            
            //Add the first product
            string SamsungGalaxyTabAddButton = "//div[contains(@class, 'product-layout')]//h4/a[contains(text(),'Samsung Galaxy Tab 10.1')]/../../following-sibling::div/button[contains(@onclick,'cart')]";
            driver.FindElement(By.XPath(SamsungGalaxyTabAddButton)).Click();
            Thread.Sleep(1500);

            //Add the second product
            string iPodShuffleAddButton = "//div[contains(@class, 'product-layout')]//h4/a[contains(text(),'iPod Shuffle')]/../../following-sibling::div/button[contains(@onclick,'cart')]";
            driver.FindElement(By.XPath(iPodShuffleAddButton)).Click();
            Thread.Sleep(1500);

            driver.FindElement(By.CssSelector(ShoppingCartButton)).Click();
            Thread.Sleep(1500);

            string before_close = driver.FindElement(By.CssSelector("table.table-striped tr")).Text;

            var session = driver.Manage().Cookies.AllCookies.ToArray();

            driver.Close();

            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://192.168.61.128/opencart/upload/");

            foreach (Cookie cookie in session)
            {
                driver.Manage().Cookies.AddCookie(cookie);
            }

            driver.Navigate().GoToUrl("http://192.168.61.128/opencart/upload/");

            driver.FindElement(By.CssSelector(ShoppingCartButton)).Click();

            string after_close = driver.FindElement(By.CssSelector("table.table-striped tr")).Text;
            Assert.AreEqual(before_close, after_close);
            Thread.Sleep(1000);
        }
    }
}

