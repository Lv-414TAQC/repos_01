using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest414Test.Tests
{
        //cycle in method
    [TestFixture]
    class CoolDownTimeTest
    {
        AdminService adminService;
        IUser adminForTest;
        [Test]
        public void TestMethod1()
        {
            IUser adminUser = UserRepository.Get().Admin();
            GuestService guestService = new GuestService();
            adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            CoolDownTime currentCoolDownime = CoolDownTimeRepository.GetDefault();
            Console.WriteLine(currentCoolDownime.Time);
            Assert.IsTrue(currentCoolDownime.Time.Equals(adminService.GetCoolDownTime()));
            adminService.UpdateCoolDowntime(CoolDownTimeRepository.NewCoolDown());
            currentCoolDownime = CoolDownTimeRepository.NewCoolDown();
            Console.WriteLine(currentCoolDownime.Time);
            Assert.IsTrue(currentCoolDownime.Time.Equals(adminService.GetCoolDownTime()));

        }
    }
}
