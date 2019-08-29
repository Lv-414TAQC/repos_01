using Allure.Commons;
using NLog;
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
    class LoggedTest
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

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
                logger.Info("TestContext.CurrentContext.Result.StackTrace = " +
                    TestContext.CurrentContext.Result.StackTrace);
            }

            // Return to Previous State
             adminService = guestService.SuccessfulAdminLogin(UserRepository.Get().Admin());
             //Delete created user
             adminService.RemoveUser(UserRepository.Get().NewUser());
             adminService.Logout();
        }

        [Test, TestCaseSource("ExistUsers")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-210")]
        [AllureOwner("KukliakT")]
        [AllureParentSuite("LoggedTest_Suite")]
        [AllureSuite("Main_Suite")]
        [AllureLink("Rest_Application_Link", "localhost:8080/")]
        public void CheckLoginLogoutUser(IUser user)
        {
            logger.Info("Start test CheckLoginLogoutUser");

            userService = guestService.SuccessfulUserLogin(user);
            Assert.IsTrue(userService.IsLogged());
            userService.Logout();
            Assert.IsFalse(userService.IsLogged());

            logger.Info("End test CheckLoginLogoutUser: ");
        }

        [Test, TestCaseSource("Admins")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-211")]
        [AllureOwner("KukliakT")]
        [AllureParentSuite("LoggedTest_Suite")]
        [AllureSuite("Main_Suite")]
        [AllureLink("Rest_Application_Link", "localhost:8080/")]
        public void CheckLoginLogoutAdmin(IUser admin)
        {
            logger.Info("Start test CheckLoginLogoutAdmin");

            adminService = guestService.SuccessfulAdminLogin(admin);
            Assert.IsTrue(adminService.IsLogged());
            adminService.Logout();
            Assert.IsFalse(adminService.IsLogged());

            logger.Info("End test CheckLoginLogoutAdmin");
        }

        [Test, TestCaseSource("ExistUsers")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-217")]
        [AllureOwner("KukliakT")]
        [AllureParentSuite("LoggedTest_Suite")]
        [AllureSuite("Main_Suite")]
        [AllureLink("Rest_Application_Link", "localhost:8080/")]
        public void CheckLoginUserAsAdmin(IUser existUser)
        { 
            Assert.Throws<Exception>(() => guestService.SuccessfulAdminLogin(existUser));
            logger.Info("Test CheckLoginUserAsAdmin: throw expected exception");
        }

       
        [Test, TestCaseSource("IncorrectFromCSV")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-212")]
        [AllureOwner("KukliakT")]
        [AllureParentSuite("LoggedTest_Suite")]
        [AllureSuite("Main_Suite")]
        [AllureLink("Rest_Application_Link", "localhost:8080/")]
        public void CheckIncorrectLogin(IUser incorrectUser)
        {
            logger.Info("Start test CheckIncorrectLogin");
            guestService = guestService.UnsuccessfulLogin(incorrectUser);
            Assert.AreEqual(guestService.ResultStatus, "true");
            logger.Info("End test CheckIncorrectLogin");
        }

    }
}
