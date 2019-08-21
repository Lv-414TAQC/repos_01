using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest414Test.Tests
{
    [TestFixture]
    class ChangeCoolDownTimeTest
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

        }
                
           
    }
}
