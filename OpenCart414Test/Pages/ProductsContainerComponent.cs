using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class ProductsContainerComponent
    {
        protected IWebDriver driver;

        public ProductsContainerComponent(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
