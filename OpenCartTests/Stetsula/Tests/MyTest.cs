using NUnit.Framework;
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
            //HomePage.MenuButton.Click();
            //IWebElement text =  Driver.FindElement(By.XPath("//li[@id='menu-catalog']/a[@class='parent']/span"));
            //Console.WriteLine(text.Text);
            //HomePage.ClickMenu("System");
            //Thread.Sleep(1000);
            //HomePage.ClickSubMenu("Users");
            //Thread.Sleep(1000);
            //HomePage.ClickSubMenu("API");
            HomePage.ClickTaxClassesMenu();
            //Console.WriteLine(HomePage.SideMenu.Menus["System"].MenuLabel);

        }

    }
}
