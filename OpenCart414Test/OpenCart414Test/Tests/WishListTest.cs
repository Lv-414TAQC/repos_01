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
    public class WishListTest : TestRunner
    {
        // DataProvider
        private static readonly object[] ProductToAdd =
        {
            new object[] { ProductRepository.GetIPhone() },
        };
        [Test, TestCaseSource(nameof(ProductToAdd))]
        public void CheckAdding(Product addingProduct)
        {
            HomePage homePage = LoadApplication()
                .GotoLoginPage()
                .LoggingIn("roman_my@ukr.net", "TESTER_PASWORD")
                .GotoHomePage();
            Thread.Sleep(2000); //for presentation only
            ProductComponent productComponent = homePage
                .getProductComponentsContainer()
                .GetProductComponentByName(addingProduct.Title);
            Thread.Sleep(2000); //for presentation only
            productComponent.AddItemToWishList();
            Thread.Sleep(2000); //for presentation only
            WishListPage wishListPage = homePage
                .GotoWishListPage();
            Thread.Sleep(2000); //for presentation only
            Assert.IsTrue(wishListPage
                .getWishListComponentsContainer()
                .GetWishListComponentNames()
                .Contains(addingProduct.Title));
        }
    }
}
