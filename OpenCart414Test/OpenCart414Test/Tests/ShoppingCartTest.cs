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
    class ShoppingCartTest : TestRunner
    {
        private ShoppingCartPage shoppingCartPage;
        // DataProvider
        private static readonly object[] ProductToAdd =
        {
        new object[] { ProductRepository.GetIPhone() }
     };
        [Test, TestCaseSource(nameof(ProductToAdd))]
        public void Remove(Product addingProduct1)
        {
            HomePage homePage = LoadApplication();
            //ProductsContainerComponent productsContainerComponent = homePage.getProductComponentsContainer();
            //ProductComponent productComponent = productsContainerComponent
            //    .GetProductComponentByName(addingProduct1.Title);
            Thread.Sleep(2000);
            //productComponent.ClickAddToCartButton();
            homePage.AddProductToCart(addingProduct1);
            ShoppingCartEmptyPage shoppingCartEmptyPage = homePage
                .GotoShoppingCartPage()
                .NotUpdateMessage(addingProduct1, ShoppingCartData.INVALID_CHECK_ZERO);
            Thread.Sleep(2000);
            Assert.IsTrue(shoppingCartEmptyPage.Equal());
            //Thread.Sleep(2000);
            homePage = shoppingCartEmptyPage.GoToHomePage();
            homePage.AddProductToCart(addingProduct1);
            //productComponent.ClickAddToCartButton();
            shoppingCartEmptyPage = homePage
                .GotoShoppingCartPage()
                .ClearQuantity(addingProduct1);
            Thread.Sleep(1000); // only for presentation
            Assert.IsTrue(shoppingCartEmptyPage.Equal());
            homePage = shoppingCartEmptyPage.GoToHomePage();
            homePage.AddProductToCart(addingProduct1);
            shoppingCartEmptyPage = homePage
                .GotoShoppingCartPage()
                .NotUpdateMessage(addingProduct1, ShoppingCartData.INVALID_CHECK_SYM);
            Thread.Sleep(2000);
            Assert.IsTrue(shoppingCartEmptyPage.Equal());
            homePage = shoppingCartEmptyPage.GoToHomePage();
            homePage.AddProductToCart(addingProduct1);
            shoppingCartEmptyPage = homePage
                .GotoShoppingCartPage()
                .GoToEmptyPage(addingProduct1);
            Thread.Sleep(2000);
            Assert.IsTrue(shoppingCartEmptyPage.Equal());
        }

        [Test, TestCaseSource(nameof(ProductToAdd))]
        public void Update(Product addingProduct1)
        {
            HomePage homePage = LoadApplication();
            homePage.AddProductToCart(addingProduct1);
            Thread.Sleep(2000);
            ShoppingCartMessage shoppingCartPageMessage = homePage
                .GotoShoppingCartPage()
                .UpdateMessage(addingProduct1, ShoppingCartData.VALID_CHECK);
            Assert.IsTrue(shoppingCartPageMessage.GetUpdateMessage().Contains(ShoppingCartData.UPDATE_MESSAGE));
            Thread.Sleep(2000);
        }
        [Test, TestCaseSource(nameof(ProductToAdd))]
        public void Price(Product addingProduct1)
        {
            HomePage homePage = LoadApplication();
            homePage.AddProductToCart(addingProduct1);
            Thread.Sleep(2000);
            shoppingCartPage = homePage
                .GotoShoppingCartPage();
            Assert.IsTrue(shoppingCartPage
                .GetShoppingCartTitleText()
                .Contains(ShoppingCartData.CART_IS_OPEN));
            Console.WriteLine("1");
            Assert.AreEqual(shoppingCartPage
                .GetShoppingCartComponentByName(addingProduct1.Title)
                .GetUnitPrice(),
                shoppingCartPage
                .GetShoppingCartComponentByName(addingProduct1.Title).GetTotal());
            shoppingCartPage = shoppingCartPage.UpdateMessage(addingProduct1, ShoppingCartData.VALID_CHECK);
            Thread.Sleep(1000); // only for presentation
            Assert.IsTrue(shoppingCartPage.GetShoppingCartComponentByName(addingProduct1.Title)
                .GetTextQuantityField() == ShoppingCartData.VALID_CHECK);
            Console.WriteLine("3");
            Assert.IsTrue((shoppingCartPage
                .GetShoppingCartComponentByName(addingProduct1.Title)
                .GetUnitPrice() * shoppingCartPage
                .GetShoppingCartComponentByName(addingProduct1.Title)
                .GetTextQuantityField()) == shoppingCartPage
                .GetShoppingCartComponentByName(addingProduct1.Title).GetTotal());
            Console.WriteLine("4");

            Console.WriteLine(shoppingCartPage.GetShoppingCartComponentByName(addingProduct1.Title).GetTotal());
            Console.WriteLine(shoppingCartPage.GetTablePriceTotal());
            Assert.IsTrue(shoppingCartPage
                .GetShoppingCartComponentByName(addingProduct1.Title)
                .GetTotal() == shoppingCartPage.GetTablePriceTotal());
            Console.WriteLine("5");



            //Assert.IsTrue(ecotax + subtotal + vat == total);
            //Console.WriteLine(total + " == " + Convert.ToDouble(totalprice.Substring(1, 5).Replace('.', ',')));

            //Assert.IsTrue(vat == ((subtotal * 20) / 100));

        }
    }
}

