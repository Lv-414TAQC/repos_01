using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
        public void DeleteProduct(Product addingProduct1, Product addingProduct2)
        {
            HomePage homePage = LoadApplication();
            homePage.AddProductToCart(addingProduct1);
            Thread.Sleep(2000);        //Only for presentation
            homePage.AddProductToCart(addingProduct2);

            Thread.Sleep(2000);
            /*
            Assert.AreEqual(addingProduct1.Title, homePage.GetCartProductContainer()
               .GetItemByName(addingProduct1).GetProductNameText());

            homePage.GetCartProductContainer(); //for reopen page

            Assert.AreEqual(addingProduct2.Title, homePage.GetCartProductContainer()
                .GetItemByName(addingProduct2).GetProductNameText());
            */

            Thread.Sleep(2000);          //Only for presentation
            homePage.GetCartProductContainer().RemoveProductByName(addingProduct2);

            Thread.Sleep(2000);          //Only for presentation

            homePage.GetCartProductContainer().RemoveProductByName(addingProduct1);
           //Only for presentation
            //Add assert on EmptyPage
            Thread.Sleep(5000);
        }


        [Test, TestCaseSource(nameof(ProductToAdd))]
        public void AddProduct(Product addingProduct1, Product addingProduct2)
        {
            HomePage homePage = LoadApplication();

            homePage.AddProductToCart(addingProduct1);
            Thread.Sleep(2000);
            homePage.AddProductToCart(addingProduct2);

            Thread.Sleep(2000);   //Only for presentation

            Assert.AreEqual(addingProduct1.Title, homePage.GetCartProductContainer()
                 .GetItemByName(addingProduct1).GetProductNameText());

            homePage.GetCartProductContainer(); //for reopen page

            Assert.AreEqual(addingProduct2.Title, homePage.GetCartProductContainer()
                .GetItemByName(addingProduct2).GetProductNameText());

            Thread.Sleep(2000);  //Only for presentation
        }

        [Test, TestCaseSource(nameof(ProductToAdd))]
        public void CheckTotalSum(Product addingProduct1, Product addingProduct2)
        {
            HomePage homePage = LoadApplication();
            homePage.AddProductToCart(addingProduct1);
            Thread.Sleep(2000);    //Only for presentation
            homePage.AddProductToCart(addingProduct2);

            Thread.Sleep(5000);    //Only for presentation
            homePage.GetCartProductContainer().GetTotalSumProducts();

            homePage.GetCartProductContainer(); //for reopen page

            homePage.GetCartProductContainer().GetTablePriceTotal();

            //Add assert compare total and GetTotalSumProduct
        }
    }
}
