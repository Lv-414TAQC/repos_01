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
    class DeleteUser
    {
        public Logger logger = LogManager.GetCurrentClassLogger();
        private GuestService guestService = new GuestService();
        private AdminService adminService;

        IUser adminUser = UserRepository.Get().Admin();

        // DataProvider
        private static readonly object[] NewUser =
        {
            new object[]{UserRepository.Get().CreateNewUser()}
        };

        [Test, TestCaseSource("NewUser")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-215")]
        [AllureOwner("DomashovetsDmytro")]
        [AllureParentSuite("DeleteUserTest")]
        [AllureSuite("Main_Suit")]
        [AllureLink("Rest_Application_Link", "https://localhost:8080/")]
        public void DeleteeUser(IUser user)
        {
            logger.Info("Start test DeleteeUser ");
            adminService = guestService.SuccessfulAdminLogin(adminUser);
            Assert.IsTrue(adminService.IsLogged());
            //
            adminService.CreateUser(user);
            Assert.IsTrue(adminService.GetAllUsers().Contains(user));
            //
            adminService.RemoveUser(user);
            Assert.IsTrue(!adminService.GetAllUsers().Contains(user));
            logger.Info("End test DeleteeUser");

        }

    }
}
