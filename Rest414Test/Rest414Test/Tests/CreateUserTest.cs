using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;
using Rest414Test.Tools;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Allure.Commons;
using NLog;

namespace Rest414Test.Tests
{
    [AllureNUnit]
    [AllureDisplayIgnored]
    [TestFixture]
    class CreateUserTest
    {
        public Logger logger = LogManager.GetCurrentClassLogger();
        private GuestService guestService = new GuestService();
        private AdminService adminService;

        IUser simpleUser = UserRepository.Get().CreateNewUser();

        private static readonly object[] UsersCsv =
            ListUtils.ToMultiArray(UserRepository.Get().FromCsv());

        [TearDown]
        public void TearDown()
        {
            adminService.ResetSystem();
        }

        [Test, TestCaseSource("UsersCsv")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-214")]        
        [AllureOwner("DomashovetsDmytro")]
        [AllureParentSuite("CreateUserTest")]
        [AllureSuite("Main_Suit")]
        [AllureLink("Rest_Application_Link", "https://localhost:8080/")]
        public void CreateNewUserTest(IUser adminUser)
        {
            logger.Info("Start test CreateNewUSer ");
            adminService = guestService.SuccessfulAdminLogin(adminUser);
            Assert.IsTrue(adminService.IsLogged());
            //
            adminService.CreateUser(simpleUser);
            Assert.IsTrue(adminService.GetAllUsers()
                .Contains(simpleUser));
            logger.Info("End test CreateNewUSer");

        }
    }
}

