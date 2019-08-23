using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;
using System.Collections.Generic;

namespace Rest414Test.Tests
{
    [TestFixture]
    public class AdminTests2
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
            adminService.Logout(adminForTest);
            adminService.RemoveUser(adminForTest);
        }

        [Test]
        public void CheckLoggingInAdmin()
        {
            adminService.SuccessfulAdminLogin(adminForTest);
            List<IUser> allLoggedInAdmins = adminService.GetLoggedInAdmins();
            Assert.IsTrue(allLoggedInAdmins.Contains(adminForTest));
        }

        [Test]
        public void CheckAddingSameNameUser()
        {
            adminService.RemoveUser(adminForTest);
            adminService.CreateUser(adminForTest);
            adminService = adminService
                .SuccessfulAdminLogin(adminForTest);
            List<IUser> allAdmins = adminService.GetAllAdmins(adminForTest);
            Assert.IsTrue(allAdmins.Count == 0);
        }
    }
}
