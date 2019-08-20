using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OpenCart414Test.Data;

namespace OpenCart414Test.Pages.AdminPanel
{
    public class TaxClassesPage : SideMenuComponent
    {
        IWebElement EditTaxableGoodsButton { get { return driver.FindElement(By.XPath("//td[contains(text(), 'Taxable Goods')]/following-sibling::td/a")); } }
        IWebElement EditDownloadableProductsButton { get { return driver.FindElement(By.XPath("//td[contains(text(), 'Downloadable Products')]/following-sibling::td/a")); } }

        IList<TaxClassComponent> TaxClasses = new List<TaxClassComponent>();

        public TaxClassesPage(IWebDriver driver) : base(driver)
        {
            GetTaxClasses();
        }

        public void GetTaxClasses()
        {
            foreach (IWebElement item in driver.FindElements(By.CssSelector("table.table-bordered.table-hover tbody tr")))
            {
                TaxClassComponent TaxClass = new TaxClassComponent();
                TaxClass.CheckBox = item.FindElement(By.XPath("./td[@class='text-center']"));
                TaxClass.ClassTitle = item.FindElement(By.XPath("./td[@class='text-left']")).Text;
                TaxClass.EditButton = item.FindElement(By.XPath("./td[@class='text-right']/a"));
                TaxClasses.Add(TaxClass);
            }
        }

        void ClickTaxClassEditButton(string taxClass)
        {
            foreach (TaxClassComponent item in TaxClasses)
            {
                if (item.ClassTitle == taxClass)
                    item.EditButton.Click();
            }
        }

        public TaxClassesPage EditTaxClass(string taxClass, TaxRate taxRate)
        {
            ClickTaxClassEditButton(taxClass);
            EditTaxClassPage editTaxClassPage = new EditTaxClassPage(driver);
            editTaxClassPage.AddTaxRule(taxRate);
            return new TaxClassesPage(driver);
        }

        public TaxClassesPage RemoveRuleFromTaxClass(string taxClass, TaxRate taxRate)
        {
            ClickTaxClassEditButton(taxClass);
            EditTaxClassPage editTaxClassPage = new EditTaxClassPage(driver);
            editTaxClassPage.RemoveRule(taxRate);
            return new TaxClassesPage(driver);
        }
    }


}

