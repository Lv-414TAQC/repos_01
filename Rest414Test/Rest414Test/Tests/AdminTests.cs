using Allure.Commons;
using NLog;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;
using System;

namespace Rest414Test.Tests
{
    [AllureNUnit]
    [AllureDisplayIgnored]
    [TestFixture]
    public class AdminTests
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
            adminService.ResetSystem();
        }

        [Test]
        [AllureTag("Regression_Tag")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-202")]
        [AllureOwner("User_Owner")]
        [AllureParentSuite("With_parameters_ParentSuite")]
        [AllureSuite("Passed_Suite")]
        [AllureSubSuite("NoAssert_SubSuite")]
        [AllureEpic("Retry_Epic")]
        [AllureFeature("RetrySmall_Feature")]
        [AllureLink("Rest_Application_Link", "https://localhost:8080/")]
        public void CheckAddingAdmin()
        {
            logger.Info("Checking adding admin started.");
            Assert.IsTrue(adminService.IsAdmin(adminForTest));
            logger.Info("Is admin: " + adminService.IsAdmin(adminForTest));
            logger.Info("Checking adding admin done.");
        }

        [Test]
        [AllureTag("Regression_Tag")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-203")]
        [AllureOwner("User_Owner")]
        [AllureParentSuite("With_parameters_ParentSuite")]
        [AllureSuite("Passed_Suite")]
        [AllureSubSuite("NoAssert_SubSuite")]
        [AllureEpic("Retry_Epic")]
        [AllureFeature("RetrySmall_Feature")]
        [AllureLink("Rest_Application_Link", "https://localhost:8080/")]
        public void CheckLoggingInAdmin()
        {
            logger.Info("Checking logging admin in started.");
            adminService.SuccessfulAdminLogin(adminForTest);
            Assert.IsTrue(adminService.IsLoggedInAdmin(adminForTest));
            logger.Info("Is logged in admin: " + adminService.IsLoggedInAdmin(adminForTest));
            logger.Info("Checking logging admin in done.");
        }

        [Test]
        [AllureTag("Regression_Tag")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-204")]
        [AllureOwner("User_Owner")]
        [AllureParentSuite("With_parameters_ParentSuite")]
        [AllureSuite("Passed_Suite")]
        [AllureSubSuite("NoAssert_SubSuite")]
        [AllureEpic("Retry_Epic")]
        [AllureFeature("RetrySmall_Feature")]
        [AllureLink("Rest_Application_Link", "https://localhost:8080/")]
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

        [Test]
        [AllureTag("Regression_Tag")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-205")]
        [AllureOwner("User_Owner")]
        [AllureParentSuite("With_parameters_ParentSuite")]
        [AllureSuite("Passed_Suite")]
        [AllureSubSuite("NoAssert_SubSuite")]
        [AllureEpic("Retry_Epic")]
        [AllureFeature("RetrySmall_Feature")]
        [AllureLink("Rest_Application_Link", "https://localhost:8080/")]
        public void CheckRemovingAdmin()
        {
            logger.Info("Checking removing admin started.");
            adminService.RemoveUser(adminForTest);
            Assert.IsFalse(adminService.IsAdmin(adminForTest));
            logger.Info("Is admin: " + adminService.IsAdmin(adminForTest));
            Assert.IsFalse(adminService.UserExists(adminForTest));
            logger.Info("User exists: " + adminService.UserExists(adminForTest));
            logger.Info("Checking removing admin done.");
        }

        [Test]
        [AllureTag("Regression_Tag")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-206")]
        [AllureOwner("User_Owner")]
        [AllureParentSuite("With_parameters_ParentSuite")]
        [AllureSuite("Passed_Suite")]
        [AllureSubSuite("NoAssert_SubSuite")]
        [AllureEpic("Retry_Epic")]
        [AllureFeature("RetrySmall_Feature")]
        [AllureLink("Rest_Application_Link", "https://localhost:8080/")]
        public void CheckRemovingLoggedInAdmin()
        {
            logger.Info("Checking removing logged in admin started.");
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
        [AllureTag("Regression_Tag")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-207")]
        [AllureOwner("User_Owner")]
        [AllureParentSuite("With_parameters_ParentSuite")]
        [AllureSuite("Passed_Suite")]
        [AllureSubSuite("NoAssert_SubSuite")]
        [AllureEpic("Retry_Epic")]
        [AllureFeature("RetrySmall_Feature")]
        [AllureLink("Rest_Application_Link", "https://localhost:8080/")]
        public void CheckAdminRemovingHimself()
        {
            logger.Info("Checking removing admin by himself started.");
            AdminService anotherAdminService = adminService
                .SuccessfulAdminLogin(adminForTest);
            anotherAdminService.RemoveUser(adminForTest);
            Assert.IsTrue(adminService.IsAdmin(adminForTest));
            logger.Info("Is admin: " + adminService.IsAdmin(adminForTest));
            Assert.IsTrue(adminService.UserExists(adminForTest));
            logger.Info("User exists: " + adminService.UserExists(adminForTest));
            logger.Info("Checking removing admin by himself done.");
        }

        [Test]
        [AllureTag("Regression_Tag")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-208")]
        [AllureOwner("User_Owner")]
        [AllureParentSuite("With_parameters_ParentSuite")]
        [AllureSuite("Passed_Suite")]
        [AllureSubSuite("NoAssert_SubSuite")]
        [AllureEpic("Retry_Epic")]
        [AllureFeature("RetrySmall_Feature")]
        [AllureLink("Rest_Application_Link", "https://localhost:8080/")]
        public void CheckAddingSameNameUser()
        {
            logger.Info("Checking adding a user with the same name as previously removed admin's started.");
            adminService.RemoveUser(adminForTest);
            adminService.CreateUser(adminForTest);
            Assert.Throws<Exception>(() => adminService.SuccessfulAdminLogin(adminForTest));
            logger.Info("Expected exception is thrown.");
            logger.Info("Checking adding a user with the same name as previously removed admin's done.");
        }
    }
}
