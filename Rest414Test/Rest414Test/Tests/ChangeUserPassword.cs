using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;
using System;

namespace Rest414Test.Tests
{
    [TestFixture]
    class ChangeUserPassword
    {
        IUser simpleUser = UserRepository.Get().ExistUser();
        IUser newPassw = UserRepository.Get().NewPasswordForUser();

        private GuestService guestService = new GuestService();
        private UserService userService;

        [TearDown]
        public void TearDown()
        {
            //userService.ChangePassw(newPassw,simpleUser);
            userService.ResetSystem();
        }

        [Test]
        public void ChangePassworddTest()
        {
            guestService.logger.Info("Start test ChangePasswordd ");
            userService = guestService.SuccessfulUserLogin(simpleUser).ChangePassw(simpleUser, newPassw)
                .Logout().SuccessfulUserLogin(newPassw);
            //
            Assert.IsTrue(userService.IsLogged());
            guestService.logger.Info("End test ChangePasswordd");
        }
    }
}
