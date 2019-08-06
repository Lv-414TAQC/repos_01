using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    class ShoppingCartPageComponent
    {
        public IWebElement Image
        { get { return driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td[@class='text-center']/a/img")); } }
        public IWebElement ProductName
        { get { return driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr//td[@class='text-left']/a")); } }
        public IWebElement Modal
        { get { return driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td/td/following-sibling::td"));} } //??????/
        public IWebElement QuantityField
        { get { return driver.FindElement(By.CssSelector("input: not(#input-coupon,#input-postcode,#input-voucher).form-control:not(.input-lg)")); } }
        public IWebElement Refresh
        { get { return driver.FindElement(By.CssSelector("button.btn.btn-primary")); } }
        public IWebElement Delete
        { get { return driver.FindElement(By.CssSelector("button.btn.btn-danger:not(.btn-xs)")); } }
        public IWebElement UnitPrice
        { get { return driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td/a[contains(text(),'iPhone')]/../following-sibling::td[@class ='text-right']")); } }
        public IWebElement Total
        { get { return driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td/a[contains(text(),'iPhone')]/../following-sibling::td[@class ='text-right']/following-sibling::td")); } }
    }
}
