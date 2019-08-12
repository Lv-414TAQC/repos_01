
namespace OpenCart414Test.Data
{
    static class ShippingDetailsRepository
    {
        public static ShippingDetails GetUkDetails()
        {
            return new ShippingDetails("United Kingdom", "Bristol", 123456);
        }

        public static ShippingDetails GetUADetails()
        {
            return new ShippingDetails("Ukraine", "L'vivs'ka Oblast'", 987654);
        }
    }


}
