using NUnit.Framework;
using OpenCart414Test.Data;
using OpenCart414Test.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCart414Test.Tests
{
    [TestFixture]
    class ShoppingCartUpdate : TestRunner
    {
        private ShoppingCartEmptyPage shoppingCartEmptyPage;
        // DataProvider
        private static readonly object[] ProductToAdd =
        {
        new object[] { ProductRepository.GetIPhone() }
        };
        [Test, TestCaseSource(nameof(ProductToAdd))]
        public void Update(Product addingProduct)
        {
            HomePage homePage = LoadApplication();
            Thread.Sleep(1000); // only for presentation
            homePage.AddProductToCart(addingProduct);
            Thread.Sleep(1000); // only for presentation
            shoppingCartEmptyPage = homePage
                 .GotoShoppingCartPage()
                 .NotUpdateMessage(addingProduct, ShoppingCartData.INVALID_CHECK_ZERO);
            Thread.Sleep(1000); // only for presentation
            Assert.IsTrue(shoppingCartEmptyPage.Equal());
            homePage = shoppingCartEmptyPage.GoToHomePage();
            Thread.Sleep(1000); // only for presentation
            homePage.AddProductToCart(addingProduct);
            Thread.Sleep(1000); // only for presentation
            shoppingCartEmptyPage = homePage
                .GotoShoppingCartPage()
                .ClearQuantity(addingProduct);
            Thread.Sleep(1000); // only for presentation
            Assert.IsTrue(shoppingCartEmptyPage.Equal());
            homePage = shoppingCartEmptyPage.GoToHomePage();
            Thread.Sleep(1000); // only for presentation
            homePage.AddProductToCart(addingProduct);
            Thread.Sleep(1000); // only for presentation
            shoppingCartEmptyPage = homePage
                .GotoShoppingCartPage()
                .NotUpdateMessage(addingProduct, ShoppingCartData.INVALID_CHECK_SYM);
            Thread.Sleep(1000); // only for presentation
            Assert.IsTrue(shoppingCartEmptyPage.Equal());
            homePage = shoppingCartEmptyPage.GoToHomePage();
            Thread.Sleep(1000); // only for presentation
            homePage.AddProductToCart(addingProduct);
            Thread.Sleep(1000); // only for presentation
            ShoppingCartMessage shoppingCartPageUpdate = homePage
                .GotoShoppingCartPage()
                .UpdateMessage(addingProduct, ShoppingCartData.VALID_CHECK);
            Assert.IsTrue(shoppingCartPageUpdate.GetUpdateMessage()
                .Contains(ShoppingCartData.UPDATE_MESSAGE));
            Thread.Sleep(1000); // only for presentation
        }
        
    }
}
