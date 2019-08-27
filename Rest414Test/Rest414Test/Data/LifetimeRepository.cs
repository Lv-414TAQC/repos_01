  
namespace Rest414Test.Data
{
    public sealed class LifetimeRepository
    {
        public const string DEFAULT_TOKEN_LIFETIME = "300000";
        public const string LONG_TOKEN_LIFETIME = "987654321";
        public const string NEGETIVE_TOKEN_LIFETIME = "-123123";
        public const string ZERO_TOKEN_LIFETIME = "0";
        public const string TOKEN_LIFETIME_WITH_LETTERS = "123123test";
        public const string TOKEN_LIFETIME_WITH_SYMBOLS = "1_23#";
        public const string TEST_REAL_TOKEN_LIFETIME = "10000";

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
            return new Lifetime(NEGETIVE_TOKEN_LIFETIME);
        }

        public static Lifetime GetZeroLifeTime()
        {
            return new Lifetime(ZERO_TOKEN_LIFETIME);
        }

        public static Lifetime GetLifeTimeWithLetters()
        {
            return new Lifetime(TOKEN_LIFETIME_WITH_LETTERS);
        }

        public static Lifetime GetLifeTimeWithSymbols()
        {
            return new Lifetime(TOKEN_LIFETIME_WITH_SYMBOLS);
        }

        public static Lifetime GetTestRealTokenLifeTime()
        {
            return new Lifetime(TEST_REAL_TOKEN_LIFETIME);
        }
    }
}
