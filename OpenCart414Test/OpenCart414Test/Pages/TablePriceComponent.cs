using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace OpenCart414Test.Pages
{
    public class TablePriceComponent
    {
        protected IWebDriver driver;

        public IList<IWebElement> TablePriceList
        { get; set; }

        public TablePriceComponent(IWebDriver driver, By searchLocator)
        {
            this.driver = driver;
            CheckElements();
            InitElements(searchLocator);

        }
        private void CheckElements()
        {
            try
            { 
            IList<IWebElement> temp = TablePriceList;
            }
            catch (Exception)
            {
                throw new Exception("Custom exception: CheckElements()");
            }
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
                if (i == 1)
                {
                    result = current.Text;
                    break;
                }  
            }
            Console.WriteLine("result = {0}", result);
            return result;
        }


        public string GetTotalForPageSC()
        {
            string result = string.Empty;
            
            for (int current = 0; current < TablePriceList.Count; current++)
            {
                if (TablePriceList[current].Text == "Total:")
                {
                        result = TablePriceList[current + 1].Text;

                }
                

            }
            return result;
        }

        public string GetSubTotal()
        {
            string result = string.Empty;
            
            for (int current =0;current < TablePriceList.Count;current++)
            {
                if (TablePriceList[current].Text == "Sub-Total:")
                {
                    result = TablePriceList[current+1].Text;
                   
                }


            }
            return result;
        }

        public string GetEcoTax()
        {
            string result = string.Empty;
            
            for (int current = 0; current < TablePriceList.Count; current++)
            {
                if (TablePriceList[current].Text == "Eco Tax (-2.00):")
                {
                    result = TablePriceList[current + 1].Text;

                }

            }
            return result;
        }

        public string GetVat()
        {
            string result = string.Empty;
            
            for (int current = 0; current < TablePriceList.Count; current++)
            {
                if (TablePriceList[current].Text == "VAT (20%):")
                {
                    result = TablePriceList[current + 1].Text;

                }


            }
            return result;
        }
        
    }
}
