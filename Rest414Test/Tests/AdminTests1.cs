using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;
using System;

namespace Rest414Test.Tests
{
    [TestFixture]
    public class AdminTests1
    {
        AdminService adminService;
        IUser adminForTest;

        [SetUp]
        public void SetUp()
        {
            IUser adminUser = UserRepository.Get().Admin();
            GuestService guestService = new GuestService();
            adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            adminForTest = UserRepository.Get().AdminForTest();
            adminService.AddAdmin(adminForTest);
        }

        [TearDown]
        public void TearDown()
        {
            adminService.RemoveUser(adminForTest);
        }

        [Test]
        public void CheckAddingAdmin()
        {
            string allAdmins = adminService.GetAllAdmins();
            Assert.IsTrue(allAdmins.Contains(adminForTest.Name));
        }

        [Test]
        public void CheckLoggingOutAdmin()
        {   
            adminService.SuccessfulAdminLogin(adminForTest);
            adminService.Logout(adminForTest);
            string allAdmins = adminService.GetAllAdmins();
            Assert.IsTrue(allAdmins.Contains(adminForTest.Name));
            string allLoggedInAdmins = adminService.GetLoggedInAdmins();
            Assert.IsFalse(allLoggedInAdmins.Contains(adminForTest.Name));
        }

        //[Test]
        //public void CheckAddingSameNameUser()
        //{
        //    IUser adminUser = UserRepository.Get().Admin();
        //    GuestService guestService = new GuestService();
        //    adminService = guestService
        //        .SuccessfulAdminLogin(adminUser);
        //    adminForTest = UserRepository.Get().AdminForTest();
        //    adminService.AddAdmin(adminForTest);
        //    adminService.RemoveUser(adminForTest);
        //    adminService.
        //}

        
    }
}
