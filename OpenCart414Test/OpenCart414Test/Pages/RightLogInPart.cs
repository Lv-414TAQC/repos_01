using OpenQA.Selenium;

namespace OpenCart414Test.Pages
{
    public class RightLoginPart : RightMenuPart
    {
        public IWebElement RightMenuEditAccount =>
        driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Edit Account']"));
        public IWebElement RightMenuPassword =>
        driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Password']"));
        public IWebElement RightMenuLogout =>
        driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Logout']"));

        public RightLoginPart(IWebDriver driver) : base(driver)
        {
        }

        public string GetRightMenuEditAccountText()
        {
            return RightMenuEditAccount.Text;
        }
        public void ClickRightMenuEditAccount()
        {
            RightMenuEditAccount.Click();
        }
        public string GetRightMenuPasswordText()
        {
            return RightMenuPassword.Text;
        }

        //Chenged 
        public ChangePasswordPage ClickRightMenuPassword()
        {
            RightMenuPassword.Click();
            return new ChangePasswordPage(driver);
        }
        public string GetRightMenuLogoutText()
        {
            return RightMenuLogout.Text;
        }
        public void ClickRightMenuLogout()
        {
            RightMenuLogout.Click();
        }
    }
}
