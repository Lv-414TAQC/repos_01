using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phones;
using System.Collections.Generic;

namespace UnitTestProject1ov
{ 

    [TestClass]
    public class UnitTest1
    {
        [DynamicData("TestInput")]
        [TestMethod]
        public void TestMethod1(Xiaomi x1, Xiaomi x2, int expectedResult)
        {
           // int expectedResult = 2;
           // x1 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
           // x2 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            Assert.AreEqual(expectedResult, x1 + x2);

        }
        public static IEnumerable<object> TestInput
        {
            get
            {
                return new[]
                {
                    new object[]{
                        new Xiaomi("Mi2lite", 20, "black", 12.5, 1),
                        new Xiaomi("Mi2lite", 20, "black", 12.5, 1),2 }
                };
            }
            
        }
       
        [DynamicData("TestInput1")]
        [TestMethod]
        public void TestMethod2(Xiaomi x1, Xiaomi x2, bool expectedResult)
        {
            // int expectedResult = 2;
            // x1 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            // x2 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            Assert.AreEqual(expectedResult, x1 == x2);

        }
        public static IEnumerable<object> TestInput1
        {
            get
            {
                return new[]

                {
                    new object[]{
                        new Xiaomi("Mi2lite", 20, "black", 12.5, 1),
                        new Xiaomi("Mi2", 20, "black", 10.5, 1), false }
                };
            }

        }
        [DynamicData("TestInput2")]
        [TestMethod]
        public void TestMethod3(Xiaomi x1, Xiaomi x2, bool expectedResult)
        {
            // int expectedResult = 2;
            // x1 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            // x2 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            Assert.AreEqual(expectedResult, x1 > x2);

        }
        public static IEnumerable<object> TestInput2
        {
            get
            {
                return new[]

                {
                    new object[]{
                        new Xiaomi("Mi2lite", 20, "black", 12.5, 1),
                        new Xiaomi("Mi2", 20, "black", 10.5, 1), true}
                };
            }

        }
        [DynamicData("TestInput3")]
        [TestMethod]
        public void TestMethod4(Xiaomi x1, Xiaomi x2, bool expectedResult)
        {
            // int expectedResult = 2;
            // x1 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            // x2 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            Assert.AreEqual(expectedResult, x1 != x2);

        }
        public static IEnumerable<object> TestInput3
        {
            get
            {
                return new[]

                {
                    new object[]{
                        new Xiaomi("Mi2lite", 20, "black", 12.5, 1),
                        new Xiaomi("Mi2", 20, "black", 10.5, 1), true }
                };
            }

        }
        [DynamicData("TestInput4")]
        [TestMethod]
        public void TestMethod5(Xiaomi x1, Xiaomi x2, bool expectedResult)
        {
            // int expectedResult = 2;
            // x1 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            // x2 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            Assert.AreEqual(expectedResult, x1 < x2);

        }
        public static IEnumerable<object> TestInput4
        {
            get
            {
                return new[]

                {
                    new object[]{
                        new Xiaomi("Mi2lite", 20, "black", 12.5, 1),
                        new Xiaomi("Mi2", 20, "black", 10.5, 1), false }
                };
            }

        }
        [DynamicData("TestInput5")]
        [TestMethod]
        public void TestMethod6(Xiaomi x1, Samsung s1, int expectedResult)
        {
            // int expectedResult = 2;
            // x1 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            // x2 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            Assert.AreEqual(expectedResult, x1 + s1);

        }
        public static IEnumerable<object> TestInput5
        {
            get
            {
                return new[]

                {
                    new object[]{
                        new Xiaomi("Mi2lite", 20, "black", 12.5, 1),
                        new Samsung("A30", 20, "red", 12.5, 1), 2 }
                };
            }

        }
        [DynamicData("TestInput6")]
        [TestMethod]
        public void TestMethod7(Samsung s1, Xiaomi x1, int expectedResult)
        {
            // int expectedResult = 2;
            // x1 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            // x2 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            Assert.AreEqual(expectedResult, s1 + x1);

        }
        public static IEnumerable<object> TestInput6
        {
            get
            {
                return new[]

                {
                    new object[]{
                        new Samsung("A30", 20, "red", 12.5, 1),
                        new Xiaomi("Mi2lite", 20, "black", 12.5, 1), 2 }
                };
            }

        }
        [DynamicData("TestInput7")]
        [TestMethod]
        public void TestMethod8(Xiaomi x1, Xiaomi expectedResult)
        {
            // int expectedResult = 2;
            // x1 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            // x2 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
           
            Assert.AreEqual(expectedResult.Number, x1++.Number);

        }
        //Представляє нумератор, який підтримує просту ітерацію по колекції зазначеного типу.
        public static IEnumerable<object> TestInput7
        {
            get
            {
                return new[]

                {
                    new object[]{
                        new Xiaomi("Mi2lite", 20, "black", 12.5, 1),
                        new Xiaomi("Mi2lite", 20, "black", 12.5, 2)}
                };
            }

        }

       
    }
    }
