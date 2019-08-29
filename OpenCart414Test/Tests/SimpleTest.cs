using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Firefox;
using NLog;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using System.IO;
using Allure.Commons;
using NUnit.Framework.Interfaces;

namespace OpenCart414Test.Tests
{
    [AllureNUnit]
    [AllureDisplayIgnored]
    [TestFixture]
    public class SimpleTest
    {
        //public static Logger log = LogManager.GetCurrentClassLogger(); // for NLog
        //public static Logger log = LogManager.GetLogger("rolling0");   // for NLog
        protected const string ALLURE_CONFIG = "allureConfig.json";
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
            // TODO
            //driver.Navigate().GoToUrl("http://10.26.34.118/opencart/upload/");
        }

        public void OpenUrl()
        {
            // TODO
            driver.Navigate().GoToUrl("https://go.softserve.academy/");
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
                TakesSources("d:/Screenshot12.txt");
                // Logout
                // Clear Cache
                //driver.Navigate().GoToUrl("http://10.26.34.233/opencart/upload/");
            }
            //if (File.Exists(sourcePath))
            //{
            //    if (File.Exists(runtimePath + ALLURE_CONFIG))
            //    {
            //        File.Delete(runtimePath + ALLURE_CONFIG);
            //    }
            //    File.Copy(sourcePath, runtimePath + ALLURE_CONFIG);
            //}
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
            string pageSource = driver.PageSource;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            File.WriteAllText(filePath, pageSource);
        }

        [Test(Description = "GO_Softserve_Academy_Test")]
        [AllureTag("Regression_Tag")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-53")]
        [AllureTms("TMS-12")]
        [AllureOwner("User_Owner")]
        [AllureParentSuite("With_parameters_ParentSuite")]
        [AllureSuite("Passed_Suite")]
        [AllureSubSuite("NoAssert_SubSuite")]
        [AllureEpic("Retry_Epic")]
        [AllureFeature("RetrySmall_Feature")]
        [AllureLink("softserve_ITA_Link", "https://go.softserve.academy/")]
        public void SoftserveAcademy()
        {
            //log.Info("START SoftserveAcademy");
            //log.Info("ThreadID= " + Thread.CurrentThread.ManagedThreadId);
            //
            //IWebDriver driver;
            //driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // by default = 0
            //
            //driver.Navigate().GoToUrl("https://softserve.academy/");
            OpenUrl();
            Thread.Sleep(1000); // DO NOT USE
            //
            driver.FindElement(By.LinkText("Log in")).Click();
            Thread.Sleep(1000); // DO NOT USE
            //
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("Hello2");
            Thread.Sleep(2000); // DO NOT USE
            //
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("Hello");
            Thread.Sleep(2000); // DO NOT USE
            //
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("qwerty");
            Thread.Sleep(2000); // DO NOT USE
            //
            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            byte[] bytes = screenshot.AsByteArray;
            AllureLifecycle.Instance.AddAttachment("Screenshot", "image/png", bytes);
            Thread.Sleep(2000); // DO NOT USE
            //
            string htmlCode = driver.PageSource;
            bytes = Encoding.ASCII.GetBytes(htmlCode);
            AllureLifecycle.Instance.AddAttachment("HTMP_Source", "text/plain", bytes);
            //
            string runtimePath = AppDomain.CurrentDomain.BaseDirectory;
            string file = File.ReadAllText(runtimePath + ALLURE_CONFIG);
            bytes = Encoding.ASCII.GetBytes(file);
            AllureLifecycle.Instance.AddAttachment("External_File_allureConfig.json", "text/plain", bytes);
            //
            //driver.Quit();
            //log.Info("DONE SoftserveAcademy");
        }

    }
}
