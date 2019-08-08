using OpenCart414Test.Data;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class WishListPage : WishListPart
    {
        private WishListComponentContainer wishListTable;
        //{ get { return driver.FindElement(By.CssSelector(".table.table-bordered.table-hover")); } }
        public WishListPage(IWebDriver driver) : base(driver)
        {
            InitElements();
        }
        private void InitElements()
        {
            wishListTable = new WishListComponentContainer(driver);
        }
        public WishListComponentContainer getWishListComponentsContainer()
        {
            return wishListTable;
        }

        // Business Logic
        public WishListEmptyPage removeLastItemFromWishList(Product removingProduct)
        {
            getWishListComponentsContainer()
                .ClickWishListComponentRemoveButtonByName(removingProduct.Title);
            return new WishListEmptyPage(driver);
        }
    }
}
