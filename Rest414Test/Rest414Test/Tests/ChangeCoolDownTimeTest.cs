using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;

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
