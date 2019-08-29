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
    public class AdminTestExternalData
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
            adminService.ResetSystem();
        }

        // DataProvider
        private static readonly object[] AdminFromCSV =
            ListUtils.ToMultiArray(UserRepository.Get().AdminsFromCsv());
        
        [Test, TestCaseSource("AdminFromCSV")]
        [AllureTag("Regression_Tag")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-209")]
        [AllureOwner("User_Owner")]
        [AllureParentSuite("With_parameters_ParentSuite")]
        [AllureSuite("Passed_Suite")]
        [AllureSubSuite("NoAssert_SubSuite")]
        [AllureEpic("Retry_Epic")]
        [AllureFeature("RetrySmall_Feature")]
        [AllureLink("Rest_Application_Link", "https://localhost:8080/")]
        public void CheckLoggingInRemovedAdmin(IUser anotherAdmin)
        {
            logger.Info("Checking logging removed admin in started.");
            adminService.AddAdmin(anotherAdmin);
            adminService.RemoveUser(anotherAdmin);
            Assert.Throws<Exception>(()=>adminService.SuccessfulAdminLogin(anotherAdmin));
            logger.Info("Expected exception is thrown.");
            logger.Info("Checking logging removed admin in done.");
        }
    }
}
