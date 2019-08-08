using OpenCartTests.Stetsula;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyTests.Stetsula.Pages
{
    class TaxClassesPage : HeaderPart
    {
        IWebElement EditTaxableGoodsButton { get {return  Driver.FindElement(By.XPath("//td[contains(text(), 'Taxable Goods')]/following-sibling::td/a")); } }
        IWebElement EditDownloadableProductsButton { get { return Driver.FindElement(By.XPath("//td[contains(text(), 'Downloadable Products')]/following-sibling::td/a")); } }

        IList<TaxClassComponent> TaxClasses = new List<TaxClassComponent>();

        public TaxClassesPage(IWebDriver driver) : base(driver)
        {
            GetTaxClasses();
        }

        public void GetTaxClasses()
        {
            foreach (IWebElement item in Driver.FindElements(By.CssSelector("table.table-bordered.table-hover tbody tr")))
            {
                TaxClassComponent TaxClass = new TaxClassComponent();
                TaxClass.CheckBox = item.FindElement(By.XPath("./td[@class='text-center']"));
                TaxClass.ClassTitle = item.FindElement(By.XPath("./td[@class='text-left']")).Text;
                TaxClass.Action = item.FindElement(By.XPath("./td[@class='text-right']"));
                TaxClasses.Add(TaxClass);
            }
        }

        public void ClickTaxClassEditButton(string taxClass)
        {
            foreach (TaxClassComponent item in TaxClasses)
            {
                if (item.ClassTitle == taxClass)
                    item.Action.Click();
            }
        }

        public void EditTaxClass()
        {

        }
    }

   
}
