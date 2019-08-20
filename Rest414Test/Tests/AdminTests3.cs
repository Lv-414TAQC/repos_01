using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;
using System;

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
            string allAdmins = adminService.GetAllAdmins();
            Assert.IsFalse(allAdmins.Contains(adminForTest.Name));
        }

        [Test]
        public void CheckRemovingLoggedInAdmin()
        {
            IUser adminForTest = UserRepository.Get().AdminForTest();
            adminService.AddAdmin(adminForTest);
            adminService.SuccessfulAdminLogin(adminForTest);
            adminService.RemoveUser(adminForTest);
            string allLoggedInAdmins = adminService.GetLoggedInAdmins();
            Assert.IsFalse(allLoggedInAdmins.Contains(adminForTest.Name));
        }

        [Test]
        public void CheckLoggingInRemovedUser()
        {
            IUser anotherAdmin = UserRepository.Get().AnotherAdmin();
            adminService.AddAdmin(anotherAdmin);
            adminService.RemoveUser(anotherAdmin);
            adminService.SuccessfulAdminLogin(anotherAdmin);
            string allLoggedInAdmins = adminService.GetLoggedInAdmins();
            Console.WriteLine(allLoggedInAdmins);
            Assert.IsFalse(allLoggedInAdmins.Contains(anotherAdmin.Name));
        }

        [Test]
        public void CheckAdminRemovingHimself()
        {
            IUser adminForTest = UserRepository.Get().AdminForTest();
            adminService.AddAdmin(adminForTest);
            AdminService anotherAdminService = adminService
                .SuccessfulAdminLogin(adminForTest);
            anotherAdminService.RemoveUser(adminForTest);
            string allAdmins = adminService.GetAllAdmins();
            Assert.IsFalse(allAdmins.Contains(adminForTest.Name));
        }
    }
}
