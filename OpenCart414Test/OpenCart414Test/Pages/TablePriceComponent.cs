using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class TablePriceComponent
    {
        protected IWebDriver driver;

        public IList<IWebElement> TablePriceList
        { get; private set; }

        public TablePriceComponent(IWebDriver driver, By searchLocator)
        {
            this.driver = driver;
            CheckElements();
            InitElements(searchLocator);

        }
        private void CheckElements()
        {
            // TODO Develop Custom Exception
            IList<IWebElement> temp = TablePriceList;
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
        public string GetTotal()
        {
            string result = string.Empty;
            int i = 0;
            foreach (IWebElement current in TablePriceList)
            {
                if (current.Text == "Total")
                {
                    i++;
                    continue;
                }
                if(i == 1)
                {
                    result = current.Text;
                }
                
            }
            return result;
        }
    }
}
