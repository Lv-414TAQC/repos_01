using NUnit.Framework;
using System;
using System.Threading;
using System.Windows.Forms;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCart414Test
{
    //[TestClass]
    [TestFixture]
    //[Parallelizable(ParallelScope.All)]
    public class UnitTest1
    {
        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            //Console.WriteLine("[OneTimeSetUp] BeforeAllMethods()");
            //MessageBox.Show("[OneTimeSetUp] BeforeAllMethods()", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            //Console.WriteLine("[OneTimeTearDown] AfterAllMethods()");
            //MessageBox.Show("[OneTimeTearDown] AfterAllMethods()", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("[SetUp] SetUp()");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("[TearDown] TearDown()");
        }

        //[TestMethod]
        //[Test]
        public void TestMethod1(
            [Values("Hello", "World")]
            string s,
            [Random(1,10,5)]
            int x)
        {
            Console.WriteLine("Thread is: " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Ok, s=" + s + " x=" + x);
        }

        //[TestCase(5, ExpectedResult = true)]
        //[TestCase(-15, ExpectedResult = false)]
        public bool TestMethod2(int x)
        {
            return x > 0;
        }

        // DataProvider
        private static readonly object[] ConverterData =
        {
            new object[] { 65, 'A' },
            new object[] { 97, 'a' },
            new object[] { 98, 'b' }
        };

        //[TestCase(65, 'A')]
        //[TestCase(97, 'a')]
        //[Test, TestCaseSource(nameof(ConverterData))]
        [Test, TestCaseSource("ConverterData")]
        public void TestMethod3(int x, char c)
        {
            char expexted = c;
            char actual = (char)x;
            //Assert.AreEqual(expexted, actual);
            Assert.IsTrue(expexted == actual);
        }

    }
}
