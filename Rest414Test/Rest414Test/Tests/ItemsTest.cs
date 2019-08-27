using NLog;
using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;
using System;
using System.Collections.Generic;

namespace Rest414Test.Tests
{
    [TestFixture]
    public class ItemTest
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

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

        [Test]
        public void AddItemTest()
        {
            logger.Info("Start AddItemTest");
            adminService = guestService.SuccessfulAdminLogin(adminUser);
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
