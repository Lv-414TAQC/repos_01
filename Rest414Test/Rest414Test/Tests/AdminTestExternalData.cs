using NLog;
using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;
using Rest414Test.Tools;
using System;

namespace Rest414Test.Tests
{
    [TestFixture]
    public class AdminTestExternalData
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        AdminService adminService;
        [SetUp]
        public void SetUp()
        {
            IUser adminUser = UserRepository.Get().Admin();
            GuestService guestService = new GuestService();
            adminService = guestService
                .SuccessfulAdminLogin(adminUser);
        }

        [TearDown]
        public void TearDown()
        {
            adminService.ResetSystem();
        }

        // DataProvider
        private static readonly object[] AdminFromCSV =
            ListUtils.ToMultiArray(UserRepository.Get().AdminsFromCsv());
        
        [Test, TestCaseSource("AdminFromCSV")]
        public void CheckLoggingInRemovedAdmin(IUser anotherAdmin)
        {
            logger.Info("Checking logging removed admin in started.");
            adminService.AddAdmin(anotherAdmin);
            adminService.RemoveUser(anotherAdmin);
            Assert.Throws<Exception>(()=>adminService.SuccessfulAdminLogin(anotherAdmin));
            logger.Info("Expected exception is thrown.");
            logger.Info("Checking logging removed admin in done.");
        }
    }
}
