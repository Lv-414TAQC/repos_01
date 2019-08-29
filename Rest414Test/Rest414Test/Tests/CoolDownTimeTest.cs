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
            adminService.Logout();
            adminService.ResetSystem();
        }
        [Test]
        [AllureTag("Regression_Tag")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-53")]
        [AllureOwner("User_Owner")]
        [AllureParentSuite("With_parameters_ParentSuite")]
        [AllureSuite("Passed_Suite")] //change names
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
            logger.Info("Change CoolDownTime done.");
        }
    }
}