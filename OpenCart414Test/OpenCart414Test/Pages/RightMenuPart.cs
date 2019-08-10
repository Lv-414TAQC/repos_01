using OpenQA.Selenium;

namespace OpenCart414Test.Pages
{
    public class RightMenuPart : BreadCrumbsPart
    {
        public IWebElement RightMenuMyAccount =>
        driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='My Account']"));
        public IWebElement RightMenuAddressBook =>
        driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Address Book']"));
        public IWebElement RightMenuWishList =>
        driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Wish List']"));
        public IWebElement RightMenuOrderHistory =>
        driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Order History']"));
        public IWebElement RightMenuDownloads =>
        driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Downloads']"));
        public IWebElement RightMenuRecurringPayments =>
        driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Recurring payments']"));
        public IWebElement RightMenuRewardPoints =>
        driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Reward Points']"));
        public IWebElement RightMenuReturns =>
        driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Returns']"));
        public IWebElement RightMenuTransactions =>
        driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Transactions']"));
        public IWebElement RightMenuNewsletter =>
        driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Newsletter']"));
                
        public RightMenuPart(IWebDriver driver) : base(driver)
        {
        }

        // Atomic
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
    }
}
