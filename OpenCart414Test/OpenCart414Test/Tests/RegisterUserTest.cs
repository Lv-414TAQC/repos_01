using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenCart414Test.Data;
using OpenCart414Test.Pages;

namespace OpenCart414Test.Tests
{
    [TestFixture]
    class RegisterUserTest : TestRunner
    {
        // DataProvider
        private static readonly object[] RegistredUser =
        {
            new object[] {
                UserRepository.Get().ValidUserWithBoundaryValues1() }
        };

        [Test, TestCaseSource(nameof(RegistredUser))]

        public void CheckRegistering(IUser user)
        {
            SuccessfullyRegisterPage SucRegPage = LoadApplication().GotoRegisterPage().successfullyRegisterUser(user);
            // Check
            Assert.IsTrue(SucRegPage.GetExpectedSuccessMessage().Equals(SucRegPage.Expected_Success_Message));

            //Step
            AccountLogoutPage accountLogoutPage = SucRegPage.LogOut();

            //Check
         //  Assert.IsTrue(accountLogoutPage.GetActualAccountLogoutMessage()  TODO
            //        .equals(accountLogoutPage.Expected_Account_Message));
            //  DataBaseUtils db = new DataBaseUtils();

            Thread.Sleep(5000);

        }
    }
}
