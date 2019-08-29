using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Rest414Test.Data;
using Rest414Test.Services;
using Rest414Test.Tools;
using System;

namespace Rest414Test.Tests
{
    [AllureNUnit]
    [AllureDisplayIgnored]
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

        private static readonly object[] ExistUsers =
        {
            new object[] { UserRepository.Get().ExistUser() }
        };

        private static readonly object[] IncorrectFromCSV =
            ListUtils.ToMultiArray(UserRepository.Get().IncorrectUsersFromCsv());

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
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
               // guestService.logger.Info("TestContext.CurrentContext.Result.StackTrace = " +
                //TestContext.CurrentContext.Result.StackTrace);
            }

            // Return to Previous State
            adminService = guestService.SuccessfulAdminLogin(UserRepository.Get().Admin());
            if ((adminService != null) && (adminService.IsLogged()))
            {
                //Delete created user
                adminService.RemoveUser(UserRepository.Get().NewUser());
                adminService.Logout();
            }

        }

        [Test, TestCaseSource("ExistUsers")]
        public void CheckLoginLogoutUser(IUser user)
        {
           // guestService.logger.Info("Start test CheckLoginLogoutUser");

            userService = guestService.SuccessfulUserLogin(user);
            Assert.IsTrue(userService.IsLogged());
            userService.Logout();
            Assert.IsFalse(userService.IsLogged());

           // guestService.logger.Info("End test CheckLoginLogoutUser: ");
        }

        [Test, TestCaseSource("Admins")]
        [AllureTag("Regression_Tag")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-171")]
        [AllureTms("TMS-12")]
        [AllureOwner("User_Owner")]
        [AllureParentSuite("With_parameters_ParentSuite")]
        [AllureSuite("Passed_Suite")]
        [AllureSubSuite("NoAssert_SubSuite")]
        [AllureEpic("Retry_Epic")]
        [AllureFeature("RetrySmall_Feature")]
        [AllureLink("Rest_Application_Link", "https://localhost:8080/")]
        public void CheckLoginLogoutAdmin(IUser admin)
        {
            //guestService.logger.Info("Start test CheckLoginLogoutAdmin");

            adminService = guestService.SuccessfulAdminLogin(admin);
            Assert.IsTrue(adminService.IsLogged());
            adminService.Logout();
            Assert.IsFalse(adminService.IsLogged());

            //guestService.logger.Info("End test CheckLoginLogoutAdmin");
        }

        [Test, TestCaseSource("ExistUsers")]
        public void CheckLoginUserAsAdmin(IUser existUser)
        { 
            Assert.Throws<Exception>(() => guestService.SuccessfulAdminLogin(existUser));
            //guestService.logger.Info("Test CheckLoginUserAsAdmin: throw expected exception");
        }

       
        [Test, TestCaseSource("IncorrectFromCSV")]
        public void CheckIncorrectLogin(IUser incorrectUser)
        {
           // guestService.logger.Info("Start test CheckIncorrectLogin");
            guestService = guestService.UnsuccessfulLogin(incorrectUser);
            //guestService.logger.Info("End test CheckIncorrectLogin");
        }

    }
}
