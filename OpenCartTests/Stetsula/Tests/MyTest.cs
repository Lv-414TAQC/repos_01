using NUnit.Framework;
using OpenCartTests.Stetsula.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;

namespace OpenCartTests.Stetsula
{
    [TestFixture]
    class MyTest
    {
        IWebDriver Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        [Test]
        public void CheckLogInAdmin()
        {
            //ChromeOptions options = new ChromeOptions();
            //options.AddArguments(@"C:\Users\Oleg\AppData\Local\Google\Chrome\User Data");
            //Console.WriteLine(Page.AdminName);
            Driver.Navigate().GoToUrl(@"http://192.168.17.128/opencart/upload/admin/");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Maximize();
            AdminLoginPage Page = new AdminLoginPage(Driver);
            Page.LogInAdmin();
            AdminHomePage HomePage = new AdminHomePage(Driver);
            HomePage.ClickGeoZonesMenu();
            GeoZonesPage GZ = new GeoZonesPage(Driver);
            GZ.DeleteGeoZone("UA Tax Zone");


        }

    }
}
