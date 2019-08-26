using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Rest414Test.Data;
using Rest414Test.Services;
using Rest414Test.Tools;
using System;

namespace Rest414Test.Tests
{
    [TestFixture]
    public class LifeTimeTest
    {
        private GuestService guestService;
        private AdminService adminService;

        private static readonly object[] Admins =
        {
            new object[] { UserRepository.Get().Admin() }
        };

        private static readonly object[] TokenLifeTimes =
        {
            new object[] { LifetimeRepository.GetLongTime() }
        };


        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            guestService = new GuestService();
        }

        //[OneTimeTearDown]
        public void AfterAllMethods()
        {
        }

        [SetUp]
        public void SetUp()
        {
            adminService = guestService.SuccessfulAdminLogin(UserRepository.Get().Admin());
        }

        //[TearDown]
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

        [Test, TestCaseSource("TokenLifeTimes")]
        public void CheckTimeChange(Lifetime newTokenlifetime)
        {
            adminService = adminService.UpdateTokenlifetime(newTokenlifetime);
            Lifetime currentTokenlifetime = adminService.GetCurrentTokenLifetime();
            Assert.AreEqual(LifetimeRepository.LONG_TOKEN_LIFETIME,
                        currentTokenlifetime.Time, "Long Time Error");
        }
                
        private static readonly object[] AdminCSVUsers =
            ListUtils.ToMultiArray(UserRepository.Get().FromCsv(), LifetimeRepository.GetLongTime());

        [Test, TestCaseSource("AdminCSVUsers")]
        public void ExamineTime(IUser adminUser, Lifetime newTokenlifetime)
        {
            Console.WriteLine("*** adminUser:  " + adminUser);
            GuestService guestService = new GuestService();
            Lifetime currentTokenlifetime = guestService.GetCurrentTokenLifetime();
            Assert.AreEqual(LifetimeRepository.DEFAULT_TOKEN_LIFETIME,
                        currentTokenlifetime.Time, "Current Time Error");
            AdminService adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            adminService = adminService.UpdateTokenlifetime(newTokenlifetime);
            currentTokenlifetime = adminService.GetCurrentTokenLifetime();
            Assert.AreEqual(LifetimeRepository.LONG_TOKEN_LIFETIME,
                        currentTokenlifetime.Time, "Long Time Error");
            guestService = adminService.Logout();
            Assert.IsEmpty(adminUser.Token, "Logout Error"); // TODO
            currentTokenlifetime.Time = LifetimeRepository.DEFAULT_TOKEN_LIFETIME;
            adminService = guestService.SuccessfulAdminLogin(adminUser);
            adminService = adminService.UpdateTokenlifetime(currentTokenlifetime);
            guestService = adminService.Logout();
            currentTokenlifetime = guestService.GetCurrentTokenLifetime();
            Assert.AreEqual(LifetimeRepository.DEFAULT_TOKEN_LIFETIME,
                        currentTokenlifetime.Time, "Current Time Error");
        }
    }
}
