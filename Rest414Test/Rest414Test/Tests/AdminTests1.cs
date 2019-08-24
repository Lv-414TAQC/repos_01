using NLog;
using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;

namespace Rest414Test.Tests
{
    [TestFixture]
    public class AdminTests1
    {
        Logger logger = LogManager.GetCurrentClassLogger();

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
            adminService.Logout();
        }

        [Test]
        public void CheckAddingAdmin()
        {
            logger.Info("Checking adding admin started.");
            Assert.IsTrue(adminService.IsAdmin(adminForTest));
            logger.Info("Is admin: " + adminService.IsAdmin(adminForTest));
            logger.Info("Checking adding admin done.");
        }

        [Test]
        public void CheckLoggingOutAdmin()
        {
            logger.Info("Checking logging admin out started.");
            adminService.SuccessfulAdminLogin(adminForTest);
            adminService.Logout(adminForTest);
            Assert.IsTrue(adminService.IsAdmin(adminForTest));
            logger.Info("Is admin: " + adminService.IsAdmin(adminForTest));
            Assert.IsFalse(adminService.IsLoggedInAdmin(adminForTest));
            logger.Info("Is logged in admin: " + adminService.IsLoggedInAdmin(adminForTest));
            logger.Info("Checking logging admin out done.");
        }
    }
}
