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
        AdminService adminService;
        [SetUp]
        public void SetUp()
        {
            IUser adminUser = UserRepository.Get().Admin();
            GuestService guestService = new GuestService();
            adminService = guestService
                .SuccessfulAdminLogin(adminUser);
        }

        [Test]
        public void CheckRemovingAdmin()
        {
            IUser adminForTest = UserRepository.Get().AdminForTest();
            adminService.AddAdmin(adminForTest);
            adminService.RemoveUser(adminForTest);
            List<IUser> allAdmins = adminService.GetAllAdmins();
            Assert.IsFalse(allAdmins.Contains(adminForTest));
        }

        [Test]
        public void CheckRemovingLoggedInAdmin()
        {
            IUser adminForTest = UserRepository.Get().AdminForTest();
            adminService.AddAdmin(adminForTest);
            adminService.SuccessfulAdminLogin(adminForTest);
            adminService.RemoveUser(adminForTest);
            List<IUser> allLoggedInAdmins = adminService.GetLoggedInAdmins();
            Assert.IsFalse(allLoggedInAdmins.Contains(adminForTest));
        }

        [Test]
        public void CheckAdminRemovingHimself()
        {
            IUser adminForTest = UserRepository.Get().AdminForTest();
            adminService.AddAdmin(adminForTest);
            AdminService anotherAdminService = adminService
                .SuccessfulAdminLogin(adminForTest);
            anotherAdminService.RemoveUser(adminForTest);
            List<IUser> allAdmins = adminService.GetAllAdmins();
            Assert.IsTrue(allAdmins.Contains(adminForTest));
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
            adminService.AddAdmin(anotherAdmin);
            adminService.RemoveUser(anotherAdmin);
            Console.WriteLine("*********" + anotherAdmin.ToString());
            adminService.UnsuccessfulLogin(anotherAdmin);
            List<IUser> allLoggedInAdmins = adminService.GetLoggedInAdmins();
            Console.WriteLine(allLoggedInAdmins);
            Assert.IsFalse(allLoggedInAdmins.Contains(anotherAdmin));
        }
    }
}
