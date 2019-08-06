using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    class TablePriceComponent
    {
        public IWebElement Sub_total
        { get { return driver.FindElement(By.XPath("//div[@class='row']/div/table/tbody/tr/td/strong[text() ='Sub-Total:']/../following-sibling::td")); } }
        public IWebElement Eco_tax
        { get { return driver.FindElement(By.XPath("//div[@class='row']/div/table/tbody/tr/td/strong[text() ='Eco Tax (-2.00):']/../following-sibling::td")); } }
        public IWebElement Vat
        { get { return driver.FindElement(By.XPath("//div[@class='row']/div/table/tbody/tr/td/strong[text() ='VAT (20%):']/../following-sibling::td")); } }
        public IWebElement total
        { get { return driver.FindElement(By.XPath("//div[@class='row']/div/table/tbody/tr/td/strong[text() ='Total:']/../following-sibling::td")); } }

        //Page Object
        public string GetSub_totalText()
        {
            return Sub_total.Text;
        }
        public string GetEco_taxText()
        {
            return Eco_tax.Text;
        }
        public string GetVatText()
        {
            return Vat.Text;
        }
        public string GetTotalText()
        {
            return total.Text;
        }
    }
}
