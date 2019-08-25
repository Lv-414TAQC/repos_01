using NLog;
using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;
using Rest414Test.Tools;
using System;
using System.Collections.Generic;

namespace Rest414Test.Tests
{
    [TestFixture]
    public class AdminTests3
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
            adminService.Logout();
        }

        [Test]
        public void CheckRemovingAdmin()
        {
            logger.Info("Checking removing admin started.");
            IUser adminForTest = UserRepository.Get().AdminForTest();
            adminService.AddAdmin(adminForTest);
            adminService.RemoveUser(adminForTest);
            Assert.IsFalse(adminService.IsAdmin(adminForTest));
            logger.Info("Is admin: " + adminService.IsAdmin(adminForTest));
            Assert.IsFalse(adminService.UserExists(adminForTest));
            logger.Info("User exists: " + adminService.UserExists(adminForTest));
            logger.Info("Checking removing admin done.");
        }

        [Test]
        public void CheckRemovingLoggedInAdmin()
        {
            logger.Info("Checking removing logged in admin started.");
            IUser adminForTest = UserRepository.Get().AdminForTest();
            adminService.AddAdmin(adminForTest);
            adminService.SuccessfulAdminLogin(adminForTest);
            adminService.RemoveUser(adminForTest);
            Assert.IsFalse(adminService.IsLoggedInAdmin(adminForTest));
            logger.Info("Is logged in admin: " + adminService.IsLoggedInAdmin(adminForTest));
            Assert.IsFalse(adminService.IsAdmin(adminForTest));
            logger.Info("Is admin: " + adminService.IsAdmin(adminForTest));
            Assert.IsFalse(adminService.UserExists(adminForTest));
            logger.Info("User exists: " + adminService.UserExists(adminForTest));
            logger.Info("Checking removing logged in admin done.");
        }

        [Test]
        public void CheckAdminRemovingHimself()
        {
            logger.Info("Checking removing admin by himself started.");
            IUser adminForTest = UserRepository.Get().AdminForTest();
            adminService.AddAdmin(adminForTest);
            AdminService anotherAdminService = adminService
                .SuccessfulAdminLogin(adminForTest);
            anotherAdminService.RemoveUser(adminForTest);
            Assert.IsTrue(adminService.IsAdmin(adminForTest));
            logger.Info("Is admin: " + adminService.IsAdmin(adminForTest));
            Assert.IsTrue(adminService.UserExists(adminForTest));
            logger.Info("User exists: " + adminService.UserExists(adminForTest));
            logger.Info("Checking removing admin by himself done.");
        }

        // DataProvider
        private static readonly object[] AdminFromCSV =
            ListUtils.ToMultiArray(UserRepository.Get().AdminsFromCsv());
        //private static readonly object[] AdminFromExcel =
        //    ListUtils.ToMultiArray(UserRepository.Get().AdminsFromExcel());

        [Test, TestCaseSource("AdminFromCSV")]
        //[Test, TestCaseSource("AdminFromExcel")]
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
