using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

namespace AddToCart 
{
    [TestFixture]
    class TestCases
    {
       
        private static IWebDriver driver;
        public const string ShoppingCartButton = "#cart > button";

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

            driver.FindElement(By.Name("search")).Clear();
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

            Assert.IsTrue(driver.FindElement(By.Id("cart-total")).Text.Contains("1 item(s)"));

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

            Assert.IsTrue(driver.FindElement(By.CssSelector("div.alert.alert-success")).Text.Contains(driver.FindElement(By.XPath(IMacAddButton + "/parent::div/parent::div//h4//a")).Text));
        }

        [Test]
        public static void ReopenBrowser() //ATQCNET_171
        {
            driver.FindElement(By.Name("search")).Clear();
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

            driver.Navigate().Refresh();

            driver.FindElement(By.CssSelector(ShoppingCartButton)).Click();

            string after_close = driver.FindElement(By.CssSelector("table.table-striped tr")).Text;
            Assert.AreEqual(before_close, after_close);
            Thread.Sleep(1000);
        }

        [Test]
        public static void AddProduct() //ATQCNET_166()
        {
            driver.FindElement(By.XPath("//li[contains(@class,'dropdown')]//a[text()='Desktops']")).Click();
            driver.FindElement(By.XPath("//div[contains(@class,'dropdown-menu')]/a[text()='Show All Desktops']")).Click();
            Thread.Sleep(2000);

            //Add the first product(iPod Classic)
            string IPodClassicAddButton = "//div[contains(@class, 'product-layout')]//h4/a[contains(text(),'iPod Classic')]/../../following-sibling::div/button[contains(@onclick,'cart')]";
            driver.FindElement(By.XPath(IPodClassicAddButton)).Click();
            Thread.Sleep(1500);

            driver.FindElement(By.CssSelector(ShoppingCartButton)).Click();
            Thread.Sleep(1500);

            Assert.IsTrue(IsElementPresent(By.XPath("//td[contains(@class,'text-left')]/a[contains(text(),'iPod Classic')]")));


            driver.FindElement(By.CssSelector(ShoppingCartButton)).Click();
            driver.FindElement(By.XPath("//ul[contains(@class,'nav')]/li/a[text()='Cameras']")).Click();
            Thread.Sleep(2000);

            //Add the second product(iPod Classic)
            string CanonEOSAddButton = "//div[contains(@class, 'product-layout')]//h4/a[contains(text(),'Canon EOS 5D')]/../../following-sibling::div/button[contains(@onclick,'cart')]";
            driver.FindElement(By.XPath(CanonEOSAddButton)).Click();
            Thread.Sleep(1500);

            
            driver.FindElement(By.Id("input-option226")).Click();
            SelectElement select = new SelectElement(driver.FindElement(By.CssSelector("#input-option226")));
            select.SelectByText("Red");
            Thread.Sleep(2000);

            driver.FindElement(By.Id("input-quantity")).Clear();
            driver.FindElement(By.Id("input-quantity")).SendKeys("1" + Keys.Enter);

            Thread.Sleep(2000);
            driver.FindElement(By.Id("button-cart")).Click();
            Thread.Sleep(1500);

            driver.FindElement(By.CssSelector(ShoppingCartButton)).Click();
            Thread.Sleep(1500);

             //to do verify if two products are equals to previous added
        }


    }

}

