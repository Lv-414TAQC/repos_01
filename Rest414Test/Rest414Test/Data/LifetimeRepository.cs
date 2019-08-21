using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest414Test.Data
{
    public sealed class LifetimeRepository
    {
        public const string DEFAULT_TOKEN_LIFETIME = "300000";
        public const string LONG_TOKEN_LIFETIME = "800000";

        private LifetimeRepository()
        {
        }

        public static Lifetime GetDefault()
        {
            return new Lifetime(DEFAULT_TOKEN_LIFETIME);
        }

        public static Lifetime GetLongTime()
        {
            return new Lifetime(LONG_TOKEN_LIFETIME);
        }
    }

}
