using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenCart414Test.Pages;
using OpenCart414Test.Pages.AdminPanel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using OpenQA.Selenium.Support.UI;

namespace OpenCart414Test.Tests
{
    public abstract class TestRunner
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public virtual void SetUp()
        {

            // TODO

           // driver.Navigate().GoToUrl("http://192.168.20.128/opencart/upload/");

            //driver.Navigate().GoToUrl("http://192.168.163.130/opencart/upload/"); //alena
           // driver.Navigate().GoToUrl("http://192.168.147.128/opencart/upload/"); // Nazar

            //driver.Navigate().GoToUrl("http://192.168.163.130/opencart/upload/"); //alena
            //driver.Navigate().GoToUrl("http://192.168.147.128/opencart/upload/"); // Nazar
            //driver.Navigate().GoToUrl("http://192.168.61.129/opencart/upload/");
            //driver.Navigate().GoToUrl("http://10.26.34.118/opencart/upload/");
           // driver.Navigate().GoToUrl("http://192.168.140.131/opencart/upload/"); //dima
           // driver.Navigate().GoToUrl("http://192.168.17.128/opencart/upload/");
            //driver.Navigate().GoToUrl("http://192.168.140.131/opencart/upload/");
            //driver.Navigate().GoToUrl("http://192.168.61.129/opencart/upload/");
            //driver.Navigate().GoToUrl("http://172.20.10.2/opencart/upload/");
            //driver.Navigate().GoToUrl("http://192.168.20.128/opencart/upload/");
            //driver.Navigate().GoToUrl("http://172.20.10.2/opencart/upload/");
            driver.Navigate().GoToUrl("http://192.168.20.128/opencart/upload/");


            //driver.Navigate().GoToUrl("http://192.168.61.129/opencart/upload/");


        }

        [TearDown]
        public void TearDown()
        {
            string resultMessage = TestContext.CurrentContext.Result.Message;
            if ((resultMessage != null) && (resultMessage.Length > 0))
            {
                Console.WriteLine("TestContext.CurrentContext.Result = " + TestContext.CurrentContext.Result.Message);
            }
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Console.WriteLine("TestContext.CurrentContext.Result.StackTrace = " + TestContext.CurrentContext.Result.StackTrace);
                TakesScreenshot("d:/Screenshot12.png");
                TakesSources("");
            }
        }

        protected void TakesScreenshot(string filePath)
        {
            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
        }

        protected void TakesSources(string filePath)
        {
            // TODO Save Sources
        }

        public HomePage LoadApplication()
        {
            return new HomePage(driver);
        }

        public AdminLoginPage LoadAdminLoginPage()
        {
            driver.Navigate().GoToUrl("http://192.168.17.128/opencart/upload/admin");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return new AdminLoginPage(driver);
        }

        public HomePage LoadHomePage()
        {
            driver.Navigate().GoToUrl("http://192.168.17.128/opencart/upload/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return new HomePage(driver);
        }
    }
}
