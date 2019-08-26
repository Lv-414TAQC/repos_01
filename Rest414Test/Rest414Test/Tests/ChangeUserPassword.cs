using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;

namespace Rest414Test.Tests
{
    [TestFixture]
    class ChangeUserPassword
    {
        IUser simpleUser = UserRepository.Get().ExistUser();
        IUser newPassw = UserRepository.Get().NewPasswordForUser();
        IUser oldPassw = UserRepository.Get().OldPasswordForUser();

        private GuestService guestService = new GuestService();
        private UserService userService;

        [TearDown]
        public void TearDown()
        {
            userService.ChangePassw(simpleUser, oldPassw);
        }

        [Test]
        public void ChangePasswordd()
        {
            userService = guestService.SuccessfulUserLogin(simpleUser).ChangePassw(simpleUser, newPassw);
            Assert.AreEqual(simpleUser.Password, newPassw.Password);
            //
            userService.Logout();
            Assert.IsTrue(!userService.IsLogged());
            //
            userService.SuccessfulUserLogin(simpleUser);
            Assert.IsTrue(userService.IsLogged());

        }
    }
}
