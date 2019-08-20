using System.Threading;
using NUnit.Framework;
using OpenCart414Test.Data;
using OpenCart414Test.Pages;


namespace OpenCart414Test.Tests
{
    [TestFixture]
    class AddToCartTests : TestRunner
    {  
        // DataProvider
        private static readonly object[] ProductToAdd =
        {
            new object[] { ProductRepository.GetIPhone(), ProductRepository.GetMacBook() }
        };

        [Test, TestCaseSource(nameof(ProductToAdd))]
        public void AddProduct(Product addingProduct1, Product addingProduct2)
        {
            HomePage homePage = LoadApplication();

            homePage.AddProductToCart(addingProduct1);
            Thread.Sleep(1500);   //Only for presentation
            homePage.AddProductToCart(addingProduct2);
            Thread.Sleep(1500);   //Only for presentation

            WaitCheckOutLink();
            Assert.AreEqual(addingProduct1.Title, homePage.OpenCartButton()
                 .GetProductByName(addingProduct1).GetProductNameText());
            Thread.Sleep(1500);   //Only for presentation
            Assert.AreEqual(addingProduct2.Title, homePage.GetCartContainerComponent()
                .GetProductByName(addingProduct2).GetProductNameText());

            Assert.IsTrue(homePage.GetCartButtonText().Contains(HomePage.TWO_PRODUCT));
        }


        [Test, TestCaseSource(nameof(ProductToAdd))]
        public void CheckTotalSum(Product addingProduct1, Product addingProduct2)
        {
            HomePage homePage = LoadApplication();
            homePage.AddProductToCart(addingProduct1);
            Thread.Sleep(1500);   //Only for presentation
            homePage.AddProductToCart(addingProduct2);
            Thread.Sleep(1500);   //Only for presentation

            WaitCheckOutLink();

            Assert.AreEqual(homePage.OpenCartButton().GetTotalSumProducts(),
            homePage.GetCartContainerComponent().GetTablePriceTotal()); 
            Thread.Sleep(1500);   //Only for presentation
        }


        [Test, TestCaseSource(nameof(ProductToAdd))]
        public void DeleteProduct(Product addingProduct1, Product addingProduct2)
        {
            HomePage homePage = LoadApplication();
            homePage.AddProductToCart(addingProduct1);
            homePage.AddProductToCart(addingProduct2);

            wait.Until((drv) => {
                return homePage.GetCartButtonText().Contains(HomePage.TWO_PRODUCT);
            });
            Assert.IsTrue(homePage.GetCartButtonText().Contains(HomePage.TWO_PRODUCT));
            Assert.AreEqual(addingProduct1.Title, homePage.OpenCartButton()
               .GetProductByName(addingProduct1).GetProductNameText());      
            Assert.AreEqual(addingProduct2.Title, homePage.GetCartContainerComponent()
                .GetProductByName(addingProduct2).GetProductNameText());

            homePage.GetCartContainerComponent().RemoveProduct(addingProduct2);

            wait.Until((drv) => {
                return homePage.GetCartButtonText().Contains(HomePage.ONE_PRODUCT);
            });
            Assert.IsTrue(homePage.GetCartButtonText().Contains(HomePage.ONE_PRODUCT));

            homePage.OpenCartButton().RemoveProduct(addingProduct1);

            wait.Until((drv) => {
                return homePage.GetCartButtonText().Contains(HomePage.ZERO_PRODUCT);
            });
            Assert.IsTrue(homePage.GetCartButtonText().Contains(HomePage.ZERO_PRODUCT));
            Assert.IsTrue(homePage.OpenEmptyCartButton().GetInfoMessageText().Length > 0);   
        }
    }
}
