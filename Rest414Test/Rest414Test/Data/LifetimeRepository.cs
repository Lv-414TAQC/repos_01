
namespace Rest414Test.Data
{
    public sealed class LifetimeRepository
    {
        public const string DefaultTokenLifetime = "300000";
        public const string LongTokenLifetime = "800000";

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
    }
}
