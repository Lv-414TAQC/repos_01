using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;

namespace AddToCart
{
    [TestFixture]
    class TestCases
    {
        private static IWebDriver driver;

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
            Thread.Sleep(1500);
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
        public static void ATQCNET_166()
        {
            //Pre-condition
            Assert.True(driver.FindElement(By.CssSelector("div#logo a img.img-responsive")).GetAttribute("src").Contains("http://192.168.61.128/opencart/upload/image/catalog/logo.png"));

            driver.FindElement(By.Name("search")).SendKeys("%" + Keys.Enter);
            //Add the first product

            driver.FindElement(By.CssSelector("div.button-group button[onclick=\"cart.add('41', '1');\"]")).Click();
            Thread.Sleep(1500);
            //Add the second product
            driver.FindElement(By.CssSelector("div.button-group button[onclick=\"cart.add('44', '1');\"]")).Click();
            Thread.Sleep(1500);

            //1 step - click on cart
            driver.FindElement(By.CssSelector("button.btn.btn-inverse.btn-block.btn-lg.dropdown-toggle")).Click();
            Thread.Sleep(1500);

            Assert.AreEqual("Sub-Total", driver.FindElement(By.CssSelector("table.table-bordered td > strong")).Text);

            //2 step
            driver.FindElement(By.CssSelector(".btn.btn-danger.btn-xs")).Click();
            Thread.Sleep(1500);

            Assert.IsFalse(IsElementPresent(By.CssSelector("table.table-bordered td > strong")));

            IWebElement step2 = driver.FindElement(By.Id("cart-total"));
            Assert.IsTrue(step2.Text.Contains("1 item(s)"));

            //step 3
            driver.FindElement(By.CssSelector("button.btn.btn-inverse.btn-block.btn-lg.dropdown-toggle")).Click();
            Thread.Sleep(1500);

            Assert.IsTrue(IsElementPresent(By.CssSelector(".table.table-striped tr:nth-child(1)")) && !IsElementPresent(By.CssSelector(".table.table-striped tr:nth-child(2)")));

            //step 4
            driver.FindElement(By.CssSelector(".btn.btn-danger.btn-xs")).Click();
            Thread.Sleep(1500);

            Assert.IsFalse(IsElementPresent(By.CssSelector("table.table-bordered td > strong")));
            Assert.AreEqual("0 item(s) - $0.00", driver.FindElement(By.Id("cart-total")).Text);

            // step 5
            driver.FindElement(By.CssSelector("button.btn.btn-inverse.btn-block.btn-lg.dropdown-toggle")).Click();
            Thread.Sleep(1500);

            Assert.AreEqual("Your shopping cart is empty!", driver.FindElement(By.CssSelector(".text-center")).Text);
        }

        [Test]
        public static void ATQCNET_170()
        {
            Assert.True(driver.FindElement(By.CssSelector("div#logo a img.img-responsive")).GetAttribute("src").Contains("http://192.168.61.128/opencart/upload/image/catalog/logo.png"));

            //step1
            driver.FindElement(By.Name("search")).SendKeys("%" + Keys.Enter);

            //Add the first product
            //IWebElement step1 = driver.FindElement(By.CssSelector("div.button-group button[onclick=\"cart.add('29', '1');\"]"));
            //step1.Click();

            IWebElement element = driver.FindElement(By.XPath("//*[contains(@class,\"button-group\")]/button[@onclick=\"cart.add('36', '1');\"]"));
            element.Click();
            Thread.Sleep(1500);

            Assert.IsTrue(IsElementPresent(By.CssSelector("div.alert.alert-success")));

            //parents element

            IWebElement name_product = driver.FindElement(By.XPath("//*[contains(@class,\"button-group\")]/button[@onclick=\"cart.add('36', '1');\"]/parent::div/parent::div//h4//a"));
            IWebElement name_message = driver.FindElement(By.CssSelector("div.alert.alert-success"));
            Assert.IsTrue(name_message.Text.Contains(name_product.Text));
        }

        [Test]
        public static void ATQCNET_171()
        {
            driver.FindElement(By.Name("search")).SendKeys("%" + Keys.Enter);
            //Add the first product

            driver.FindElement(By.CssSelector("div.button-group button[onclick=\"cart.add('41', '1');\"]")).Click();
            Thread.Sleep(1500);
            //Add the second product
            driver.FindElement(By.CssSelector("div.button-group button[onclick=\"cart.add('44', '1');\"]")).Click();
            Thread.Sleep(1500);

            driver.FindElement(By.CssSelector("button.btn.btn-inverse.btn-block.btn-lg.dropdown-toggle")).Click();
            Thread.Sleep(1500);

            string before_close = driver.FindElement(By.CssSelector("table.table-striped tr:nth-child(1)")).Text;

            var session = driver.Manage().Cookies.AllCookies.ToArray();

            driver.Close();

            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://192.168.61.128/opencart/upload/");

            foreach (Cookie cookie in session)
            {
                driver.Manage().Cookies.DeleteCookieNamed(cookie.Name);
                driver.Manage().Cookies.AddCookie(cookie);
            }

            driver.Navigate().GoToUrl("http://192.168.61.128/opencart/upload/");

            driver.FindElement(By.CssSelector("button.btn.btn-inverse.btn-block.btn-lg.dropdown-toggle")).Click();

            string after_close = driver.FindElement(By.CssSelector("table.table-striped tr:nth-child(1)")).Text;
            Assert.AreEqual(before_close, after_close);
            Thread.Sleep(1000);
        }

    }
}

