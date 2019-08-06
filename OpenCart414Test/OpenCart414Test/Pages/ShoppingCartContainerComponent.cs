using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    class ShoppingCartContainerComponent
    {
        private IWebElement product;

        public IWebElement ProductImage
        { get { return product.FindElement(By.CssSelector("table.table-striped .text-center > a > img.img-thumbnail")); } }
        public IWebElement ProductName
        { get { return product.FindElement(By.CssSelector("table.table-striped .text-left > a")); } }
        public IWebElement ProductPrice
        { get { return product.FindElement(By.XPath("//table[@class='table table-striped']//td[contains(text(),'.')]")); } }
        public IWebElement ProductQuantity
        { get { return product.FindElement(By.XPath("//table[@class='table table-striped']//td[contains(text(),'x')]")); } }
        public IWebElement ProductRemoveButton
        { get { return product.FindElement(By.CssSelector("button.btn.btn-danger.btn-xs")); } }


        public ProductComponent(IWebElement product)
        {
            this.product = product;
            CheckElements();
        }

        private void CheckElements()
        {
            // TODO Develop Custom Exception
            IWebElement temp = ProductImage;
            temp = ProductName;
            temp = ProductPrice;
            temp = ProductQuantity;
            temp = ProductRemoveButton;
            // TODO All Web Elements
        }
    }
}
