using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenCart414Test.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Tests
{
    // TODO Use Application Source classes
    public abstract class TestRunner
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // by default 0
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            //driver.Navigate().GoToUrl("http://192.168.61.129/opencart/upload/");
            //driver.Navigate().GoToUrl("http://10.26.34.118/opencart/upload/");
            //driver.Navigate().GoToUrl("http://192.168.140.131/opencart/upload/");
            //driver.Navigate().GoToUrl("http://192.168.61.129/opencart/upload/");
            //driver.Navigate().GoToUrl("http://172.20.10.2/opencart/upload/");
            driver.Navigate().GoToUrl("http://192.168.20.128/opencart/upload/");
        }

        [TearDown]
        //public void TearDown(ITestResult testResult)
        public void TearDown()
        {
            string resultMessage = TestContext.CurrentContext.Result.Message;
            if ((resultMessage != null) && (resultMessage.Length > 0))
            {
                // TODO Save to Log
                Console.WriteLine("TestContext.CurrentContext.Result = " + TestContext.CurrentContext.Result.Message);
            }
            //if (testResult.ResultState.Status == TestStatus.Failed)
            //if (TestContext.CurrentContext.Result.Message.Length > 0)
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                // TODO Save to File
                Console.WriteLine("TestContext.CurrentContext.Result.StackTrace = " + TestContext.CurrentContext.Result.StackTrace);
                // TODO Choose filename
                TakesScreenshot("d:/Screenshot12.png");
                TakesSources("");
                // Logout
                // Clear Cache
                //driver.Navigate().GoToUrl("http://10.26.34.233/opencart/upload/");
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

    }
}
