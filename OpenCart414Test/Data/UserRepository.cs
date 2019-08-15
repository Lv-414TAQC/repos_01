using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test
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

        public IUser Registered()
        {
            return User.Get()
              .SetFirstname("hahaha")
              .SetLastname("hahaha")
              .SetEmail("hahaha@gmail.com")
              .SetTelephone("telephone07")
              .SetAddress1("address107")
              .SetCity("city07")
              .SetPostcode("postcode07")
              .SetCountry("country07")
              .SetRegionState("regionState07")
              .SetPassword(Environment.GetEnvironmentVariable("MY_PASSWORD"))
              .SetSubscribe(true)
              .SetCompany("Company07")
              .Build();
        }

    }
}
