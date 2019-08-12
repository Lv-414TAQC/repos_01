using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenCart414Test.Data;
using OpenCart414Test.Pages;

namespace OpenCart414Test.Tests
{

    [TestFixture]
    class ShoppingCartRemove : TestRunner
    {
        
        private ShoppingCartEmptyPage shoppingCartEmptyPage;
        
        // DataProvider
        private static readonly object[] ProductToAdd =
        {
        new object[] { ProductRepository.GetIPhone() }
        };
        [Test, TestCaseSource(nameof(ProductToAdd))]
        public void Remove(Product addingProduct)
        {
            HomePage homePage = LoadApplication();  
            Thread.Sleep(1000); // only for presentation
            homePage.AddProductToCart(addingProduct);
            Thread.Sleep(1000); // only for presentation
            shoppingCartEmptyPage = homePage
                .GotoShoppingCartPage()
                .GoToEmptyPage(addingProduct);
            Thread.Sleep(1000); // only for presentation
            Assert.IsTrue(shoppingCartEmptyPage.Equal());
            Assert.AreEqual(ShoppingCartEmptyPage.CART_IS_EMPTY, shoppingCartEmptyPage.GetInfoMessageText());
            homePage = shoppingCartEmptyPage.GoToHomePage();
            Thread.Sleep(1000); // only for presentation
        }

        
        
    }
}

