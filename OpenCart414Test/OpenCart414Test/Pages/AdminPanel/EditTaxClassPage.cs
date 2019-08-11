using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenCart414Test.Data;
using OpenQA.Selenium.Support.UI;

namespace OpenCart414Test.Pages.AdminPanel
{
    class EditTaxClassPage : SideMenuComponent
    {
        IWebElement SaveButton => driver.FindElement(By.CssSelector("button[data-original-title='Save']"));
        IWebElement AddRuleButton => driver.FindElement(By.CssSelector("button[data-original-title='Add Rule']"));
        IWebElement RuleTable => driver.FindElement(By.CssSelector("table#tax-rule"));

        public EditTaxClassPage(IWebDriver driver) : base(driver)
        {
                
        }

        void ClickSaveButton()
        {
            SaveButton.Click();
        }

        void ClickAddRuleButton()
        {
            AddRuleButton.Click();
        }

        public void AddTaxRule(TaxRate rate)
        {
            ClickAddRuleButton();
            SelectElement rule = new SelectElement(driver.FindElement(By.CssSelector("#tax-rule tr[id*='tax-rule']:last-child select[name*='tax_rate_id']")));
            rule.SelectByText(rate.Name);
            ClickSaveButton();

        }
    }
}
