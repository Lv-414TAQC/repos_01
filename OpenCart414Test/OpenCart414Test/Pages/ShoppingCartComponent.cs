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
        //div[@class='table-responsive']/table/tbody/tr/td[@class='text-left'][last()]/div/input
        public IWebElement Image
        { get { return product.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td[@class='text-center']/a/img")); } }
        public IWebElement ProductName
        { get { return product.FindElement(By.XPath("//div[@class='table-responsive']//table/tbody/tr/td[@class='text-left'][count(a)=1]")); } }
        public IWebElement Model
        { get { return product.FindElement(By.XPath("//div[@class='table-responsive']//table/tbody/tr/td[@class='text-left'][count(*)=0]"));} } 
        //public IWebElement QuantityField
        //{ get { return product.FindElement(By.CssSelector("input:not(#input-coupon,#input-postcode,#input-voucher).form-control:not(.input-lg)")); } }
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
<<<<<<< HEAD:OpenCart414Test/OpenCart414Test/Pages/ShoppingCartComponent.cs

        public ShoppingCartComponent(IWebElement product)
=======
       
            
        private void CheckElements()
>>>>>>> 06cc0ee49a793feda83055819c415caada4fd5ad:OpenCart414Test/OpenCart414Test/Pages/ShoppingCartPageComponent.cs
        {
            this.product = product;
            //CheckElements();

        }

        //private void CheckElements()
        //{
        //    // TODO Develop Custom Exception
        //    IWebElement temp = Image;
        //    temp = ProductName;
        //    temp = Model;
        //    temp = UnitPrice;
        //    temp = QuantityField;
        //    temp = RemoveButton;
        //    temp = UpdateButton;
        //    temp = Total;

        //}

        // Page Object
        
        //Functional
        public string GetProductName()
        {
            return ProductName.Text;
        }
        public string GetModel()
        {
            return Model.Text;
        }
        public string GetTextQuantityFieldString()
        {
            return FieldValue.GetAttribute(TopPart.TAG_ATTRIBUTE_VALUE); 
        }
        public int GetTextQuantityField()
        {
            return Convert.ToInt32(FieldValue.GetAttribute(TopPart.TAG_ATTRIBUTE_VALUE)); 
        }
        
        public void ClickRemoveButton()
        {
            RemoveButton.Click();
        }
        public void ClickUpdateButton()
        {
            UpdateButton.Click();
        }
        public double GetUnitPrice()
        {
<<<<<<< HEAD:OpenCart414Test/OpenCart414Test/Pages/ShoppingCartComponent.cs
            return Convert.ToDouble(UnitPrice.Text.Substring(1, 5).Replace('.', ','));//TODO localization
=======
            QuantityField.Clear();
            QuantityField.SendKeys(text);

>>>>>>> 06cc0ee49a793feda83055819c415caada4fd5ad:OpenCart414Test/OpenCart414Test/Pages/ShoppingCartPageComponent.cs
        }
        public double GetTotal()
        {
            return Convert.ToDouble((Total.Text.Substring(1, 5).Replace('.', ',')));
        }
        //met convert 
        
        public void SandKeysQuantityField(string text)
        {
            
            QuantityField.Clear();
            QuantityField.SendKeys(text);
           
        }
        public void ClearQuantityField()
        {
            QuantityField.Clear();
            
        }
        
        //Business logic
    }

}
