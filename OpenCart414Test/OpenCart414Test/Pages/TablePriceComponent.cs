using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    class TablePriceComponent
    {
        protected IWebDriver driver;

        public IList<IWebElement> TablePriceList
        { get; private set; }

        public TablePriceComponent(IWebDriver driver, By searchLocator)
        {
            this.driver = driver;
          //  CheckElements();
            //InitElements();
        }

        private void InitElements(By searchLocator)
        {
            TablePriceList = driver.FindElements(searchLocator);
        }


        //Page Object


        public IList<string> GetTablePriceListText()
        {
            IList<string> result = new List<string>();
            foreach (IWebElement current in TablePriceList)
            {
                result.Add(current.Text);
            }
            return result;
        }
    }
}
