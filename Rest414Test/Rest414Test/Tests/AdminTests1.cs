using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;
using System;
using System.Collections.Generic;

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
            Console.WriteLine(adminForTest);
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
            List<IUser> allAdmins = adminService.GetAllAdmins();
            Assert.IsTrue(allAdmins.Contains(adminForTest));
        }

        [Test]
        public void CheckLoggingOutAdmin()
        {   
            adminService.SuccessfulAdminLogin(adminForTest);
            adminService.Logout(adminForTest);
            List<IUser> allAdmins = adminService.GetAllAdmins();
            foreach (IUser i in allAdmins)
            {
                Console.WriteLine(i.ToString());
            }
            Assert.IsTrue(allAdmins.Contains(adminForTest));
            List<IUser> allLoggedInAdmins = adminService.GetLoggedInAdmins();
            Assert.IsFalse(allLoggedInAdmins.Contains(adminForTest));
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
