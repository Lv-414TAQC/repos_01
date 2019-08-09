using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OpenCart414Test.Pages.AdminPanel
{
    class AdminHomePage : HeaderPart
    {
        public SideMenuComponent SideMenu;

        public AdminHomePage(IWebDriver Driver) : base(Driver)
        {
            SideMenu = new SideMenuComponent(Driver);
            GetMenu();
        }

        public void GetMenu()
        {
            MenuButton.Click();
            foreach (IWebElement item in Driver.FindElements(By.CssSelector("li[id]>a.parent")))
            {
                MenuComponent menu = new MenuComponent(Driver);
                menu.MenuButton = item;
                menu.MenuLabel = item.FindElement(By.XPath("./span")).Text;
                //Console.WriteLine(menu.MenuLabel);
                SideMenu.Menus.Add(menu.MenuLabel, menu);

            }
            MenuButton.Click();
        }

        public void ClickMenu(string targetMenu)
        {

            SideMenu.Menus[targetMenu].MenuButton.Click();
        }

        public void ClickLocalizationMenu()
        {
            ClickMenu("System");
            MenuComponent Localization = new MenuComponent(Driver);
            Localization.MenuButton = Driver.FindElement(By.XPath("//a[contains(text(), 'Localisation')]"));
            Localization.MenuLabel = Localization.MenuButton.Text;
            Localization.MenuButton.Click();
        }

        public void ClickGeoZonesMenu()
        {
            ClickLocalizationMenu();
            MenuComponent GeoZones = new MenuComponent(Driver);
            GeoZones.MenuButton = Driver.FindElement(By.XPath("//a[contains(text(), 'Geo Zones')]"));
            GeoZones.MenuLabel = GeoZones.MenuButton.Text;
            GeoZones.MenuButton.Click();
        }

        public void ClickTaxesMenu()
        {
            ClickLocalizationMenu();
            MenuComponent Taxes = new MenuComponent(Driver);
            Taxes.MenuButton = Driver.FindElement(By.XPath("//a[contains(text(), 'Taxes')]"));
            Taxes.MenuLabel = Taxes.MenuButton.Text;
            Taxes.MenuButton.Click();
        }

        public void ClickTaxRatesMenu()
        {
            ClickTaxesMenu();
            MenuComponent TaxRates = new MenuComponent(Driver);
            TaxRates.MenuButton = Driver.FindElement(By.XPath("//a[contains(text(), 'Tax Rates')]"));
            TaxRates.MenuLabel = TaxRates.MenuButton.Text;
            TaxRates.MenuButton.Click();
        }

        public void ClickTaxClassesMenu()
        {
            ClickTaxesMenu();
            MenuComponent TaxClasses = new MenuComponent(Driver);
            TaxClasses.MenuButton = Driver.FindElement(By.XPath("//a[contains(text(), 'Tax Classes')]"));
            TaxClasses.MenuLabel = TaxClasses.MenuButton.Text;
            TaxClasses.MenuButton.Click();
        }

        public void ClickSubMenu(string submenu)
        {
            MenuComponent Submenu = new MenuComponent(Driver);
            string path = String.Format(@"//a[contains(text(), {0})]", submenu);
            Submenu.MenuButton = Driver.FindElement(By.XPath(path));
            Submenu.MenuLabel = Submenu.MenuButton.Text;
            Submenu.MenuButton.Click();
        }

        public void ClickCurrenciesMenu()
        {
            ClickLocalizationMenu();
            MenuComponent Currencies = new MenuComponent(Driver);
            Currencies.MenuButton = Driver.FindElement(By.XPath("//a[contains(text(), 'Currencies')]"));
            Currencies.MenuLabel = Currencies.MenuButton.Text;
            Currencies.MenuButton.Click();
        }


        //public void BuildMenuTree()
        //{
        //    MenuComponent System = new MenuComponent(driver);
        //    System.MenuButton = driver.FindElement(By.Id("menu-system"));
        //    System.MenuLabel = driver.FindElement(By.CssSelector("#menu-system span")).Text;
        //    Menus.Add("System", System);

        //    MenuComponent Localization = new MenuComponent(driver);
        //    Localization.MenuButton = driver.FindElement(By.XPath("//a[contains(text(), 'Localisation')]"));
        //    Localization.MenuLabel = driver.FindElement(By.XPath("//a[contains(text(), 'Localisation')]")).Text;
        //    Menus.Add("Localisation", Localization);

        //    MenuComponent Taxes = new MenuComponent(driver);
        //    Taxes.MenuButton = driver.FindElement(By.XPath("//a[contains(text(), 'Taxes')]"));
        //    Taxes.MenuLabel = driver.FindElement(By.XPath("//a[contains(text(), 'Taxes')]")).Text;
        //    Menus.Add("Taxes", Taxes);

        //    MenuComponent TaxClasses = new MenuComponent(driver);
        //    Taxes.MenuButton = driver.FindElement(By.XPath("//a[contains(text(), 'Tax Classes')]"));
        //    Menus.Add("Tax Classes", TaxClasses);

        //    MenuComponent Languages = new MenuComponent(driver);
        //    Taxes.MenuButton = driver.FindElement(By.XPath("//a[contains(text(), 'Languages')]"));
        //    Taxes.MenuLabel = driver.FindElement(By.XPath("//a[contains(text(), 'Languages')]")).Text;
        //    Menus.Add("Languages", Languages);

        //    MenuComponent Sales = new MenuComponent(driver);
        //    Sales.MenuButton = driver.FindElement(By.Id("menu-sale"));
        //    Menus.Add("Sales", Sales);

        //    MenuComponent Orders = new MenuComponent(driver);
        //    Orders.MenuButton = driver.FindElement(By.XPath("//a[contains(text(), 'Orders')]")); ;
        //    Menus.Add("Orders", Orders);

        //}

    }


}

