using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenCart414Test.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Reflection;
using System.IO;
using OpenQA.Selenium.Support.UI;
using OpenCart414Test.Pages.AdminPanel;

namespace OpenCart414Test.Tests
{
    // TODO Use Application Source classes
    public abstract class TestRunner
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // by default 0
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
            driver.Navigate().GoToUrl("http://192.168.61.129/opencart/upload/");
            //driver.Navigate().GoToUrl("http://192.168.163.130/opencart/upload/"); //alena
        }

        [TearDown]
        //public void TearDown(ITestResult testResult)
        public virtual void TearDown()
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
            // TSave Screenshot
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


        public IWebElement WaitCheckOutLink()
        {
            IWebElement result = wait.Until((drv) =>
            {
                return LoadApplication().GetCartContainerComponent().CheckOutLink;
            });
            return result;
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
