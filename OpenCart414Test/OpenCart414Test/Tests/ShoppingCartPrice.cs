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
    class ShoppingCartPrice : TestRunner
    {
        private ShoppingCartPage shoppingCartPage;
        private ShoppingCartMessage shoppingCartPageUpdate;
        // DataProvider
        private static readonly object[] ProductToAdd =
        {
        new object[] { ProductRepository.GetIPhone() }
        };
        [Test, TestCaseSource(nameof(ProductToAdd))]
        public void Price(Product addingProduct)
        {
            HomePage homePage = LoadApplication();
            Thread.Sleep(1000); // only for presentation
            homePage.AddProductToCart(addingProduct);
            Thread.Sleep(1000); // only for presentation
            shoppingCartPage = homePage
                .GotoShoppingCartPage();
            Assert.IsTrue(shoppingCartPage
                .GetShoppingCartTitleText()
                .Contains(ShoppingCartData.CART_IS_OPEN));

            Assert.AreEqual(shoppingCartPage
                .UnitPrice(addingProduct),
                shoppingCartPage
                .TotalPrice(addingProduct));
        }

        [Test, TestCaseSource(nameof(ProductToAdd))]
        public void PriceAfterUpdate(Product addingProduct)
        {
            HomePage homePage = LoadApplication();
            Thread.Sleep(1000); // only for presentation
            homePage.AddProductToCart(addingProduct);
            Thread.Sleep(1000); // only for presentation
            shoppingCartPage = homePage
                .GotoShoppingCartPage();
            shoppingCartPageUpdate = shoppingCartPage
                .UpdateMessage(addingProduct, ShoppingCartData.VALID_CHECK);
            Thread.Sleep(1000); // only for presentation

            Assert.IsTrue(shoppingCartPageUpdate
                .GetData(addingProduct) == ShoppingCartData.VALID_CHECK);

            Assert.IsTrue((shoppingCartPageUpdate
                .UnitPrice(addingProduct) * shoppingCartPageUpdate.GetIntData(addingProduct))
                == shoppingCartPageUpdate.TotalPrice(addingProduct));
        }

        [Test, TestCaseSource(nameof(ProductToAdd))]
        public void PriceEqual(Product addingProduct)
        {
            HomePage homePage = LoadApplication();
            Thread.Sleep(1000); // only for presentation
            homePage.AddProductToCart(addingProduct);
            Thread.Sleep(1000); // only for presentation
            shoppingCartPage = homePage
                .GotoShoppingCartPage();
            shoppingCartPageUpdate = shoppingCartPage
                .UpdateMessage(addingProduct, ShoppingCartData.VALID_CHECK);
            Thread.Sleep(1000); // only for presentation
            Console.WriteLine(shoppingCartPageUpdate.TotalPrice(addingProduct)  //only for presentation
                + "==" + shoppingCartPageUpdate.GetTablePriceTotal());
            Assert.IsTrue(shoppingCartPageUpdate.TotalPrice(addingProduct)
                == shoppingCartPageUpdate.GetTablePriceTotal());
        }

        [Test, TestCaseSource(nameof(ProductToAdd))]
        public void PriceInTable(Product addingProduct)
        {
            HomePage homePage = LoadApplication();
            Thread.Sleep(1000); // only for presentation
            homePage.AddProductToCart(addingProduct);
            Thread.Sleep(1000); // only for presentation
            shoppingCartPage = homePage
                .GotoShoppingCartPage();
            shoppingCartPageUpdate = shoppingCartPage
                .UpdateMessage(addingProduct, ShoppingCartData.VALID_CHECK);
            Thread.Sleep(1000); // only for presentation
            Console.WriteLine(shoppingCartPageUpdate.GetTablePriceSubTotal()
                + " + " + shoppingCartPageUpdate.GetTablePriceEcoTax()
                 + " + " + shoppingCartPageUpdate.GetTablePriceVat()        //only for presentation
                + " == " + shoppingCartPageUpdate.GetTablePriceTotal());
            Assert.IsTrue(shoppingCartPageUpdate.GetTablePriceSubTotal()
                + shoppingCartPageUpdate.GetTablePriceEcoTax()
                + shoppingCartPageUpdate.GetTablePriceVat()
                == shoppingCartPageUpdate.GetTablePriceTotal());

            Console.WriteLine(shoppingCartPageUpdate.GetTablePriceVat() +
                "==" + ((shoppingCartPageUpdate.GetTablePriceSubTotal() +  //only for presentation
                "*" + ShoppingCartData.FOR_VAT_1) + "/" + ShoppingCartData.FOR_VAT_2));
            Assert.IsTrue(shoppingCartPageUpdate.GetTablePriceVat()
                == ((shoppingCartPageUpdate.GetTablePriceSubTotal()
                * ShoppingCartData.FOR_VAT_1) / ShoppingCartData.FOR_VAT_2));

        }
    }
}
