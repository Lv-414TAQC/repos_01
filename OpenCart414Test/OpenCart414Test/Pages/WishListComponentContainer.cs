using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace OpenCart414Test.Pages
{
    public class WishListComponentContainer
    {
        private const string WishComponentXPath = "//div[@class='table-responsive']/table/tbody/tr";

        protected IWebDriver driver;

        private IList<WishListComponent> TableRows;

        public WishListComponentContainer(IWebDriver driver)
        {
            this.driver = driver;
            InitElements();
        }
        private void InitElements()
        {
            TableRows = new List<WishListComponent>();
            foreach (IWebElement current in driver.FindElements(By.XPath(WishComponentXPath)))
            {
                TableRows.Add(new WishListComponent(current));
            }
        }

        public IList<WishListComponent> GetWishListComponents()
        {
            return TableRows;
        }

        public IList<string> GetWishListComponentNames()
        {
            IList<string> wishListComponentNames = new List<string>();
            foreach (WishListComponent current in GetWishListComponents())
            {
                wishListComponentNames.Add(current.GetWishListComponentProductNameText());
            }
            return wishListComponentNames;
        }
        public WishListComponent GetWishListComponentByName(string wishListComponentName)
        {
            WishListComponent result = null;
            foreach (WishListComponent current in GetWishListComponents())
            {
                if (current.GetWishListComponentProductNameText().ToLower().Equals(wishListComponentName.ToLower()))
                {
                    result = current;
                    break;
                }
            }
            if (result == null)
            {
                throw new Exception("ProductName: " + wishListComponentName + " not Found.");
            }
            return result;
        }
        public string GetWishListComponentUnitPriceByName(string wishListComponentName)
        {
            return GetWishListComponentByName(wishListComponentName).GetWishListComponentUnitPriceText();
        }
        public string GetWishListComponentModelByName(string wishListComponentName)
        {
            return GetWishListComponentByName(wishListComponentName).GetWishListComponentModelText();
        }
        public string GetWishListComponentStockByName(string wishListComponentName)
        {
            return GetWishListComponentByName(wishListComponentName).GetWishListComponentStockText();
        }
        public void ClickWishListComponentAddToCartButtonByName(string wishListComponentName)
        {
            GetWishListComponentByName(wishListComponentName).ClickWishListComponentAddToCartButton();
        }
        public void ClickWishListComponentRemoveButtonByName(string wishListComponentName)
        {
            GetWishListComponentByName(wishListComponentName).ClickWishListComponentRemoveButton();
        }
        public int GetWishListComponentsCount()
        {
            return GetWishListComponents().Count;
        }
    }
}
