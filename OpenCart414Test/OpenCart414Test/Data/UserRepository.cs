using System;

namespace OpenCart414Test.Data
{
    public sealed class UserRepository
    {
        private volatile static UserRepository instance;
        private static object lockingObject = new object();

        private UserRepository()
        {
        }

        public static UserRepository Get()
        {
            if (instance == null)  //
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new UserRepository();
                    }
                }
            }
            return instance;
        }


        public IUser ValidUserWithBoundaryValues1()
        {
            return User.Get()
                    .SetFirstname("L")
                    .SetLastname("V")
                    .SetEmail("onbvc.201@lpnu.ua")
                    .SetTelephone("0507591658")
                    .SetAddress1("Var")
                    .SetCity("Lv")
                    .SetPostcode("48")
                    .SetCountry("Togo")
                    .SetRegionState("Kara")
                    .SetPassword("qwer")
                    .SetSubscribe(true)
                    .SetFax("41358454")
                    .SetCompany("Company")
                    .Build();
        }
        public IUser Registered()
        {
            return User.Get()
              .SetFirstname("firstname07")
              .SetLastname("lastname07")
              .SetEmail("email07")
              .SetTelephone("telephone07")
              .SetAddress1("address107")
              .SetCity("city07")
              .SetPostcode("postcode07")
              .SetCountry("country07")
              .SetRegionState("regionState07")
              .SetPassword("password07")
              .SetSubscribe(true)
              .SetCompany("Company07")
              .Build();
        }

        public IUser WishListTester()
        {
            return User.Get()
              .SetFirstname("tester")
              .SetLastname("tester")
              .SetEmail("roman_my@ukr.net")
              .SetTelephone("someNumber")
              .SetAddress1("someAddress")
              .SetCity("someCity")
              .SetPostcode("somePostcode")
              .SetCountry("someCountry")
              .SetRegionState("someRegionState")
              .SetPassword(Environment.GetEnvironmentVariable("TESTER_PASWORD"))
              .SetSubscribe(true)
              .SetCompany("someCompany")
              .Build();
        }

        public static IUser  GetTestUser()
        {
            return User.Get()
              .SetFirstname("tester")
              .SetLastname("tester")
              .SetEmail(Environment.GetEnvironmentVariable("USER_NAME"))
              .SetTelephone("someNumber")
              .SetAddress1("someAddress")
              .SetCity("someCity")
              .SetPostcode("somePostcode")
              .SetCountry("someCountry")
              .SetRegionState("someRegionState")
              .SetPassword(Environment.GetEnvironmentVariable("USER_PASSWORD"))
              .SetSubscribe(true)
              .SetCompany("someCompany")
              .Build();
        }


    }
}
