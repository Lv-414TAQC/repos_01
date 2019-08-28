using NLog;
using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;
using Rest414Test.Tools;
using System;

namespace Rest414Test.Tests
{
    [TestFixture]
    class CreateUser
    {        
        private GuestService guestService = new GuestService();
        private AdminService adminService;

        IUser simpleUser = UserRepository.Get().CreateNewUser();

        private static readonly object[] UsersCsv =
            ListUtils.ToMultiArray(UserRepository.Get().FromCsv());

        [TearDown]
        public void TearDown()
        {
            adminService.RemoveUser(simpleUser);
        }

        [Test, TestCaseSource("UsersCsv")]
        public void CreateNewUserTest(IUser adminUser)
        {
            guestService.logger.Info("Start test CreateNewUSer ");
            adminService = guestService.SuccessfulAdminLogin(adminUser);
            Assert.IsTrue(adminService.IsLogged());
            //
            adminService.CreateUser(simpleUser);
            Assert.IsTrue(adminService.GetAllUsers().Contains(new User(simpleUser.Name)));
            guestService.logger.Info("End test CreateNewUSer");

        }
    }
}

