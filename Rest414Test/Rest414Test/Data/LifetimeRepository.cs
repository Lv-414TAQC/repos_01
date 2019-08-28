  
namespace Rest414Test.Data
{
    public sealed class LifetimeRepository
    {
        public const string DefaultTokenLifetime = "300000";
        public const string LongTokenLifetime = "987654321";
        public const string NegetiveTokenLifetime = "-123123";
        public const string ZeroTokenLifetime = "0";
        public const string TokenLifetimeWithLetters = "123123test";
        public const string TokenLifetimeWithSymbols = "1_23#";
        public const string TestRealTokenLifetime = "10000";

        private LifetimeRepository()
        {
        }

        public static Lifetime GetDefault()
        {
            return new Lifetime(DefaultTokenLifetime);
        }

        public static Lifetime GetLongTime()
        {
            return new Lifetime(LongTokenLifetime);
        }

        public static Lifetime GetNegetiveLifeTime()
        {
            return new Lifetime(NegetiveTokenLifetime);
        }

        public static Lifetime GetZeroLifeTime()
        {
            return new Lifetime(ZeroTokenLifetime);
        }

        public static Lifetime GetLifeTimeWithLetters()
        {
            return new Lifetime(TokenLifetimeWithLetters);
        }

        public static Lifetime GetLifeTimeWithSymbols()
        {
            return new Lifetime(TokenLifetimeWithSymbols);
        }

        public static Lifetime GetTestRealTokenLifeTime()
        {
            return new Lifetime(TestRealTokenLifetime);
        }
    }
}
