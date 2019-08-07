using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class WishListComponentContainer
    {
        private const string WISHLIST_COMPONENT_XPATH = "//div[@class='table-responsive']/table/tbody/tr";

        protected IWebDriver driver;

        public IWebElement TableHeadImage
        { get { return driver.FindElement(By.XPath("//td[text()='Image']")); } }
        public IWebElement TableHeadProductName
        { get { return driver.FindElement(By.XPath("//td[text()='Product Name']")); } }
        public IWebElement TableHeadModel
        { get { return driver.FindElement(By.XPath("//td[text()='Model']")); } }
        public IWebElement TableHeadStock
        { get { return driver.FindElement(By.XPath("//td[text()='Stock']")); } }
        public IWebElement TableHeadUnitPrice
        { get { return driver.FindElement(By.XPath("//td[text()='Unit Price']")); } }
        public IWebElement TableHeadAction
        { get { return driver.FindElement(By.XPath("//td[text()='Action']")); } }

        private IList<WishListComponent> TableRows;

        public WishListComponentContainer(IWebDriver driver)
        {
            this.driver = driver;
            InitElements();
        }
        private void InitElements()
        {
            TableRows = new List<WishListComponent>();
            foreach (IWebElement current in driver.FindElements(By.CssSelector(WISHLIST_COMPONENT_XPATH)))
            {
                TableRows.Add(new WishListComponent(current));
            }
        }

        public IList<WishListComponent> GetWishListComponents()
        {
            return TableRows;
        }

        // Functional
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
                // TODO Develop Custom Exception
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
