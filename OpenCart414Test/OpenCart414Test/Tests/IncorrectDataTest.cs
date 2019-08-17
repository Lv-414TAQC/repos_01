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
    class IncorrectDataTest : TestRunner
    {
        // DataProvider
        private static readonly object[] InvalidDataUser =
        {
            new object[] {
                UserRepository.Get().InvalidUserWithBoundaryValues2() }
        };

        [Test, TestCaseSource(nameof(InvalidDataUser))]

        public void CheckInvalidRegister(IUser user)
        {
            UnsuccessfullyRegisterPage unsuccessfullypage  = LoadApplication()
                .GotoRegisterPage().
                UserWithWrongData(user);

            //Check
            Assert.AreEqual(UnsuccessfullyRegisterPage.Expected_Warning_First_Name, unsuccessfullypage.GetActualFirstNameError());
            Assert.AreEqual(UnsuccessfullyRegisterPage.Expected_Warning_Last_Name, unsuccessfullypage.GetActualLastNameError());
            Assert.AreEqual(UnsuccessfullyRegisterPage.Expected_Warning_Email, unsuccessfullypage.GetActualEmailError());
            Assert.AreEqual(UnsuccessfullyRegisterPage.Expected_Warning_Telephone, unsuccessfullypage.GetActualTelephoneError());
            Assert.AreEqual(UnsuccessfullyRegisterPage.Expected_Warning_Address1, unsuccessfullypage.GetActualAddressError());
            Assert.AreEqual(UnsuccessfullyRegisterPage.Expected_Warning_City, unsuccessfullypage.GetActualCityError());
            Assert.AreEqual(UnsuccessfullyRegisterPage.Expected_Warning_Region, unsuccessfullypage.GetActualRegionError());
            Assert.AreEqual(UnsuccessfullyRegisterPage.Expected_Warning_Password, unsuccessfullypage.GetActualPasswordError());

            Thread.Sleep(5000);

        }
    }
}
