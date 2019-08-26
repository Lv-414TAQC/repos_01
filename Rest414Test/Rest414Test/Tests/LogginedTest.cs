using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Rest414Test.Data;
using Rest414Test.Services;

namespace Rest414Test.Tests
{
    [TestFixture]
    class LogginedTest
    {
        private GuestService guestService;
        private AdminService adminService;
        private UserService userService;

        // DataProviders
        private static readonly object[] Admins =
        {
            new object[] { UserRepository.Get().Admin() }
        };

        private static readonly object[] NewUsers =
        {
            new object[] { UserRepository.Get().NewUser() }
        };

        private static readonly object[] ExistUser_NewUser =
        {
            new object[] { UserRepository.Get().ExistUser(), UserRepository.Get().NewUser() }
        };

        private static object[] IncorrectPasswords =
        {
            new object[] { UserRepository.Get().IncorrectPasswordUser()},
            new object[] { UserRepository.Get().EmptyPasswordUser()},
            new object[] { UserRepository.Get().IncorrectPasswordAdmin()},
            new object[] { UserRepository.Get().EmptyPasswordAdmin()}
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
            adminService.Logout();
        }

        [TearDown]
        public void TearDown()
        {
            adminService = guestService.SuccessfulAdminLogin(UserRepository.Get().Admin());

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                guestService.logger.Info("TestContext.CurrentContext.Result.StackTrace = " + TestContext.CurrentContext.Result.StackTrace);
            }
           
            // Return to Previous State
            if ((adminService != null) && (adminService.IsLogged()))
            {
                //Delete created user
                adminService.RemoveUser(UserRepository.Get().NewUser());
                adminService.Logout();
            }
            
        }

        [Test, TestCaseSource("NewUsers")]
        public void CheckLoginLogoutUser(IUser user)
        {
            guestService.logger.Info("Start test CheckLoginLogoutUser");
     
            userService = guestService.SuccessfulUserLogin(user);
            Assert.IsTrue(userService.IsLogged());
            userService.Logout();
            Assert.IsFalse(userService.IsLogged());

            guestService.logger.Info("End test CheckLoginLogoutUser: ");
        }

        [Test, TestCaseSource("Admins")]
        public void CheckLoginLogoutAdmin(IUser admin)
        {
            guestService.logger.Info("Start test CheckLoginLogoutAdmin");

            adminService = guestService.SuccessfulAdminLogin(admin);
            Assert.IsTrue(adminService.IsLogged());
            adminService.Logout();
            Assert.IsFalse(adminService.IsLogged());

            guestService.logger.Info("End test CheckLoginLogoutAdmin");
        }

        [Test, TestCaseSource("ExistUser_NewUser")]
        public void CheckAnotherLogin(IUser firstUser, IUser secondUser)
        {
            userService = guestService.SuccessfulUserLogin(firstUser);
            Assert.IsTrue(userService.IsLogged());
            //first user don't logout!
            adminService = guestService.SuccessfulAdminLogin(secondUser);
            Assert.IsFalse(adminService.IsLogged());
        }

        [Test, TestCaseSource("IncorrectPasswords")]
        public void CheckIncorrectLogin(IUser incorrectUser)
        {
            guestService = guestService.UnsuccessfulLogin(incorrectUser);
        }

    }
}
