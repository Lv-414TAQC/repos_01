using OpenCart414Test.Tools;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OpenCart414Test.Pages
{
    public class ShoppingCartComponent
    {
        private IWebElement product;
        
        public IWebElement Image =>
        product.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td[@class='text-center']/a/img"));
        public IWebElement ProductName =>
        product.FindElement(By.XPath("//div[@class='table-responsive']//table/tbody/tr/td[@class='text-left'][count(a)=1]")); 
        public IWebElement Model =>
        product.FindElement(By.XPath("//div[@class='table-responsive']//table/tbody/tr/td[@class='text-left'][count(*)=0]"));
        public IWebElement QuantityField =>
        product.FindElement(By.XPath("//input[contains(@name,'quantity')]"));
        public IWebElement UpdateButton => 
        product.FindElement(By.XPath("//div[@class='table-responsive']//table/tbody/tr/td[@class='text-left'][last()]/div/span/button[@type='submit']")); 
        public IWebElement RemoveButton =>
        product.FindElement(By.CssSelector("button.btn.btn-danger:not(.btn-xs)")); 
        public IWebElement UnitPrice =>
        product.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td/a[contains(text(),'iPhone')]/../following-sibling::td[@class ='text-right'][last()-1]")); 
        public IWebElement Total =>
        product.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td/a[contains(text(),'iPhone')]/../following-sibling::td[@class ='text-right']/following-sibling::td")); 
        public IWebElement FieldValue =>
        product.FindElement(By.XPath("//input[contains(@name,'quantity')]")); 
        
        public ShoppingCartComponent(IWebElement product)
        {
            this.product = product;
          
        }
        
        // Page Object
        
        public string GetProductName()
        {
            return ProductName.Text;
        }
        public string GetModel()
        {
            return Model.Text;
        }
        public string GetTextQuantityField()
        {
            return FieldValue.GetAttribute(TopPart.TAG_ATTRIBUTE_VALUE); 
        }
        
        public void ClickRemoveButton()
        {
            RemoveButton.Click();
        }
        public void ClickUpdateButton()
        {
            UpdateButton.Click();
        }
        public RegularExpressions GetRegularExpressions()
        {
            return new RegularExpressions();
        }
        public decimal GetUnitPrice()
        {
            return GetRegularExpressions().ConvertStringCurrency(UnitPrice.Text);
            
        }
        public decimal GetTotal()
        {
            return GetRegularExpressions().ConvertStringCurrency(Total.Text);
           
        }
       
        
        public void SandKeysQuantityField(string text)
        {
            
            QuantityField.Clear();
            QuantityField.SendKeys(text);
           
        }
        public void ClearQuantityField()
        {
            QuantityField.Clear();
            
        }
        
        
    }

}
