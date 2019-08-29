using Allure.Commons;
using NLog;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;
using Rest414Test.Tools;
using System;

namespace Rest414Test.Tests
{
        
    [TestFixture]
    class CoolDownTimeTest
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        AdminService adminService;
        
        //IUser UserForLock = UserRepository.Get().UserForLock();
        IUser IncorrectUserForLock = UserRepository.Get().IncorrectUserForLock();
        IUser adminUser = UserRepository.Get().Admin();

        [SetUp]
        public void SetUp()
        {

        GuestService guestService = new GuestService();
            adminService = guestService
                .SuccessfulAdminLogin(adminUser);
        }

        [TearDown]
        public void TearDown()
        {
            adminService.Logout();
            adminService.ResetSystem();
        }
        [Test]
        [AllureTag("Regression_Tag")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-53")]
        [AllureTms("TMS-12")]
        [AllureOwner("User_Owner")]
        [AllureParentSuite("With_parameters_ParentSuite")]
        [AllureSuite("Passed_Suite")]
        [AllureSubSuite("NoAssert_SubSuite")]
        [AllureEpic("Retry_Epic")]
        [AllureFeature("RetrySmall_Feature")]
        [AllureLink("Rest_Application_Link", "https://localhost:8080/")]
        public void ChangeCoolDownTime()
        {
            logger.Info("Change CoolDownTime started.");
            CoolDownTime currentCoolDownime = CoolDownTimeRepository.GetDefault();
            logger.Info("Default time: " + currentCoolDownime.Time);
            currentCoolDownime = CoolDownTimeRepository.NewCoolDown();
            adminService.UpdateCoolDowntime(currentCoolDownime);
            logger.Info("New time: " + currentCoolDownime.Time);
            Assert.IsTrue(currentCoolDownime.Time.Equals(adminService.GetCoolDownTime()));
            //adminService.Logout();
            //adminService.ResetSystem();
            logger.Info("Change CoolDownTime done.");
        }
        //DataProvider
        private static readonly object[] UserForLockCSV =
            ListUtils.ToMultiArray(UserRepository.Get().UserForLockCsv());

        
        [Test, TestCaseSource("UserForLockCSV")]
        public void CheckLockingOfUser(IUser UserForLock) 
        {
            GuestService guestService = new GuestService();
            adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            logger.Info("Check locking of user started");
            adminService.CreateUser(UserForLock);
            logger.Info("List of  users: " + adminService.CreateUser(UserForLock));
            Assert.IsTrue(adminService.GetAllUsers().Contains(new User(UserForLock.Name)));
            adminService.Logout();

            guestService = guestService.LockingUser(IncorrectUserForLock);
            adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            adminService.GetLockedUsers();
            Assert.IsTrue(adminService.GetLockedUsers().Contains(new User(UserForLock.Name)));
            logger.Info("List of locked users: " + adminService.GetLockedUsers());
            logger.Info("Check locking of user done.");
        }
       

        [Test, TestCaseSource("UserForLockCSV")]
        //[Test]
        public void UnlockOfUser(IUser UserForLock)
        {
            logger.Info("Unlock of user started.");
            adminService.UnlockUser(UserForLock);
            Assert.IsFalse(adminService.GetLockedUsers().Contains(new User(UserForLock.Name)));
            logger.Info("List of locked users: " + adminService.GetLockedUsers());
            logger.Info("Unlock of user done.");
        }

        [Test, TestCaseSource("UserForLockCSV")]
        //[Test]
        public void LockOfUser(IUser UserForLock)
        {
            logger.Info("Lock of user started.");
            adminService.LockUser(UserForLock);
            Assert.IsTrue(adminService.GetLockedUsers().Contains(new User(UserForLock.Name)));
            logger.Info("List of locked users: " + adminService.GetLockedUsers());
            logger.Info("Lock of user done.");
        }
    }
}
