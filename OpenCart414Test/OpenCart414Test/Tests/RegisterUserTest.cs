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
        private static readonly object[] RegUser =
        {
            new object[] {
                UnloggedMyAccount.REGISTER,
                },
        };

        //[Test, TestCaseSource(nameof(RegUser))]
        [Test]
        public void CheckRegistering()
        {
            HomePage homePage = LoadApplication();
            homePage.GotoRegisterPage().InitElements("Woof","Boof","Lul@gmail.com","30443244","CoolStreet","CoolCity",
                "322","Ukraine","Kyiv","wooow","wooow");
            Thread.Sleep(5000);

        }
    }
}
