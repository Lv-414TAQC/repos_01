using System;
using NUnit.Framework;
using OpenCart414Test.Pages;
using OpenCart414Test.Pages.AdminPanel;
using OpenCart414Test.Data;

namespace OpenCart414Test.Tests
{
    [TestFixture]
    class CurrencyInShoppingCartTests : TestRunner
    {
        [SetUp]
        public override void SetUp()
        {
            HomePage homePage = LoadHomePage();
            homePage.AddProductToCart(ProductRepository.GetMacBook());
            homePage.ClickShoppingCart();
            ShoppingCartPage cartPage = homePage.OpenShoppingCartPage();

        }

        [Test]
        public void CheckProductPriceInShoppingCart()
        {

        }
    }
}
