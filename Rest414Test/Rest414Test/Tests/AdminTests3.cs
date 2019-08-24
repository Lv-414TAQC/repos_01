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
            List<IUser> allAdmins = adminService.GetAllAdmins();
            Assert.IsFalse(allAdmins.Contains(adminForTest));
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
            List<IUser> allLoggedInAdmins = adminService.GetLoggedInAdmins();
            Assert.IsFalse(allLoggedInAdmins.Contains(adminForTest));
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
            List<IUser> allAdmins = adminService.GetAllAdmins();
            Assert.IsTrue(allAdmins.Contains(adminForTest));
            logger.Info("Checking removing admin by himself done.");
        }

        // DataProvider
        private static readonly object[] AdminFromCSV =
            ListUtils.ToMultiArray(UserRepository.Get().AdminsFromCsv());
        private static readonly object[] AdminFromExcel =
            ListUtils.ToMultiArray(UserRepository.Get().AdminsFromExcel());

        //[Test, TestCaseSource(nameof(AdminFromCSV))]
        [Test, TestCaseSource(nameof(AdminFromExcel))]
        public void CheckLoggingInRemovedAdmin(IUser anotherAdmin)
        {
            logger.Info("Checking logging removed admin in started.");
            adminService.AddAdmin(anotherAdmin);
            adminService.RemoveUser(anotherAdmin);
            Assert.Throws<Exception>(()=>adminService.SuccessfulAdminLogin(anotherAdmin));
            logger.Info("Checking logging removed admin in done.");
        }
    }
}
