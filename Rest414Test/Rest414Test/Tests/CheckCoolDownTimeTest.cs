using Allure.Commons;
using NLog;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;
using Rest414Test.Tools;
using System;

namespace Rest414Test.Tests
{
    [AllureNUnit]
    [AllureDisplayIgnored]
    [TestFixture]
    class CheckCoolDownTimeTest
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        AdminService adminService;
        IUser adminUser = UserRepository.Get().Admin();
        IUser IncorrectUserForLock = UserRepository.Get().IncorrectUserForLock();

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
  
        }
        
        
        //DataProvider
        private static readonly object[] UserForLockCSV =
            ListUtils.ToMultiArray(UserRepository.Get().UserForLockCsv()); 
        [Test, TestCaseSource("UserForLockCSV")]
        [AllureTag("Regression_Tag")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-218")]
        [AllureOwner("Alena Basanets")]
        [AllureParentSuite("CheckCoolDownTimeTest")]
        [AllureLink("Rest_Application_Link", "https://localhost:8080/")]
        public void CheckLockingOfUser(IUser userForLock)  
        {
            GuestService guestService = new GuestService();
            adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            logger.Info("Check locking of user started");
            adminService.CreateUser(userForLock);
            logger.Info("List of  users: " + adminService.CreateUser(userForLock));
            Assert.IsTrue(adminService.GetAllUsers().Contains(userForLock));
            adminService.Logout();
            guestService = guestService.LockingUser(IncorrectUserForLock);
            adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            adminService.GetLockedUsers();
            Assert.IsTrue(adminService.GetLockedUsers().Contains(userForLock));
            logger.Info("List of locked users: " + adminService.GetLockedUsers());
            logger.Info("Check locking of user done.");
        }
        //add jira

        [Test, TestCaseSource("UserForLockCSV")]
        [AllureTag("Regression_Tag")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-218")]
        [AllureOwner("Alena Basanets")]
        [AllureParentSuite("CheckCoolDownTimeTest")]
        [AllureLink("Rest_Application_Link", "https://localhost:8080/")]
        public void UnlockOfUser(IUser userForLock)
        {
            logger.Info("Unlock of user started.");
            adminService.UnlockUser(userForLock);
            Assert.IsFalse(adminService.GetLockedUsers().Contains(userForLock));
            logger.Info("List of locked users: " + adminService.GetLockedUsers());
            logger.Info("Unlock of user done.");
        }

        [Test, TestCaseSource("UserForLockCSV")]
        [AllureTag("Regression_Tag")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-218")]
        [AllureOwner("Alena Basanets")]
        [AllureParentSuite("CheckCoolDownTimeTest")]
        [AllureLink("Rest_Application_Link", "https://localhost:8080/")]
        public void LockOfUser(IUser userForLock)
        {
            logger.Info("Lock of user started.");
            adminService.LockUser(userForLock);
            Assert.IsTrue(adminService.GetLockedUsers().Contains(userForLock));
            logger.Info("List of locked users: " + adminService.GetLockedUsers());
            logger.Info("Lock of user done.");
        }
    }
}
