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
        List<ItemTemplate> existItems = ItemsRepository.ListItems();
        AdminService adminService;

        UserService userService;
        IUser user = UserRepository.Get().ExistUser();

        ItemTemplate existItem = ItemRepository.GetFirst();
        ItemTemplate updatedItem = ItemRepository.UpdateItem();

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void ItemTestOne()
        {
            adminService = guestService.SuccessfulAdminLogin(adminUser);
            adminService.AddItems(existItems);
            Assert.AreEqual(existItems.Count, adminService.GetAllItems().Count);
        }

        [Test]
        public void ItemTestTwo()
        {
            userService = guestService.SuccessfulUserLogin(user);
            Assert.IsTrue(userService.IsLoggined());
            Assert.IsEmpty(userService.GetAllItems());
        }

        [Test]
        public void ItemTestThree()
        {
            adminService = guestService.SuccessfulAdminLogin(adminUser);
            adminService.UpdateItem(existItem, updatedItem);
            //adminService.GetAllItems();
            Assert.IsTrue(adminService.IsUpdateItem(updatedItem, adminService.GetAllItems()));

        }

    }
}
