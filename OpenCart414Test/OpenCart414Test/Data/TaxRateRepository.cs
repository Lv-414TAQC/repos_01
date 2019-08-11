using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Data
{
    class TaxRateRepository
    {
        public static TaxRate GetFixTaxRate()
        {
            return new TaxRate("FixedTestTax", 2.0, "Fixed Amount", "UA Tax Zone");
        }

        public static TaxRate GetPercentageTaxRate()
        {
            return new TaxRate("PercentageTestTax", 5.0, "Percentage", "UA Tax Zone");
        }
    }
}
