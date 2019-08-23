using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Rest414Test.Data;
using Rest414Test.Services;
using System;

namespace Rest414Test.Tests
{
    [TestFixture]
    class LogginedTest
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        private GuestService guestService;
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
        private static readonly object[] UserAdmin =
        {
            new object[] { UserRepository.Get().NewUser(), UserRepository.Get().Admin() }
        };

        // DataProvider
        private static object[] IncorrectPasswordUser =
        {
            new object[] { UserRepository.Get().IncorrectPasswordUser()},
            new object[] { UserRepository.Get().EmptyPasswordUser()}
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

       [SetUp]
       public void SetUp()
        {
            adminService = guestService.SuccessfulAdminLogin(UserRepository.Get().Admin());
            adminService.CreateUser(UserRepository.Get().NewUser());
            adminService.GetAllUsers();
            //Assert.IsTrue(adminService.GetAllUsers().Contains(new User(newUser.Name)));
            adminService.Logout();
        }

        [TearDown]
        public void TearDown()
        {
            //Delete created user
            adminService = guestService.SuccessfulAdminLogin(UserRepository.Get().Admin());
            adminService.RemoveUser(UserRepository.Get().NewUser());
            adminService.Logout();

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
        public void CheckLoginLogoutUser(IUser newUser)
        {
            logger.Info("Start test CheckLoginLogoutUser");
     
            userService = guestService.SuccessfulUserLogin(newUser);
            Assert.IsTrue(userService.IsLoggined());
            userService.Logout();
            Assert.IsFalse(userService.IsLoggined());

            logger.Info("End test CheckLoginLogoutUser: " + newUser.Name);
        }

        [Test, TestCaseSource("UserAdmin")]
        public void CheckAnotherLogin(IUser newUser, IUser adminUser)
        {
            userService = guestService.SuccessfulUserLogin(newUser);
            Assert.IsTrue(userService.IsLoggined());
            adminService = guestService.SuccessfulAdminLogin(adminUser);
            Assert.IsFalse(adminService.IsLoggined());
        }

        [Test, TestCaseSource("IncorrectPasswordUser")]
        public void CheckIncorrectLogin(IUser incorrectUser)
        {
            Assert.IsTrue(guestService.UnsuccessfulLogin(incorrectUser)
                .GetType() == typeof(GuestService));
        }

    }
}
