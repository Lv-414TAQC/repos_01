using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Data
{
    public class ShippingDetails
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public int PostCode { get; set; }

        public ShippingDetails(string country, string region, int code)
        {
            Country = country;
            Region = region;
            PostCode = code;
        }
    }
}
