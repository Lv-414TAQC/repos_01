using NUnit.Framework;
using OpenCart414Test.Data;
using OpenCart414Test.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCart414Test.Tests
{
    class ChangePasswordTest : TestRunner
    {
        private static readonly object[] RegistredUser =
       {
            new object[] {
                UserRepository.Get().ValidUserWithBoundaryValues1() }
        };

        [Test, TestCaseSource(nameof(RegistredUser))]

        public void CheckRegistering(IUser user)
        {
            //steps
            AccountPage accountPage = LoadApplication()
                .GotoLoginPage()
                .SuccessLogin(user)
                .ClickRightMenuPassword()
                .ChangePassword("Meow");
            Thread.Sleep(2000);
            //check
          //  Assert.AreEqual(AccountPage.My_Password_UPDATE_Message
            //   , accountPage.GetMessageText());
        }
    }
}
