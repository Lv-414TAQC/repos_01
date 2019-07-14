using NUnit.Framework;
using Phones;
using System;
namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Start");
        }
        
        
        [Test]
        public void Test1()
        {
            int expectedResult = 2;
            Xiaomi x1 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            Xiaomi x2 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);

            Assert.AreEqual(expectedResult,x1+x2);
        }
        [Test]
        public void Test2()
        {
            bool expectedResult = false;
            Xiaomi x1 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            Xiaomi x2 = new Xiaomi("Mi2", 20, "black", 10.5, 1);

            Assert.AreEqual(expectedResult, x1 == x2);
        }
        [Test]
        public void Test3()
        {
            bool expectedResult = true;
            Xiaomi x1 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            Xiaomi x2 = new Xiaomi("Mi2", 20, "black", 10.5, 1);

            Assert.AreEqual(expectedResult, x1 > x2);
        }
        [Test]
        public void Test4()
        {
            bool expectedResult = true;
            Xiaomi x1 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            Xiaomi x2 = new Xiaomi("Mi2", 20, "black", 10.5, 1);

            Assert.AreEqual(expectedResult, x1 != x2);
        }
        [Test]
        public void Test5()
        {
            bool expectedResult = false;
            Xiaomi x1 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            Xiaomi x2 = new Xiaomi("Mi2", 20, "black", 10.5, 1);

            Assert.AreEqual(expectedResult, x1 < x2);
        }
        [Test]
        public void Test6()
        {
            int expectedResult = 2;
            Xiaomi x1 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            Samsung s1 = new Samsung("A30", 20, "red", 12.5, 1);

            Assert.AreEqual(expectedResult, s1 + x1);
        }
        [Test]
        public void Test7()
        {
            int expectedResult = 2;
            Xiaomi x1 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            Samsung s1 = new Samsung("A30", 20, "red", 12.5, 1);

            Assert.AreEqual(expectedResult, x1 + s1);
        }
        [Test]
        public void Test8()
        {
            Xiaomi expectedResult = new Xiaomi("Mi2lite", 20, "black", 12.5, 2);
            Xiaomi x1 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            

            Assert.AreEqual(expectedResult.Number, x1++.Number);
        }
        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("End");
        }

    }
}