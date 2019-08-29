using NUnit.Framework;
using NUnit.Framework.Interfaces;
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
            Lifetime lifetime = guestService.GetCurrentTokenLifetime();
            int tokenLifeTimeValue;
            bool actualResult = Int32.TryParse(lifetime.Time, out tokenLifeTimeValue);
            Assert.IsTrue(actualResult);
            Assert.IsTrue(tokenLifeTimeValue > 0);
        }

        [Test]
        public void CheckGettingActualTokenLifeTime()
        {
            adminService.UpdateTokenlifetime(LifetimeRepository.GetLongTime());
            Lifetime lifetime = guestService.GetCurrentTokenLifetime();
            Assert.AreEqual(LifetimeRepository.GetLongTime().Time, lifetime.Time);
        }
    }
}
