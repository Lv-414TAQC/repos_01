﻿
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
