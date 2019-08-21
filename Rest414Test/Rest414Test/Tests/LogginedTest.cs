using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Rest414Test.Data;
using Rest414Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest414Test.Tests
{
    [TestFixture]
    class LogginedTest
    {
        private GuestService guestService;
        //private AdminService userService;
        private AdminService adminService;
        private UserService userService;

        // DataProvider
        private static readonly object[] Admins =
        {
            new object[] { UserRepository.Get().Admin() }
        };

        // DataProvider
        private static readonly object[] NewUsers =
        {
            new object[] { UserRepository.Get().NewUser() }
        };

        // DataProvider
        private static readonly object[] TokenLifeTimes =
        {
            new object[] { LifetimeRepository.GetLongTime() }
        };


        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            guestService = new GuestService();
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
        }

        //[SetUp, TestCaseSource("Admins")]
        [SetUp]
        //public void SetUp(IUser adminUser)
        public void SetUp()
        {
            //adminService = guestService.SuccessfulAdminLogin(adminUser);
            adminService = guestService.SuccessfulAdminLogin(UserRepository.Get().Admin());
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                // TODO Save to Log File
                Console.WriteLine("TestContext.CurrentContext.Result.StackTrace = " + TestContext.CurrentContext.Result.StackTrace);
                // Clear Cache
            }
            //
            // Return to Previous State
            if ((adminService != null) && (adminService.IsLoggined()))
            {
                Lifetime currentTokenlifetime = LifetimeRepository.GetDefault();
                adminService = adminService.UpdateTokenlifetime(currentTokenlifetime);
            }
            //
            // TODO for User
            if ((adminService != null) && (adminService.IsLoggined()))
            {
                guestService = adminService.Logout();
                adminService = null;
            }
        }


        [Test, TestCaseSource("NewUsers")]
        public void CheckCreatingUser(IUser newUser)
        {
            adminService.CreateUser(newUser);
            Assert.IsTrue(adminService.GetAllUsers().Contains(new User(newUser.Name)));
            userService = guestService.SuccessfulUserLogin(UserRepository.Get().NewUser());
            Assert.IsTrue(userService.IsLoggined());
            //  adminService.Logout();

        }

    }
}
