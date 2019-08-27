using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Rest414Test.Data;
using Rest414Test.Services;
using System;

namespace Rest414Test.Tests
{
    [TestFixture]
    class RealLifeTimeTokenTests
    {
        GuestService guestService;
        AdminService adminService;
        bool isTokenAlive;

        [OneTimeSetUp]
        public void SetUp()
        {
            guestService = new GuestService();
            adminService = guestService.SuccessfulAdminLogin(UserRepository.Get().Admin());
        }

        [Test]
        public void CheckRealTokenLIfeTime()
        {
            Lifetime newLifeTime = LifetimeRepository.GetTestRealTokenLifeTime();
            adminService.UpdateTokenlifetime(newLifeTime);
            UserService testUser =  adminService.CreateUser(UserRepository.Get().CreateNewUser());
            testUser.SuccessfulUserLogin(UserRepository.Get().CreateNewUser());
            string userToken = testUser.GetToken();

            Console.WriteLine(userToken);

            double newLifeTimevalue = Double.Parse(newLifeTime.Time);


            //Thread.Sleep(lifeTime - 200);
            //string aliveTokensBeforeLifeTimeEnd = Tools.GetAliveTokens(url, adminToken);
            //Thread.Sleep(400);
            //adminToken = Tools.LogInAdmin(url);
            //string aliveTokensAfterLifeTimeEnd = Tools.GetAliveTokens(url, adminToken);
            //Console.WriteLine(aliveTokensBeforeLifeTimeEnd);
            //bool actualresult = aliveTokensBeforeLifeTimeEnd.Contains(userToken);
            //Assert.IsTrue(actualresult);
            //actualresult = aliveTokensAfterLifeTimeEnd.Contains(userToken);
            //Console.WriteLine(aliveTokensAfterLifeTimeEnd);
            //Assert.IsFalse(actualresult);
        }
    }
}
