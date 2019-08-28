using Allure.Commons;
using NLog;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;
using Rest414Test.Tools;

namespace Rest414Test.Tests
{
    [AllureNUnit]
    [AllureDisplayIgnored]
    [TestFixture]
    public class ItemTest
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private static readonly object[] UsersCsv =
            ListUtils.ToMultiArray(UserRepository.Get().FromCsv());

        IUser adminUser = UserRepository.Get().Admin();
        GuestService guestService = new GuestService();
        AdminService adminService;

        UserService userService;
        IUser user = UserRepository.Get().ExistUser();

        ItemTemplate existItem = ItemRepository.GetFirst();
        ItemTemplate updatedItem = ItemRepository.UpdateItem();

        [TearDown]
        public void TearDown()
        {
            if (adminService.IsLogged())
            {
                adminService.Logout();
            }
            else userService.Logout();
        }

        [Test, TestCaseSource("UsersCsv")]
        [AllureTag("Regression_Tag")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-53")]
        [AllureTms("TMS-12")]
        [AllureOwner("User_Owner")]
        [AllureParentSuite("With_parameters_ParentSuite")]
        [AllureSuite("Passed_Suite")]
        [AllureSubSuite("NoAssert_SubSuite")]
        [AllureEpic("Retry_Epic")]
        [AllureFeature("RetrySmall_Feature")]
        [AllureLink("Rest_Application_Link", "https://localhost:8181/")]
        public void AddItemTest(IUser admin)
        {
            logger.Info("Start AddItemTest");
            adminService = guestService.SuccessfulAdminLogin(admin);
            adminService.AddItems(ItemsRepository.ListItems());
            Assert.AreEqual(ItemsRepository.ListItems().Count, 
                adminService.GetAllItems().Count);
            logger.Info("End AddItemTest");
        }

        [Test]
        public void UserAccessItemsTest()
        {
            logger.Info("Start UserAccessItemsTest");
            userService = guestService.SuccessfulUserLogin(user);
            Assert.IsTrue(userService.IsLogged());
            Assert.IsEmpty(userService.GetAllItems());
            logger.Info("End UserAccessItemsTest");
        }

        [Test]
        public void UpdateItemTest()
        {
            logger.Info("Start UpdateItemTest");
            adminService = guestService.SuccessfulAdminLogin(adminUser);
            adminService.UpdateItem(existItem, updatedItem);
            Assert.IsTrue(adminService.IsUpdateItem(updatedItem, adminService.GetAllItems()));
            logger.Info("End UpdateItemTest");
        }
    }
}
