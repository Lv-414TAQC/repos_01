using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenCart414Test.Tools;

namespace OpenCart414Test.Pages
{
    

    public class ShoppingCartMessage : ShoppingCartPage
    {
        //private const string TABLE_PRICE_COMPONENT_XPATH = "//div[@class='row']/div/table/tbody/tr/td";
        //public TablePriceComponent tablePriceAfterUpdate;
        public IWebElement UpdateMess
        { get { return driver.FindElement(By.CssSelector("div.alert.alert-success")); } }
        public ShoppingCartMessage(IWebDriver driver) : base(driver)
        {
          
        }

        public string GetUpdateMessage()
        {
            return UpdateMess.Text;
        }

        //Business Logic
        public HomePage GoToHomePage()
        {
            ClickContinueShopping();
            return new HomePage(driver);
        }
       


        //public IList<string> GetAllTablePriceComponentsAfterUpdate()
        //{
        //    CreateTablePriceComponentAfterUpdate(By.XPath(TABLE_PRICE_COMPONENT_XPATH));
        //    return GetTablePriceComponentAfterUpdate().GetTablePriceListText();

        //}


        //protected TablePriceComponent CreateTablePriceComponentAfterUpdate(By searchLocator)
        //{
        //    tablePriceAfterUpdate = new TablePriceComponent(driver, searchLocator);
        //    return GetTablePriceComponentAfterUpdate();
        //}
        //protected TablePriceComponent GetTablePriceComponentAfterUpdate()
        //{
        //    if (tablePriceAfterUpdate == null)
        //    {
        //        // TODO Develop Custom Exception 
        //        throw new Exception("TablePriceComponent is null.");
        //    }
        //    return tablePriceAfterUpdate;
        //}
        //// Business Logic
        //public RegularExpressions GetRegularExpressionsAfterUpdate()
        //{
        //    return new RegularExpressions();
        //}
        //public decimal GetTablePriceTotalAfterUpdate()
        //{
        //    CreateTablePriceComponentAfterUpdate(By.XPath(TABLE_PRICE_COMPONENT_XPATH));
        //    return GetRegularExpressionsAfterUpdate().RegexCurrency(GetTablePriceComponentAfterUpdate().GetTotalForPageSC());

        //}
        //public decimal GetTablePriceSubTotalAfterUpdate()
        //{
        //    CreateTablePriceComponentAfterUpdate(By.XPath(TABLE_PRICE_COMPONENT_XPATH));
        //    return GetRegularExpressionsAfterUpdate().RegexCurrency(GetTablePriceComponentAfterUpdate().GetSubTotal());

        //}
        //public decimal GetTablePriceEcoTaxAfterUpdate()
        //{
        //    CreateTablePriceComponentAfterUpdate(By.XPath(TABLE_PRICE_COMPONENT_XPATH));
        //    return GetRegularExpressionsAfterUpdate().RegexCurrency(GetTablePriceComponentAfterUpdate().GetEcoTax());

        //}
        //public decimal GetTablePriceVatAfterUpdate()
        //{
        //    CreateTablePriceComponentAfterUpdate(By.XPath(TABLE_PRICE_COMPONENT_XPATH));
        //    return GetRegularExpressionsAfterUpdate().RegexCurrency(GetTablePriceComponentAfterUpdate().GetVat());

        //}
    }
}
