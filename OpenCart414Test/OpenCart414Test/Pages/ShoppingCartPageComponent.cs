using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    class ShoppingCartPageComponent
    {
        protected IWebDriver driver;
        //private IWebDriver driver;
        public ShoppingCartPageComponent()
        {

        }
        public IWebElement Image
        { get { return driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td[@class='text-center']/a/img")); } }
        public IWebElement ProductName
        { get { return driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr//td[@class='text-left']/a")); } }
        public IWebElement Modal
        { get { return driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td/td/following-sibling::td"));} } //??????/
        public IWebElement QuantityField
        { get { return driver.FindElement(By.CssSelector("input: not(#input-coupon,#input-postcode,#input-voucher).form-control:not(.input-lg)")); } }
        public IWebElement UpdateButton
        { get { return driver.FindElement(By.CssSelector("button.btn.btn-primary")); } }
        public IWebElement RemoveButton
        { get { return driver.FindElement(By.CssSelector("button.btn.btn-danger:not(.btn-xs)")); } }
        public IWebElement UnitPrice
        { get { return driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td/a[contains(text(),'iPhone')]/../following-sibling::td[@class ='text-right']")); } }
        public IWebElement Total
        { get { return driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td/a[contains(text(),'iPhone')]/../following-sibling::td[@class ='text-right']/following-sibling::td")); } }

        // Page Object

        
        //public IWebElement GetImage()
        //{
        //    return Image;
        //}
        public string GetProductName()
        {
            return ProductName.Text;
        }
        public string GetModal()
        {
            return Modal.Text;
        }
       
        public void SandKeysQuantityField(string text)
        {
            QuantityField.Clear();
            QuantityField.SendKeys(text);
        }
        public void ClickRemoveButton()
        {
            RemoveButton.Click();
        }
        public void ClickUpdateButton()
        {
            UpdateButton.Click();
        }
    }

}
