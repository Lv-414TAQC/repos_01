using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;

namespace Rest414Test.Tests
{
    [TestFixture]
    class DeleteUser
    {
        private GuestService guestService = new GuestService();
        private AdminService adminService;

        IUser adminUser = UserRepository.Get().Admin();

        // DataProvider
        private static readonly object[] NewUser =
        {
            new object[]{UserRepository.Get().CreateNewUser()}
        };

        [Test, TestCaseSource("NewUser")]
        public void DeleteeUser(IUser user)
        {
            guestService.logger.Info("Start test DeleteeUser ");
            adminService = guestService.SuccessfulAdminLogin(adminUser);
            Assert.IsTrue(adminService.IsLogged());
            //
            adminService.CreateUser(user);
            Assert.IsTrue(adminService.GetAllUsers().Contains(new User(user.Name)));
            //
            adminService.RemoveUser(user);
            Assert.IsTrue(!adminService.GetAllUsers().Contains(new User(user.Name)));
            guestService.logger.Info("End test DeleteeUser");

        }

    }
}
