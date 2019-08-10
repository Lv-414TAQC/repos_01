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
            ProductsContainerComponent productsContainerComponent = homePage.getProductComponentsContainer();
            ProductComponent productComponent = productsContainerComponent
                .GetProductComponentByName(addingProduct1.Title);
            Thread.Sleep(2000);
            productComponent.ClickAddToCartButton();
            ShoppingCartEmptyPage shoppingCartEmptyPage = homePage
                .GotoShoppingCartPage()
                .NotUpdateMessage(addingProduct1, ShoppingCartData.INVALID_CHECK_ZERO);
            Thread.Sleep(2000);
            Assert.IsTrue(shoppingCartEmptyPage.Equal());
            //Thread.Sleep(2000);
            shoppingCartEmptyPage.GoToHomePage();
            
            productComponent.ClickAddToCartButton();

            //Thread.Sleep(1000); // only for presentation
            //shoppingCartPage.ClearQuantity(addingProduct1);
            //shoppingCartPage.NotUpdateMessage(addingProduct1);
            //Assert.IsTrue(shoppingCartPage
            //   .NotUpdateMessage(addingProduct1)
            //   .GetInfoMessageText()
            //   .Contains(shoppingCartPage
            //   .NotUpdateMessage(addingProduct1)
            //   .GetConstInfoMessageText()));
            //homePage = LoadApplication();
            //Thread.Sleep(2000);
            //productComponent.ClickAddToCartButton();
            ////homePage.GotoShoppingCartPage();
             shoppingCartEmptyPage = homePage
                .GotoShoppingCartPage()
                .GoToEmptyPage(addingProduct1);
            Thread.Sleep(2000);
            Assert.IsTrue(shoppingCartEmptyPage.Equal());
        }

        //[Test, TestCaseSource(nameof(ProductToAdd))]
        //public void Update(Product addingProduct1)
        //{
        //    HomePage homePage = LoadApplication();
        //    ProductsContainerComponent productsContainerComponent = homePage.getProductComponentsContainer();
        //    ProductComponent productComponent = productsContainerComponent.GetProductComponentByName(addingProduct1.Title);
        //    Thread.Sleep(2000);sh
        //    productComponent.ClickAddToCartButton();
        //    homePage.ClickShoppingCart();
        //    ShoppingCartPage s = new ShoppingCartPage(driver);
        //    Assert.IsTrue(s.GetShoppingCartTitleText().Contains(ShoppingCartMessage.CART_IS_OPEN));
        //    ShoppingCartComponent component = new ShoppingCartComponent();
        //    Thread.Sleep(2000);
        //    component.ClearQuantityField();
        //    Thread.Sleep(1000); //for update page
        //    Assert.IsTrue(component.GetTextQuantityField().Equals(null));
        //    component.SandKeysQuantityField("2");
        //    Thread.Sleep(1000); // only for presentation 
        //    component.UpdateMessage();
        //    Thread.Sleep(1000); // only for presentation
        //    Assert.IsTrue(component.GetUpdateMessage().Contains(ShoppingCartMessage.UPDATE_MESSAGE));
        //    Assert.IsTrue(component.GetTextQuantityField() == 2);
        //    component.ClearQuantityField();
        //    Thread.Sleep(1000); //for update page
        //    component.SandKeysQuantityField("job");
        //    Thread.Sleep(2000);
        //    component.UpdateMessage();
        //    Thread.Sleep(2000);
        //    ShoppingCartEmptyPage em = new ShoppingCartEmptyPage(driver);
        //    Assert.IsTrue(em.GetInfoMessageText().Contains(ShoppingCartMessage.CART_IS_EMPTY));
        //}
        //[Test, TestCaseSource(nameof(ProductToAdd))]
        //public void Price(Product addingProduct1)
        //{
        //    HomePage homePage = LoadApplication();
        //    ProductsContainerComponent productsContainerComponent = homePage.getProductComponentsContainer();
        //    ProductComponent productComponent = productsContainerComponent.GetProductComponentByName(addingProduct1.Title);
        //    Thread.Sleep(2000);
        //    productComponent.ClickAddToCartButton();
        //    homePage.ClickShoppingCart();
        //    ShoppingCartPage s = new ShoppingCartPage(driver);
        //    Assert.IsTrue(s.GetShoppingCartTitleText().Contains(ShoppingCartMessage.CART_IS_OPEN));
        //    ShoppingCartComponent component = new ShoppingCartComponent();
        //    Thread.Sleep(2000);
        //    Assert.IsTrue(component.GetUnitPrice().Equals(component.GetTotal()));
        //    component.SandKeysQuantityField("2");
        //    Thread.Sleep(1000); // only for presentation 
        //    component.UpdateMessage();
        //    Thread.Sleep(1000); // only for presentation
        //    Assert.IsTrue(component.GetTextQuantityField() == 2);
        //    Assert.IsTrue((component.GetUnitPrice() * component.GetTextQuantityField()) == component.GetTotal());

        //    ////??????????/
           
            //double subtotal = Convert.ToDouble(driver.FindElement(By.XPath("//div[@class='row']/div/table/tbody/tr/td/strong[text() ='Sub-Total:']/../following-sibling::td")).Text.Substring(1, 5).Replace('.', ','));
            ////Console.WriteLine(driver.FindElement(By.XPath("//div[@class='row']/div/table/tbody/tr/td/strong[text() ='Flat Shipping Rate:']/../following-sibling::td")).Text);
            //double ecotax = Convert.ToDouble(driver.FindElement(By.XPath("//div[@class='row']/div/table/tbody/tr/td/strong[text() ='Eco Tax (-2.00):']/../following-sibling::td")).Text.Substring(1, 3).Replace('.', ','));
            //double vat = Convert.ToDouble(driver.FindElement(By.XPath("//div[@class='row']/div/table/tbody/tr/td/strong[text() ='VAT (20%):']/../following-sibling::td")).Text.Substring(1, 4).Replace('.', ','));
            //double total = Convert.ToDouble(driver.FindElement(By.XPath("//div[@class='row']/div/table/tbody/tr/td/strong[text() ='Total:']/../following-sibling::td")).Text.Substring(1, 5).Replace('.', ','));
            //Console.WriteLine(ecotax + subtotal + vat + total);
            //Assert.IsTrue(ecotax + subtotal + vat == total);
            //Console.WriteLine(total + " == " + Convert.ToDouble(totalprice.Substring(1, 5).Replace('.', ',')));
            //Assert.IsTrue(total == Convert.ToDouble(totalprice.Substring(1, 5).Replace('.', ',')));
            //Console.WriteLine(vat + " == " + subtotal * 0.2);
            //Assert.IsTrue(vat == ((subtotal * 20) / 100));
            
        }
    }

