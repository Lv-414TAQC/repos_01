using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class ShoppingCartPageComponent
    {
        private const string UPDATE_MESSAGE = "Success: You have modified your shopping cart!";
        private IWebElement product;
        protected IWebDriver driver;
        //private IWebDriver driver;
        public ShoppingCartPageComponent(IWebElement product)
        {
            this.product = product;
            CheckElements();

        }
        public IWebElement Image
        { get { return product.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td[@class='text-center']/a/img")); } }
        public IWebElement ProductName
        { get { return product.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr//td[@class='text-left']/a")); } }
        public IWebElement Modal
        { get { return product.FindElement(By.XPath("//div[@class='table-responsive']//table/tbody/tr/td[@class='text-left'][count(*)=0]"); } } //??????/
        public IWebElement QuantityField
        { get { return product.FindElement(By.CssSelector("input[name*='quantity']")); } }
        public IWebElement UpdateButton
        { get { return product.FindElement(By.CssSelector("button.btn.btn-primary")); } }
        public IWebElement RemoveButton
        { get { return product.FindElement(By.CssSelector("button.btn.btn-danger:not(.btn-xs)")); } }
        public IWebElement UnitPrice
        { get { return product.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td/a[contains(text(),'iPhone')]/../following-sibling::td[@class ='text-right']")); } }
        public IWebElement Total
        { get { return product.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td/a[contains(text(),'iPhone')]/../following-sibling::td[@class ='text-right']/following-sibling::td")); } }
        public IWebElement FieldValue
        { get { return product.FindElement(By.CssSelector(".input-group.btn-block > input")); } }
       
            
        private void CheckElements()
        {
            // TODO Develop Custom Exception
            IWebElement temp = Image;
            temp = ProductName;
            temp = Modal;
            temp = UnitPrice;
            temp = QuantityField;
            temp = RemoveButton;
            temp = UpdateButton;
            temp = Total;

        }

        // Page Object


        //public IWebElement GetImage()
        //{
        //    return Image;
        //}
        //Functional
        public string GetProductName()
        {
            return ProductName.Text;
        }
        public string GetModal()
        {
            return Modal.Text;
        }
        public string GetTextQuantityField()
        {
            return FieldValue.GetAttribute("value");
        }
        public void ClickRemoveButton()
        {
            RemoveButton.Click();
        }
        public void ClickUpdateButton()
        {
            UpdateButton.Click();
        }


        //Business logic
        public void SandKeysQuantityField(string text)
        {
            QuantityField.Clear();
            QuantityField.SendKeys(text);

        }
        public string UpdateMessage()
        {
            ClickUpdateButton();
            return UPDATE_MESSAGE;
        }
        public ShoppingCartEmptyPage GoToEmptyPage()
        {
            ClickRemoveButton();
            return new ShoppingCartEmptyPage(driver);
        }
    }

}
