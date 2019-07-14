using NUnit.Framework;

namespace Tests
{   
    [TestFixture]
    public class DelegatesHWTests
    {
        [TestCase(10, 45, 26, 73, 34, 11, ExpectedResult = 70)]
        public int SumEvens(params int[] x)
        {
            return delegates_hw.MathClass.Sum_(delegates_hw.MathClass.Evens, x);
        }

        [TestCase(10, 45, 26, 73, 34, 11, ExpectedResult = 129)]
        public int SumOdds(params int[] x)
        {
            return delegates_hw.MathClass.Sum_(delegates_hw.MathClass.Odds, x);
        }

        [TestCase(10, 45, 26, 73, 34, 11, ExpectedResult = 34)]
        public int MaxEvens(params int[] x)
        {
            return delegates_hw.MathClass.Max_(delegates_hw.MathClass.Evens, x);
        }

        [TestCase(10, 45, 26, 73, 34, 11, ExpectedResult = 73)]
        public int MaxOdds(params int[] x)
        {
            return delegates_hw.MathClass.Max_(delegates_hw.MathClass.Odds, x);
        }

        [TestCase(10, 45, 26, 73, 34, 11, ExpectedResult = 23)]
        public int AvgEvens(params int[] x)
        {
            return delegates_hw.MathClass.Avg_(delegates_hw.MathClass.Evens, x);
        }

        [TestCase(10, 45, 26, 73, 34, 11, ExpectedResult = 43)]
        public int AvgOdds(params int[] x)
        {
            return delegates_hw.MathClass.Avg_(delegates_hw.MathClass.Odds, x);
        }

        [TestCase(10, 45, 26, 73, 34, 11, ExpectedResult = 199)]
        public int SumAll(params int[] x)
        {
            return delegates_hw.MathClass.Sum_(null, x);
        }

        [TestCase(10, 45, 26, 73, 34, 11, ExpectedResult = 73)]
        public int MaxAll(params int[] x)
        {
            return delegates_hw.MathClass.Max_(null, x);
        }

        [TestCase(10, 45, 26, 73, 34, 11, ExpectedResult = 33)]
        public int AvgAll(params int[] x)
        {
            return delegates_hw.MathClass.Avg_(null, x);
        }
    }
}