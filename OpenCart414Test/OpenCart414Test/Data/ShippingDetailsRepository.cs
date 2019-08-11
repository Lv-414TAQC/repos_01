using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Data
{
    class ShippingDetailsRepository
    {
        public static ShippingDetails GetUkDetails()
        {
            return new ShippingDetails("United Kingdom", "Bristol", 123456);
        }
    }
}
