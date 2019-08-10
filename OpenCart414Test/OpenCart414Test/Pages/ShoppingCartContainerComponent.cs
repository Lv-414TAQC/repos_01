using OpenQA.Selenium;

namespace OpenCart414Test.Pages
{
    class ShoppingCartContainerComponent
    {
        private const string PRODUCT_PRICE_CSSSELECTOR = "table.table.table-striped td.text-right:nth-child(4)";     //By.XPath("//table[@class='table table-striped']//td[contains(text(),'.')]")
        private const string PRODUCT_QUANTITY_CSSSELECTOR = "table.table.table-striped td.text-right:nth-child(3)";  //By.XPath("//table[@class='table table-striped']//td[contains(text(),'x')]")

        private IWebElement product;

        public IWebElement ProductImage
        { get { return product.FindElement(By.CssSelector("table.table-striped .text-center > a > img.img-thumbnail")); } }
        public IWebElement ProductName
        { get { return product.FindElement(By.CssSelector("table.table-striped .text-left > a")); } }

        public IWebElement ProductPrice
        { get { return product.FindElement(By.CssSelector(PRODUCT_PRICE_CSSSELECTOR)); } }
        public IWebElement ProductQuantity
        { get { return product.FindElement(By.CssSelector(PRODUCT_QUANTITY_CSSSELECTOR)); } }

        public IWebElement ProductRemoveButton
        { get { return product.FindElement(By.CssSelector("button.btn.btn-danger.btn-xs")); } }


        public ShoppingCartContainerComponent(IWebElement product)
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

        // Page Object

        //TODO ProductImage

        //ProductName
        public string GetProductNameText()
        {
            return ProductName.Text;
        }

        // ProductPrice
        public string GetProductPriceText()
        {
            return ProductPrice.Text;
        }

        //ProductQuantity
        public string GetProductQuantityText()
        {
            return ProductQuantity.Text;
        }

        //ProductRemoveButton
        public void ClickProductRemoveButton()
        {
            ProductRemoveButton.Click();
        }

       
        // Functional

        // Business Logic

    }
}
