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
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static readonly object[] UsersCsv =
            ListUtils.ToMultiArray(UserRepository.Get().FromCsv());

        GuestService guestService = new GuestService();
        IUser adminUser = UserRepository.Get().Admin();
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
            adminService.ResetSystem();
        }

        [Test, TestCaseSource("UsersCsv")]
        [AllureTag("Regression_Tag")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ATQCNET-53")]
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
            adminService = guestService.SuccessfulAdminLogin(adminUser);
            adminService.AddItems(ItemsRepository.ListItems());
            Assert.IsTrue(adminService.IsLogged());
            adminService.Logout();
            userService = guestService.SuccessfulUserLogin(user);
            Assert.IsTrue(userService.IsLogged());
            Assert.IsEmpty(userService.GetAllItems());
            logger.Info("End UserAccessItemsTest");
        }

        [Test]
        public void AdminAccessItemsTest()
        {
            logger.Info("Start AdminAccessItemsTest");
            userService = guestService.SuccessfulUserLogin(user);
            userService.AddItems(ItemsRepository.UserListItems());
            Assert.IsTrue(userService.IsLogged());
            userService.Logout();
            adminService = guestService.SuccessfulAdminLogin(adminUser);
            Assert.IsTrue(adminService.IsLogged());
            Assert.IsEmpty(adminService.GetAllItems());
            logger.Info("End AdminAccessItemsTest");
        }

        [Test]
        public void UpdateItemTest()
        {
            logger.Info("Start UpdateItemTest");
            adminService = guestService.SuccessfulAdminLogin(adminUser);
            adminService.AddItems(ItemsRepository.ListItems());
            adminService.UpdateItem(existItem, updatedItem);
            adminService.GetAllItems();
            Assert.IsTrue(adminService.IsUpdateItem(updatedItem, adminService.GetAllItems()));
            logger.Info("End UpdateItemTest");
        }
    }
}
