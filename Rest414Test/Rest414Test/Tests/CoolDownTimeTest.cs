using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;
using System;

namespace Rest414Test.Tests
{
        
    [TestFixture]
    class CoolDownTimeTest
    {
        AdminService adminService;
        
        
        IUser UserForLock = UserRepository.Get().UserForLock();
        IUser IncorrectUserForLock = UserRepository.Get().IncorrectUserForLock();
[Test]
        public void TestMethod1()
        {
            IUser adminUser = UserRepository.Get().Admin();
            GuestService guestService = new GuestService();
            adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            CoolDownTime currentCoolDownime = CoolDownTimeRepository.GetDefault();
            Console.WriteLine(currentCoolDownime.Time);
            string s = adminService.GetCoolDownTime();
            Assert.IsTrue(currentCoolDownime.Time.Equals(s));
            currentCoolDownime = CoolDownTimeRepository.NewCoolDown();
            adminService.UpdateCoolDowntime(currentCoolDownime);
            Console.WriteLine(currentCoolDownime.Time);
            Assert.IsTrue(currentCoolDownime.Time.Equals(adminService.GetCoolDownTime()));
            currentCoolDownime = CoolDownTimeRepository.GetDefault();
            adminService.Logout();
        }
        [Test]
        public void TestMethod2()
        {
            IUser adminUser = UserRepository.Get().Admin();
            GuestService guestService = new GuestService();
            adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            //UserForLock = UserRepository.Get().CreateNewUser();
            adminService.CreateUser(UserForLock);
            
            Assert.IsTrue(adminService.GetAllUsers().Contains(new User(UserForLock.Name)));
            adminService.Logout();
            guestService = guestService.LockingUser(IncorrectUserForLock);
            adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            adminService.GetLockedUsers();
            Assert.IsTrue(adminService.GetLockedUsers().Contains(new User(UserForLock.Name)));
            adminService.Logout();
        }

        [Test]
        public void TestMethod3()
        {
            IUser adminUser = UserRepository.Get().Admin();
            GuestService guestService = new GuestService();
            adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            adminService.UnlockUser(UserForLock);
            Assert.IsFalse(adminService.GetLockedUsers().Contains(new User(UserForLock.Name)));
            adminService.Logout();
        }
    }
}
