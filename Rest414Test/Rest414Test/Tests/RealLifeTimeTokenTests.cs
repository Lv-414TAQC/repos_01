using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;
using System;
using System.Threading.Tasks;
using Allure.Commons;
using NLog;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Rest414Test.Tests
{
    [TestFixture]
    class RealLifeTimeTokenTests
    {
        GuestService guestService;
        AdminService adminService;
        Logger logger = LogManager.GetCurrentClassLogger();

        [OneTimeSetUp]
        public void SetUp()
        {
            guestService = new GuestService();
            adminService = guestService.SuccessfulAdminLogin(UserRepository.Get().Admin());
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            adminService = guestService.SuccessfulAdminLogin(UserRepository.Get().Admin());
            adminService.UpdateTokenlifetime(LifetimeRepository.GetDefault());
            adminService.RemoveUser(UserRepository.Get().TestUser());
        }

        [Test]
        public async Task CheckRealTokenLIfeTime()
        {
            logger.Info("CheckRealTokenLIfeTime test started");
            await Task.Factory.StartNew(async () =>
            {
                Lifetime newLifeTime = LifetimeRepository.GetTestRealTokenLifeTime();
                adminService.UpdateTokenlifetime(newLifeTime);
                adminService.CreateUser(UserRepository.Get().TestUser());
                UserService testUser = guestService.SuccessfulUserLogin(UserRepository.Get().TestUser());
                string userToken = testUser.GetToken();
                logger.Info("userToken : {0}", userToken);
                await Task.Delay(9500);
                string aliveTokensBeforeTimeEnd = adminService.GetAliveTokens();
                logger.Info("aliveTokensBeforeTimeEnd : {0}", aliveTokensBeforeTimeEnd);
                adminService = guestService.SuccessfulAdminLogin(UserRepository.Get().Admin());
                await Task.Delay(1000);
                string aliveTokensAfterTimeEnd = adminService.GetAliveTokens();
                logger.Info("aliveTokensAfterTimeEnd : {0}", aliveTokensAfterTimeEnd);
                Assert.IsTrue(aliveTokensBeforeTimeEnd.Contains(userToken));
                Assert.IsFalse(aliveTokensAfterTimeEnd.Contains(userToken));
            }).Unwrap();
            logger.Info("CheckRealTokenLIfeTime test done");
        }
 
    }
}
