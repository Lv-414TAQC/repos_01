using NLog;
using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;

namespace Rest414Test.Tests
{
    [TestFixture]
    class CreateUser
    {        
        private GuestService guestService = new GuestService();
        private AdminService adminService;

        IUser adminUser = UserRepository.Get().Admin();
        IUser simpleUser = UserRepository.Get().CreateNewUser();

        [TearDown]
        public void TearDown()
        {
            adminService.RemoveUser(simpleUser);
        }

        [Test]
        public void CreateNewUserTest()
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

