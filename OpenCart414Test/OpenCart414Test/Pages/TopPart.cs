using OpenCart414Test.Data;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class TopPart
    {
        public const string TAG_ATTRIBUTE_VALUE = "value";
        protected const string TAG_ATTRIBUTE_SRC = "src";
        //
        protected const string LIST_CURENCIES_CSSSELECTOR = "div.btn-group.open ul.dropdown-menu li";
        protected const string DROPDOWN_MYACCOUNT_CSSSELECTOR = ".dropdown-menu-right li";
        //
        protected IWebDriver driver;
        //
        public IWebElement Currency
        { get { return driver.FindElement(By.CssSelector(".btn.btn-link.dropdown-toggle")); } }
        public IWebElement MyAccount
        { get { return driver.FindElement(By.CssSelector(".list-inline > li > a.dropdown-toggle")); } }
        public IWebElement WishList
        { get { return driver.FindElement(By.Id("wishlist-total")); } }
        public IWebElement ShoppingCart
        { get { return driver.FindElement(By.CssSelector("a[title='Shopping Cart']")); } }
        public IWebElement Checkout
        { get { return driver.FindElement(By.CssSelector("a[title='Checkout']")); } }
        public IWebElement Logo
        { get { return driver.FindElement(By.CssSelector("#logo img")); } }
        public IWebElement SearchField
        { get { return driver.FindElement(By.Name("search")); } }
        public IWebElement SearchButton
        { get { return driver.FindElement(By.CssSelector(".btn.btn-default.btn-lg")); } }
        public IWebElement CartButton
        { get { return driver.FindElement(By.CssSelector("#cart > button")); } }
        //
        private DropdownComponent dropdownComponent;
      
        public IList<IWebElement> TopMenu;  // TODO { get; private set; }

        public TopPart(IWebDriver driver)
        {
            this.driver = driver;
            InitElements();
            CheckElements();
        }

        private void InitElements()
        {
            dropdownComponent = null;
        }

        private void CheckElements()
        {
            // TODO Develop Custom Exception
            IWebElement temp = Currency; // TODO All Web Elements
        }

        // PageObject

        // Currency
        public string GetCurrencyText()
        {
            return Currency.Text;
        }

        public void ClickCurrency()
        {
            Currency.Click();
        }

        // MyAccount
        public string GetMyAccountText()
        {
            return MyAccount.Text;
        }

        public void ClickMyAccount()
        {
            MyAccount.Click();
        }

        // WishList
        public string GetWishListText()
        {
            return WishList.Text;
        }

        public void ClickWishList()
        {
            WishList.Click();
        }

        // ShoppingCart
        public string GetShoppingCartText()
        {
            return ShoppingCart.Text;
        }

        public void ClickShoppingCart()
        {
            ShoppingCart.Click();
        }

        // Checkout
        public string GetCheckoutText()
        {
            return Checkout.Text;
        }

        public void ClickCheckout()
        {
            Checkout.Click();
        }

        // Logo
        public void ClickLogo()
        {
            Logo.Click();
        }

        // SearchField
        public string GetSearchFieldText()
        {
            return SearchField.GetAttribute(TAG_ATTRIBUTE_VALUE);
        }

        public void SetSearchField(string text)
        {
            SearchField.SendKeys(text);
        }

        public void ClearSearchField()
        {
            SearchField.Clear();
        }

        public void ClickSearchField()
        {
            SearchField.Click();
        }


        // SearchButton
        public void ClickSearchButton()
        {
            SearchButton.Click(); 
        }


        //public SearchUnsuccessPage ClickSearchButtonD() //Доробити як бізнес логіку
        //{
        //    SearchButton.Click();
        //    return new SearchUnsuccessPage(driver);

        //}

        // CartButton
        public string GetCartButtonText()
        {
            return CartButton.Text;
        }

        public void ClickCartButton()
        {
            CartButton.Click();
        }

        // DropdownComponent
        protected DropdownComponent GetDropdownComponent()
        {
            if (dropdownComponent == null)
            {
                // TODO Develop Custom Exception 
                throw new Exception("DropdownComponent is null.");
            }
            return dropdownComponent;
        }

        private DropdownComponent CreateDropdownComponent(By searchLocator)
        {
            dropdownComponent = new DropdownComponent(driver, searchLocator);
            return GetDropdownComponent();
        }

        private void ClickDropdownComponentByPartialName(string optionName)
        {
            if (!GetDropdownComponent().IsExistDropdownOptionByPartialName(optionName))
            {
                // TODO Develop Custom Exception 
                throw new Exception("OptionName not found.");
            }
            GetDropdownComponent().ClickDropdownOptionByPartialName(optionName);
            dropdownComponent = null;
        }

        private void CloseDropdownOption()
        {
            ClickSearchField();
            dropdownComponent = null;
        }

        internal CartContainerComponent OpenCartButton()
        {
            ClickCartButton();
            return new CartContainerComponent(driver);
        }
        internal CartContainerComponent GetCartContainerComponent()
        {
            return new CartContainerComponent(driver);
        }
        internal CartEmptyContainerComponent OpenEmptyCartButton()
        {
            ClickCartButton();
            return new CartEmptyContainerComponent(driver);
        }
        internal CartEmptyContainerComponent GetCartEmptyContainerComponent()
        {
            return new CartEmptyContainerComponent(driver);
        }
 
        // Functional
        protected void MakeTopSearch(string searchText)
        {
            ClickSearchField();
            ClearSearchField();
            SetSearchField(searchText);
            ClickSearchButton();
        }


        // CurrencyDropdownComponent
        private void OpenCurrencyDropdownComponent()
        {
            ClickSearchField();
            ClickCurrency();
            CreateDropdownComponent(By.CssSelector(LIST_CURENCIES_CSSSELECTOR));
        }

        protected void ClickCurrencyByPartialName(Currency currency)
        {
            OpenCurrencyDropdownComponent();
            ClickDropdownComponentByPartialName(ApplicationRepository
                .GetCurrencyDTO(currency).UIPartialName);
        }

        public IList<string> GetListCurrencyNames()
        {
            OpenCurrencyDropdownComponent();
            IList<string> result = GetDropdownComponent().GetListOptionsText();
            CloseDropdownOption();
            return result;
        }

        // MyAccountDropdownComponent
        private void ClickDropdownMyAccountByPartialName(string optionName)
        {
            ClickSearchField();
            ClickMyAccount();
            CreateDropdownComponent(By.CssSelector(DROPDOWN_MYACCOUNT_CSSSELECTOR));
            ClickDropdownComponentByPartialName(optionName);
        }

        protected void ClickUnloggedMyAccountByPartialName(UnloggedMyAccount optionName)
        {
            // TODO Check if Unlogged
            ClickDropdownMyAccountByPartialName(ApplicationRepository
                .GetUnloggedMyAccountDTO(optionName).UIPartialName);
        }

        protected void ClickLoggedMyAccountByPartialName(LoggedMyAccount optionName)
        {
            // TODO Check if loggined
            ClickDropdownMyAccountByPartialName(ApplicationRepository
                .GetLoggedMyAccountDTO(optionName).UIPartialName);
        }


        // Business Logic

        public HomePage GotoHomePage()
        {
            ClickLogo();
            return new HomePage(driver);
        }
        //public SearchSuccessPage SearchSuccessfully(string searchText)
        public SearchSuccessPage SearchSuccessfully(SearchCriteria searchCriteria)
        {
            MakeTopSearch(searchCriteria.SearchValue);
            //MakeTopSearch(searchText);
            return new SearchSuccessPage(driver);
        }

        //public SearchUnsuccessPage SearchUnsuccessfully(string searchText)
        public SearchUnsuccessPage SearchUnsuccessfully(SearchCriteria searchCriteria)
        {
            MakeTopSearch(searchCriteria.SearchValue);
            //MakeTopSearch(searchText);               
            return new SearchUnsuccessPage(driver);
        }

        public LoginPage GotoLoginPage()
        {
            ClickUnloggedMyAccountByPartialName(UnloggedMyAccount.LOGIN);
            return new LoginPage(driver);
        }

        public RegisterUserPage GotoRegisterPage()
        {
            ClickUnloggedMyAccountByPartialName(UnloggedMyAccount.REGISTER);
            return new RegisterUserPage(driver);
        }

        public AccountLogoutPage Logout()
        {
            ClickLoggedMyAccountByPartialName(LoggedMyAccount.LOGOUT);
            return new AccountLogoutPage(driver);
        }

        public WishListPage GotoWishListPage()
        {
            ClickWishList();
            return new WishListPage(driver);
        }

        public ShoppingCartPage GotoShoppingCartPage()
        {
            ClickShoppingCart();
            return new ShoppingCartPage(driver);
        }

    }
}
