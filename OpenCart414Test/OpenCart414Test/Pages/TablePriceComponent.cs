using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    class TablePriceComponent
    {
        //private IWebDriver driver;
        protected IWebDriver driver;
        public TablePriceComponent()
        {

        }
        public IWebElement Sub_total
        { get { return driver.FindElement(By.XPath("//div[@class='row']/div/table/tbody/tr/td/strong[text() ='Sub-Total:']/../following-sibling::td")); } }
        public IWebElement Sub_total_Name
        { get { return driver.FindElement(By.XPath("//div[@class='row']/div/table/tbody/tr/td/strong[text() ='Sub-Total:']")); } }
        public IWebElement Eco_tax
        { get { return driver.FindElement(By.XPath("//div[@class='row']/div/table/tbody/tr/td/strong[text() ='Eco Tax (-2.00):']/../following-sibling::td")); } }
        public IWebElement Eco_tax_Name
        { get { return driver.FindElement(By.XPath("//div[@class='row']/div/table/tbody/tr/td/strong[text() ='Eco Tax (-2.00):']")); } }
        public IWebElement Vat
        { get { return driver.FindElement(By.XPath("//div[@class='row']/div/table/tbody/tr/td/strong[text() ='VAT (20%):']/../following-sibling::td")); } }
        public IWebElement Vat_Name
        { get { return driver.FindElement(By.XPath("//div[@class='row']/div/table/tbody/tr/td/strong[text() ='VAT (20%):']")); } }
        public IWebElement total
        { get { return driver.FindElement(By.XPath("//div[@class='row']/div/table/tbody/tr/td/strong[text() ='Total:']/../following-sibling::td")); } }
        public IWebElement total_Name
        { get { return driver.FindElement(By.XPath("//div[@class='row']/div/table/tbody/tr/td/strong[text() ='Total:']")); } }

        public TablePriceComponent(IWebDriver driver)
        {
            this.driver = driver;
            CheckElements();
            InitElements();
        }

        private void CheckElements()
        {
            // TODO Develop Custom Exception
            //IWebElement temp = ViewCartLink;
            //temp = CheckOutLink; // TODO All Web Elements
        }

        //private void InitElements()
        //{
        //    itemsTable = new List<ShoppingCartContainerComponent>();
        //    foreach (IWebElement current in driver.FindElements(By.CssSelector(ITEMS_TABLE_CSSSELECTOR)))
        //    {
        //        itemsTable.Add(new ShoppingCartContainerComponent(current));
        //    }
        //}
        //Page Object
        public string GetSub_total_NameText()
        {
            return Sub_total_Name.Text;
        }
        public string GetSub_totalText()
        {
            return Sub_total.Text;
        }
        public string GetEco_Taxl_NameText()
        {
            return Eco_tax_Name.Text;
        }
        public string GetEco_taxText()
        {
            return Eco_tax.Text;
        }
        public string GetVat_NameText()
        {
            return Vat_Name.Text;
        }
        public string GetVatText()
        {
            return Vat.Text;
        }
        public string GetTotalText()
        {
            return total.Text;
        }
        public string Get_total_NameText()
        {
            return total_Name.Text;
        }
    }
}
