using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenCart414Test.Data;
using OpenCart414Test.Pages;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.Interactions;

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
        public void AddToCart(Product addingProduct1, Product addingProduct2)
        {
            //Example test!!!!!!!!!!!!!!!
            HomePage homePage = LoadApplication();

            ProductsContainerComponent productsContainerComponent = homePage.getProductComponentsContainer();
            ProductComponent productComponent1 = productsContainerComponent.GetProductComponentByName(addingProduct1.Title);
            Thread.Sleep(2000);
            productComponent1.ClickAddToCartButton();

            ProductComponent productComponent2 = productsContainerComponent.GetProductComponentByName(addingProduct2.Title);
            Thread.Sleep(2000);
            productComponent2.ClickAddToCartButton();

            Thread.Sleep(2000);
            homePage.ClickCartButton();
            Thread.Sleep(2000);

            CartProductContainer cartProductContainer = new CartProductContainer(driver);

            IList<string> a = cartProductContainer.GetAllTablePriceComponents();
            foreach(string cur in a)
            {
                Console.WriteLine(cur);
            }
            Console.WriteLine("____________________________");

            IList<ShoppingCartContainerComponent> b = cartProductContainer.GetItemsTable();
            foreach (ShoppingCartContainerComponent cur in b)
            {
                Console.WriteLine(cur.GetProductPriceText());
            }

           // ShoppingCartContainerComponent shoppingCartContainerComponent = new ShoppingCartContainerComponent();


        }

    }
}
