using OpenQA.Selenium;

namespace OpenCart414Test.Pages
{
    public class RightLogoutPart : RightMenuPart
    {
        public IWebElement RightMenuLogin =>
        driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Login']"));
        public IWebElement RightMenuRegister =>
        driver.FindElement(By.XPath("//div[@class='list-group']/a[text()='Register']"));

        public RightLogoutPart(IWebDriver driver) : base(driver)
        {
        }

        // Atomic
        public string GetRightMenuLoginText()
        {
            return RightMenuLogin.Text;
        }
        public void ClickRightMenuLogin()
        {
            RightMenuLogin.Click();
        }
        public string GetRightMenuRegisterText()
        {
            return RightMenuRegister.Text;
        }
        public void ClickRightMenuRegister()
        {
            RightMenuRegister.Click();
        }
    }
}
