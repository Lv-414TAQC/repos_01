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
            adminService.Logout();
        }

        [Test]
        public void AddItemTest()
        {
            adminService = guestService.SuccessfulAdminLogin(adminUser);
            adminService.AddItems(ItemsRepository.ListItems());
            CollectionAssert.Contains(ItemsRepository.ListItems(), 
                adminService.GetAllItems());
        }

        [Test]
        public void userAccessItemsTest()
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
