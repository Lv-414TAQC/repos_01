using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class RightMenuPart : BreadCrumPart
    {
        public IWebElement RightMenuMyAccount
        { get { return driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='My Account']")); } }
        public IWebElement RightMenuAddressBook
        { get { return driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Address Book']")); } }
        public IWebElement RightMenuWishList
        { get { return driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Wish List']")); } }
        public IWebElement RightMenuOrderHistory
        { get { return driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Order History']")); } }
        public IWebElement RightMenuDownloads
        { get { return driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Downloads']")); } }
        public IWebElement RightMenuRecurringPayments
        { get { return driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Recurring payments']")); } }
        public IWebElement RightMenuRewardPoints
        { get { return driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Reward Points']")); } }
        public IWebElement RightMenuReturns
        { get { return driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Returns']")); } }
        public IWebElement RightMenuTransactions
        { get { return driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Transactions']")); } }
        public IWebElement RightMenuNewsletter
        { get { return driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Newsletter']")); } }
                
        public RightMenuPart(IWebDriver driver) : base(driver)
        {
        }

        // Page Object
        public string GetRightMenuMyAccountText()
        {
            return RightMenuMyAccount.Text;
        }
        public void ClickRightMenuMyAccount()
        {
            RightMenuMyAccount.Click();
        }
        public string GetRightMenuAddressBookText()
        {
            return RightMenuAddressBook.Text;
        }
        public void ClickRightMenuAddressBook()
        {
            RightMenuAddressBook.Click();
        }
        public string GetRightMenuWishListText()
        {
            return RightMenuWishList.Text;
        }
        public void ClickRightMenuWishList()
        {
            RightMenuWishList.Click();
        }
        public string GetRightMenuOrderHistoryText()
        {
            return RightMenuOrderHistory.Text;
        }
        public void ClickRightMenuOrderHistory()
        {
            RightMenuOrderHistory.Click();
        }
        public string GetRightMenuDownloadsText()
        {
            return RightMenuDownloads.Text;
        }
        public void ClickRightMenuDownloads()
        {
            RightMenuDownloads.Click();
        }
        public string GetRightMenuRecurringPaymentsText()
        {
            return RightMenuRecurringPayments.Text;
        }
        public void ClickRightRecurringPayments()
        {
            RightMenuRecurringPayments.Click();
        }
        public string GetRightMenuRewardPointsText()
        {
            return RightMenuRewardPoints.Text;
        }
        public void ClickRightMenuRewardPoints()
        {
            RightMenuRewardPoints.Click();
        }
        public string GetRightMenuReturnsText()
        {
            return RightMenuReturns.Text;
        }
        public void ClickRightMenuReturns()
        {
            RightMenuReturns.Click();
        }
        public string GetRightMenuTransactionsText()
        {
            return RightMenuTransactions.Text;
        }
        public void ClickRightMenuTransactions()
        {
            RightMenuTransactions.Click();
        }
        public string GetRightMenuNewsletterText()
        {
            return RightMenuNewsletter.Text;
        }
        public void ClickRightMenuNewsletter()
        {
            RightMenuNewsletter.Click();
        }

        // Functional

        // Business Logic
    }
}
