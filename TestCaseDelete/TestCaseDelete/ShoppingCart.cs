using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestCaseDelete
{

    [TestFixture]
    public class ShoppingCart
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            //IWebDriver driver = new FirefoxDriver();
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            // Precondition
            // Goto Application Start Page
            driver.Navigate().GoToUrl("http://192.168.163.130/opencart/upload/");
            Thread.Sleep(1000); // BAD Practic, don't use.
        }

        [TearDown]
        public void TearDown()
        {
            // Return to previous state
            // Check if Loggined and logout driver.Navigate().GoToUrl(".../logout");
        }
        [Test]
        public void Addproduct()
        {

            driver.FindElement(By.PartialLinkText("Phones & PDAs")).Click();
            Thread.Sleep(1000); // only for presentation
            Assert.IsTrue(driver.FindElement(By.CssSelector("#content > h2")).Text.Contains("Phones & PDAs"));
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]//h4/a[contains(text(),'iPhone')]/../../following-sibling::div/button[contains(@onclick,'cart')]")).Click();
            Thread.Sleep(1000); // only for presentation    
            Assert.IsTrue(driver.FindElement(By.CssSelector("div.alert.alert-success")).Text.Contains("Success: You have added iPhone to your shopping cart!"));
            driver.FindElement(By.CssSelector("a[title = 'Shopping Cart']")).Click();
            Thread.Sleep(1000); // only for presentation 
            Assert.IsTrue(driver.FindElement(By.CssSelector("#content > h1")).Text.Substring(0, 13).Contains("Shopping Cart"));
            Assert.IsTrue(driver.FindElement(By.LinkText("iPhone")).Displayed);
            driver.FindElement(By.ClassName("btn-default")).Click();
            Thread.Sleep(1000); // only for presentation
        }
        [Test]
        public void Price()
        {
            driver.FindElement(By.PartialLinkText("Phones & PDAs")).Click();
            Thread.Sleep(1000); // only for presentation
            Assert.IsTrue(driver.FindElement(By.CssSelector("#content > h2")).Text.Contains("Phones & PDAs"));
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]//h4/a[contains(text(),'iPhone')]/../../following-sibling::div/button[contains(@onclick,'cart')]")).Click();
            Thread.Sleep(1000); // only for presentation    
            driver.FindElement(By.CssSelector("a[title = 'Shopping Cart']")).Click();
            Thread.Sleep(1000); // only for presentation 
            Assert.IsTrue(driver.FindElement(By.CssSelector("#content > h1")).Text.Substring(0, 13).Contains("Shopping Cart"));
            string unitprice = driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td/a[contains(text(),'iPhone')]/../following-sibling::td[@class ='text-right']")).Text;
            //total price
            string totalprice = driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td/a[contains(text(),'iPhone')]/../following-sibling::td[@class ='text-right']/following-sibling::td")).Text;
            Assert.IsTrue(unitprice.Substring(1, 5) == totalprice.Substring(1, 5));
            IWebElement field = (driver.FindElement(By.CssSelector(".input-group.btn-block > input")));
            driver.FindElement(By.CssSelector(".input-group.btn-block > input")).Clear();
            driver.FindElement(By.CssSelector(".input-group.btn-block > input")).SendKeys("2");
            Thread.Sleep(1000); // only for presentation 
            field = (driver.FindElement(By.CssSelector(".input-group.btn-block > input")));
            Assert.IsTrue(field.GetAttribute("value") == "2");
            driver.FindElement(By.CssSelector("button.btn.btn-primary")).Click();
            Thread.Sleep(1000); // only for presentation
            field = (driver.FindElement(By.CssSelector(".input-group.btn-block > input")));
            //unit price
            unitprice = driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td/a[contains(text(),'iPhone')]/../following-sibling::td[@class ='text-right']")).Text;
            //tota price
            totalprice = driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td/a[contains(text(),'iPhone')]/../following-sibling::td[@class ='text-right']/following-sibling::td")).Text;
            Assert.IsTrue((Convert.ToDouble(unitprice.Substring(1, 5).Replace('.', ',')) * Convert.ToInt32(field.GetAttribute("value"))) == Convert.ToDouble(totalprice.Substring(1, 5).Replace('.', ',')));
            double subtotal = Convert.ToDouble(driver.FindElement(By.XPath("//div[@class='row']/div/table/tbody/tr/td/strong[text() ='Sub-Total:']/../following-sibling::td")).Text.Substring(1, 5).Replace('.', ','));
            double ecotax = Convert.ToDouble(driver.FindElement(By.XPath("//div[@class='row']/div/table/tbody/tr/td/strong[text() ='Eco Tax (-2.00):']/../following-sibling::td")).Text.Substring(1, 3).Replace('.', ','));
            double vat = Convert.ToDouble(driver.FindElement(By.XPath("//div[@class='row']/div/table/tbody/tr/td/strong[text() ='VAT (20%):']/../following-sibling::td")).Text.Substring(1, 4).Replace('.', ','));
            double total = Convert.ToDouble(driver.FindElement(By.XPath("//div[@class='row']/div/table/tbody/tr/td/strong[text() ='Total:']/../following-sibling::td")).Text.Substring(1, 5).Replace('.', ','));
            Console.WriteLine(ecotax + subtotal + vat + total);
            Assert.IsTrue(ecotax + subtotal + vat == total);
            Console.WriteLine(total + " == " + Convert.ToDouble(totalprice.Substring(1, 5).Replace('.', ',')));
            Assert.IsTrue(total == Convert.ToDouble(totalprice.Substring(1, 5).Replace('.', ',')));
            Console.WriteLine(vat + " == " + subtotal * 0.2);
            Assert.IsTrue(vat == ((subtotal * 20)/100));
        }
        [Test]
        public void Refresh()
        {
            driver.FindElement(By.PartialLinkText("Phones & PDAs")).Click();
            Thread.Sleep(1000); // only for presentation
            Assert.IsTrue(driver.FindElement(By.CssSelector("#content > h2")).Text.Contains("Phones & PDAs"));
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]//h4/a[contains(text(),'iPhone')]/../../following-sibling::div/button[contains(@onclick,'cart')]")).Click();
            Thread.Sleep(1000); // only for presentation    
            driver.FindElement(By.CssSelector("a[title = 'Shopping Cart']")).Click();
            Thread.Sleep(1000); // only for presentation 
            Assert.IsTrue(driver.FindElement(By.CssSelector("#content > h1")).Text.Substring(0, 13).Contains("Shopping Cart"));
            IWebElement field = (driver.FindElement(By.CssSelector(".input-group.btn-block > input")));
            driver.FindElement(By.CssSelector(".input-group.btn-block > input")).Clear();
            Assert.IsTrue(field.GetAttribute("value") == "");
            driver.FindElement(By.CssSelector(".input-group.btn-block > input")).SendKeys("2");
            Thread.Sleep(1000); // only for presentation 
            driver.FindElement(By.CssSelector("button.btn.btn-primary")).Click();
            Thread.Sleep(1000); // only for presentation
            Assert.IsTrue(driver.FindElement(By.CssSelector("div.alert.alert-success")).Text.Contains("Success: You have modified your shopping cart!"));
            field = (driver.FindElement(By.CssSelector(".input-group.btn-block > input")));
            Assert.IsTrue(field.GetAttribute("value") == "2");
            driver.FindElement(By.CssSelector(".input-group.btn-block > input")).Clear();
            driver.FindElement(By.CssSelector(".input-group.btn-block > input")).SendKeys("job");
            Thread.Sleep(1000); // only for presentation 
            driver.FindElement(By.CssSelector("button.btn.btn-primary")).Click();
            
        }
        
        [Test]
        public void Delete()
        {
            driver.FindElement(By.PartialLinkText("Phones & PDAs")).Click();
            Thread.Sleep(1000); // only for presentation
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]//h4/a[contains(text(),'iPhone')]/../../following-sibling::div/button[contains(@onclick,'cart')]")).Click();
            Thread.Sleep(1000); // only for presentation    
            driver.FindElement(By.CssSelector("a[title = 'Shopping Cart']")).Click();
            Thread.Sleep(1000); // only for presentation 
            driver.FindElement(By.CssSelector(".input-group.btn-block > input")).Clear();
            driver.FindElement(By.CssSelector(".input-group.btn-block > input")).SendKeys("0");
            Thread.Sleep(1000); //for update page
            driver.FindElement(By.CssSelector("button.btn.btn-primary")).Click();
            Thread.Sleep(1000); // only for presentation
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id = 'content']/p")).Text.Contains("Your shopping cart is empty!"));
            driver.FindElement(By.PartialLinkText("Phones & PDAs")).Click();
            Thread.Sleep(1000); // only for presentation
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]//h4/a[contains(text(),'iPhone')]/../../following-sibling::div/button[contains(@onclick,'cart')]")).Click();
            Thread.Sleep(1000); // only for presentation    
            driver.FindElement(By.CssSelector("a[title = 'Shopping Cart']")).Click();
            Thread.Sleep(1000); // only for presentation 
            driver.FindElement(By.CssSelector("button.btn.btn-danger:not(.btn-xs)")).Click();
            Thread.Sleep(1000); //for update page
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id = 'content']/p")).Text.Contains("Your shopping cart is empty!"));
            Thread.Sleep(1000); //// only for presentation
            driver.FindElement(By.LinkText("Continue")).Click();
        }
        }
    }


