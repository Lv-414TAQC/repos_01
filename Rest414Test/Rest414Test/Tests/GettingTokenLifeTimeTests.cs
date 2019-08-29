using NLog;
using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;
using System;

namespace Rest414Test.Tests
{
    [TestFixture]
    class GettingTokenLifeTimeTests
    {
        GuestService guestService;
        AdminService adminService;
        Logger logger = LogManager.GetCurrentClassLogger();

        private static readonly object[] TokenLifeTimes =
        {
            new object[] { LifetimeRepository.GetLongTime() }
        };

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            guestService = new GuestService();
        }

        [SetUp]
        public void SetUp()
        {
            adminService = guestService.SuccessfulAdminLogin(UserRepository.Get().Admin());
        }

        [Test]
        public void CheckDefaultTokenLifeTimeIsPositiveNumber()
        {
            logger.Info("CheckDefaultTokenLifeTimeIsPositiveNumber test started");
            Lifetime lifetime = guestService.GetCurrentTokenLifetime();
            int tokenLifeTimeValue;
            bool actualResult = Int32.TryParse(lifetime.Time, out tokenLifeTimeValue);
            logger.Info("   actualResult : {0}", actualResult);
            logger.Info("   tokenLifeTimeValue : {0}", tokenLifeTimeValue);
            Assert.IsTrue(actualResult);
            Assert.IsTrue(tokenLifeTimeValue > 0);
            logger.Info("CheckDefaultTokenLifeTimeIsPositiveNumber test started");
        }

        [Test]
        public void CheckGettingActualTokenLifeTime()
        {
            logger.Info("CheckGettingActualTokenLifeTime test started");
            adminService.UpdateTokenlifetime(LifetimeRepository.GetLongTime());
            Lifetime lifetime = guestService.GetCurrentTokenLifetime();
            logger.Info("   actuallifetime : {0}", lifetime);
            logger.Info("   expectedlifetime : {0}", LifetimeRepository.GetLongTime());
            Assert.AreEqual(LifetimeRepository.GetLongTime().Time, lifetime.Time);
            logger.Info("CheckGettingActualTokenLifeTime test started");
        }
    }
}
