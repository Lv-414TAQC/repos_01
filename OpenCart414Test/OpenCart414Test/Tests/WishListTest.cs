using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            new object[] { ProductRepository.GetIPhone(),
                Currency.US_DOLLAR },
        };
        [Test, TestCaseSource(nameof(ProductToAdd))]
        public void CheckAdding(Product addingProduct, Currency currency)
        {
            HomePage homePage = LoadApplication();
            //homePage.LoggingIn("roman_my@ukr.nrt", "TESTER_PASWORD").GotoHomePage();
            ProductsContainerComponent productsContainerComponent = homePage.getProductComponentsContainer();
            ProductComponent productComponent = productsContainerComponent.GetProductComponentByName(addingProduct.Title);
            productComponent.ClickAddToWishButton();
            WishListPage wishListPage = homePage.ClickWishList();
            Assert.IsTrue(wishListPage.getWishListComponentsContainer().GetWishListComponentByName(addingProduct.Title)
                .GetWishListComponentProductNameText().Contains(productComponent.Name.Text));
        }
    }
}
