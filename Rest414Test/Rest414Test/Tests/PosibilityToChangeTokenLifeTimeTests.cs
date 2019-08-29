using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Rest414Test.Data;
using Rest414Test.Services;
using System;

namespace Rest414Test.Tests
{
    [TestFixture]
    public class PosibilityToChangeTokenLifeTimeTests
    {
        GuestService guestService;
        AdminService adminService;
        Logger logger = LogManager.GetCurrentClassLogger();

        private static readonly object[] TokenLifeTimes =
        {
            new object[] { LifetimeRepository.GetLongTime() }
        };

        private static readonly object[] IncorrectTokenLifeTimes =
        {
            new object[] { LifetimeRepository.GetLifeTimeWithLetters() },
            new object[] { LifetimeRepository.GetLifeTimeWithSymbols() },
            new object[] { LifetimeRepository.GetNegetiveLifeTime()},
            new object[] { LifetimeRepository.GetZeroLifeTime()}
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

        [TearDown]
        public void TearDown()
        {
            if ((adminService != null) && (adminService.IsLogged()))
            {
                Lifetime currentTokenlifetime = LifetimeRepository.GetDefault();
                adminService = adminService.UpdateTokenlifetime(currentTokenlifetime);
            }
            if ((adminService != null) && (adminService.IsLogged()))
            {
                guestService = adminService.Logout();
                adminService = null;
            }
            guestService.ResetSystem();

        }

        [Test, TestCaseSource("TokenLifeTimes")]
        public void CheckPosibilityToChangeTokenLifeTimeWithInvalidAdminToken(Lifetime newTokenlifetime)
        {
            logger.Info("CheckPosibilityToChangeTokenLifeTimeWithInvalidAdminToken test started");
            UserService fakeAdmin = new UserService(UserRepository.Get().FakeAdmin());
            guestService.TryUpdateTokenlifetime(newTokenlifetime, fakeAdmin);
            Lifetime currentTokenlifetime = adminService.GetCurrentTokenLifetime();
            logger.Info("   try to change token life time to : {0}", newTokenlifetime);
            logger.Info("   actual token lifetime : {0}", currentTokenlifetime);
            Assert.AreNotEqual(LifetimeRepository.LongTokenLifetime, currentTokenlifetime.Time);
            logger.Info("CheckPosibilityToChangeTokenLifeTimeWithInvalidAdminToken test done");
        }

        [Test, TestCaseSource("TokenLifeTimes")]
        public void CheckPosibilityToChangeTokenLifeTimeToCorrentValue(Lifetime newTokenlifetime)
        {
            logger.Info("CheckPosibilityToChangeTokenLifeTimeToCorrentValue test started");
            adminService = adminService.UpdateTokenlifetime(newTokenlifetime);
            Lifetime currentTokenlifetime = adminService.GetCurrentTokenLifetime();
            logger.Info("   expected token lifeTime : {0}", newTokenlifetime);
            logger.Info("   actual token lifeTime : {0}", currentTokenlifetime);
            Assert.AreEqual(LifetimeRepository.LongTokenLifetime, currentTokenlifetime.Time);
            logger.Info("CheckPosibilityToChangeTokenLifeTimeToCorrentValue test started");
        }

        [Test, TestCaseSource("IncorrectTokenLifeTimes")]
        public void CheckPosibilityToChangeTokenLifeTimeToIncorrentValue(Lifetime newTokenLifeTime)
        {
            logger.Info("CheckPosibilityToChangeTokenLifeTimeToIncorrentValue test started");
            Lifetime currentTokenlifetimeBeforeChange = adminService.GetCurrentTokenLifetime();
            logger.Info("   currentTokenlifetimeBeforeChange.Time = ", currentTokenlifetimeBeforeChange.Time);
            adminService = adminService.UpdateTokenlifetime(newTokenLifeTime);
            Lifetime currentTokenlifetimeAfterChange = adminService.GetCurrentTokenLifetime();
            logger.Info("   currentTokenlifetimeAfterChange.Time = ", currentTokenlifetimeAfterChange.Time);
            Assert.AreEqual(currentTokenlifetimeBeforeChange.Time, currentTokenlifetimeAfterChange.Time);
            Assert.AreNotEqual(currentTokenlifetimeAfterChange.Time, newTokenLifeTime.Time);
            logger.Info("CheckPosibilityToChangeTokenLifeTimeToIncorrentValue test done");
        }
    }
}


