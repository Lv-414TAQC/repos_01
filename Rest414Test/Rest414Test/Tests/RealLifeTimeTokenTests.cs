using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Rest414Test.Data;
using Rest414Test.Services;
using Rest414Test.Tools;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Rest414Test.Tests
{
    [TestFixture]
    class RealLifeTimeTokenTests
    {
        GuestService guestService;
        AdminService adminService;

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
            await Task.Factory.StartNew(async () =>
            {
                Lifetime newLifeTime = LifetimeRepository.GetTestRealTokenLifeTime();
            adminService.UpdateTokenlifetime(newLifeTime);
            adminService.CreateUser(UserRepository.Get().TestUser());
            UserService testUser = guestService.SuccessfulUserLogin(UserRepository.Get().TestUser());
            string userToken = testUser.GetToken();
            
            long newLifeTimevalue = Int64.Parse(newLifeTime.Time);
            await Task.Delay(9000);
            string aliveTokensBeforeTimeEnd = adminService.GetAliveTokens();
                Console.WriteLine(aliveTokensBeforeTimeEnd);
            adminService = guestService.SuccessfulAdminLogin(UserRepository.Get().Admin());
            await Task.Delay(1400);
            string aliveTokensAfterTimeEnd = adminService.GetAliveTokens();
                Console.WriteLine(aliveTokensAfterTimeEnd);
            Assert.IsTrue(aliveTokensBeforeTimeEnd.Contains(userToken));
            Assert.IsFalse(aliveTokensAfterTimeEnd.Contains(userToken));
            }).Unwrap();
        }
 
    }
}
