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
    class ChangeUserPasswordTest
    {
        public Logger logger = LogManager.GetCurrentClassLogger();
        IUser simpleUser = UserRepository.Get().ExistUser();
        IUser newPassw = UserRepository.Get().NewPasswordForUser();

        private GuestService guestService = new GuestService();
        private UserService userService;

        [TearDown]
        public void TearDown()
        {
            userService.ResetSystem();
        }

        [Test]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-216")]
        [AllureOwner("DomashovetsDmytro")]
        [AllureParentSuite("ChangeUserPasswordTest")]
        [AllureSuite("Main_Suit")]
        [AllureLink("Rest_Application_Link", "https://localhost:8080/")]
        public void ChangePassworddTest()
        {
            logger.Info("Start test ChangePasswordd ");
            userService = guestService
                .SuccessfulUserLogin(simpleUser)
                .ChangePassw(simpleUser, newPassw)
                .Logout()
                .SuccessfulUserLogin(newPassw);
            //
            Assert.IsTrue(userService.IsLogged());
            logger.Info("End test ChangePasswordd");
        }
    }
}
