using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;

namespace Rest414Test.Tests
{
    [TestFixture]
    class CreateUser
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        //
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
        public void CreateNewUser()
        {
            adminService = guestService.SuccessfulAdminLogin(adminUser);
            logger.Info("Start test CheckLoginUser ");
            Assert.IsTrue(adminService.IsLoggined());
            //
            adminService.CreateUser(simpleUser);
            Assert.IsTrue(adminService.GetAllUsers().Contains(new User(simpleUser.Name)));

        }
    }
}

