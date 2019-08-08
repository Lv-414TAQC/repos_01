using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPractices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 1. Use Constructor
            //User user = new User("firstname01",  "lastname01",
            //     "email01",  "telephone01",  "address101",
            //     "city01",  "postcode01",  "country01",
            //     "region01",  "password01", true);
            //Console.WriteLine("email = " + user.Email);
            //
            // 2. Default Constructor and Setters
            //User user = new User();
            //user.SetFirstname("firstname02");
            //user.SetLastname("lastname02");
            //user.SetEmail("email02");
            //user.SetTelephone("telephone02");
            //user.SetAddress1("address102");
            //user.SetCity("city02");
            //user.SetPostcode("postcode02");
            //user.SetCountry("country02");
            //user.SetRegionState("region02");
            //user.SetPassword("password02");
            //user.SetSubscribe(true);
            //user.SetFax("fax02");
            //user.SetCompany("company02");
            //user.SetAddress2("address202");
            //Console.WriteLine("email = " + user.Email);
            //
            // 3. Add Fluent Interface
            //User user = new User()
            //    .SetFirstname("firstname03")
            //    .SetLastname("lastname03")
            //    .SetEmail("email03")
            //    .SetTelephone("telephone03")
            //    .SetAddress1("address103")
            //    .SetCity("city03")
            //    .SetPostcode("postcode03")
            //    .SetCountry("country03")
            //    .SetRegionState("region03")
            //    .SetPassword("password03")
            //    .SetSubscribe(true)
            //    .SetFax("fax03")
            //    .SetCompany("company03")
            //    .SetAddress2("address203");
            //Console.WriteLine("email = " + user.Email);
            //
            // 4. Add Static Factory
            //User user = User.Get()
            //    .SetFirstname("firstname04")
            //    .SetLastname("lastname04")
            //    .SetEmail("email04")
            //    .SetTelephone("telephone04")
            //    .SetAddress1("address104")
            //    .SetCity("city04")
            //    .SetPostcode("postcode04")
            //    .SetCountry("country04")
            //    .SetRegionState("region04")
            //    .SetPassword("password04")
            //    .SetSubscribe(true)
            //    .SetFax("fax04")
            //    .SetCompany("company04")
            //    .SetAddress2("address204");
            //Console.WriteLine("email = " + user.Email);
            //
            // 5. Add Builder
            //User user = User.Get()
            //    .SetFirstname("firstname05")
            //    .SetLastname("lastname05")
            //    .SetEmail("email05")
            //    .SetTelephone("telephone05")
            //    .SetAddress1("address105")
            //    .SetCity("city05")
            //    .SetPostcode("postcode05")
            //    .SetCountry("country05")
            //    .SetRegionState("regionState05")
            //    .SetPassword("password05")
            //    .SetSubscribe(true)
            //    .SetCompany("Company05")
            //    .Build();
            //Console.WriteLine("email = " + user.SetEmail("")); // Runtime Error
            //Console.WriteLine("email = " + user.Email);
            //
            // 6. Dependency Inversion
            //IUser user = User.Get()
            //     .SetFirstname("firstname06")
            //     .SetLastname("lastname06")
            //     .SetEmail("email06")
            //     .SetTelephone("telephone06")
            //     .SetAddress1("address106")
            //     .SetCity("city06")
            //     .SetPostcode("postcode06")
            //     .SetCountry("country06")
            //     .SetRegionState("regionState06")
            //     .SetPassword("password06")
            //     .SetSubscribe(true)
            //     .SetCompany("Company06")
            //     .Build();
            //Console.WriteLine("email = " + user.SetEmail(""));        // Compile Error
            //Console.WriteLine("email = " + ((User)user).SetEmail(""));  // Code Smell
            //Console.WriteLine("email = " + user.Email);
            //
            // 7. Singleton
            // 8. Repository
            IUser user = UserRepository.Get()
                .Registered();
            Console.WriteLine("email = " + user.Email);
        }

    }
}
