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
    [TestFixture]
    public class SecondTest
    {
        //[Test]
        public void ExamineAddItem()
        {
            IUser adminUser = UserRepository.Get().Admin();
            //
            GuestService guestService = new GuestService();
            AdminService adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            ItemTemplate existItem = ItemRepository.GetFirst();
            //
            adminService.AddItem(existItem);
            //
            ItemTemplate itemResult = adminService.GetUserItem(existItem, adminUser);
            Assert.AreEqual(existItem.Item, itemResult.Item);
        }

        //[Test]
        public void ExamineAddUserItem()
        {
            IUser adminUser = UserRepository.Get().Admin();
            ItemTemplate existAdminItem = ItemRepository.GetFirst();
            //
            IUser simpleUser = UserRepository.Get().ExistUser();
            ItemTemplate existUserItem = ItemRepository.GetSecond();
            //
            GuestService guestService = new GuestService();
            AdminService adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            //Console.WriteLine("adminUser Token = " + adminUser.Token);
            UserService userService = guestService
                .SuccessfulUserLogin(simpleUser);
            //Console.WriteLine("simpleUser Token = " + simpleUser.Token);
            //
            userService.AddItem(existAdminItem);
            userService.AddItem(existUserItem);
            //
            ItemTemplate itemResult = adminService.GetUserItem(existAdminItem, simpleUser);
            // TODO DEvelop Equals from Item
            Assert.AreEqual(existAdminItem.Item, itemResult.Item);
            //
            itemResult = adminService.GetUserItem(existUserItem, simpleUser);
            // TODO DEvelop Equals from Item
            Assert.AreEqual(existUserItem.Item, itemResult.Item);
        }

    }
}
