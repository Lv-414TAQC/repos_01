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
        Logger logger = LogManager.GetCurrentClassLogger();

        IUser adminUser = UserRepository.Get().Admin();
        GuestService guestService = new GuestService();
        AdminService adminService;

        UserService userService;
        IUser user = UserRepository.Get().ExistUser();

        ItemTemplate existItem = ItemRepository.GetFirst();
        ItemTemplate updatedItem = ItemRepository.UpdateItem();

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            userService.Logout();
        }

        [Test]
        public void AddItemTest()
        {
            logger.Info("Start AddItemTest");
            adminService = guestService.SuccessfulAdminLogin(adminUser);
            adminService.AddItems(ItemsRepository.ListItems());
            Assert.AreEqual(ItemsRepository.ListItems().Count, 
                adminService.GetAllItems().Count);
        }

        [Test]
        public void UserAccessItemsTest()
        {
            userService = guestService.SuccessfulUserLogin(user);
            Assert.IsTrue(userService.IsLoggined());
            Assert.IsEmpty(userService.GetAllItems());
        }

        [Test]
        public void UpdateItemTest()
        {
            adminService = guestService.SuccessfulAdminLogin(adminUser);
            adminService.UpdateItem(existItem, updatedItem);
            Assert.IsTrue(adminService.IsUpdateItem(updatedItem, adminService.GetAllItems()));
        }
    }
}
