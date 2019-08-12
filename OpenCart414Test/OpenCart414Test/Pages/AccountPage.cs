using OpenQA.Selenium;

namespace OpenCart414Test.Pages
{
    public class AccountPage : RightLoginPart
    {

        public static readonly string My_Account_Message = "My Account";
        public static readonly string My_Account_Update_Message = "Success: Your account has been successfully updated.";
        public static readonly string My_Password_UPDATE_Message = "Success: Your password has been successfully updated.";
        public IWebElement Message
        { get { return driver.FindElement(By.CssSelector("#content > h2:first-child")); } }
        private IWebElement MyAccountLabel
        { get { return driver.FindElement(By.CssSelector("#content > h2:first-child")); } }

        public AccountPage(IWebDriver driver) : base(driver)
        {

        }

        public string GetMessageText()
        {
            return Message.Text;
        }
        public string GetMyAccountLabelText()
        {
            return MyAccount.Text;
        }

    }
}
