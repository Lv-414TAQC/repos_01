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
       // IUser oldPassw = UserRepository.Get().OldPasswordForUser();

        private GuestService guestService = new GuestService();
        private UserService userService;

        [TearDown]
        public void TearDown()
        {
            userService.ChangePassw(newPassw,simpleUser);
        }

        [Test]
        public void ChangePasswordd()
        {   
            userService = guestService.SuccessfulUserLogin(simpleUser).ChangePassw(simpleUser, newPassw)
                .Logout().SuccessfulUserLogin(newPassw);
            //
            Assert.IsTrue(userService.IsLoggined());
            //Assert.IsTrue(userService.IsLoggined());
            //
            //userService.Logout();
            ////Assert.IsTrue(!userService.IsLoggined());
            ////
            //userService.SuccessfulUserLogin(newPassw);
            //Assert.IsTrue(userService.IsLoggined());

        }
    }
}
