using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest414Test.Data
{
    public sealed class CoolDownTimeRepository
    {
        
            public const string DEFAULT_COOLDOWNTIME = "180000";
            public const string NEW_COOLDOWNTIME = "240000";


            private CoolDownTimeRepository()
            {
            }

            public static CoolDownTime GetDefault()
            {
                return new CoolDownTime(DEFAULT_COOLDOWNTIME);
            }
            public static CoolDownTime NewCoolDown()
            {
                return new CoolDownTime(NEW_COOLDOWNTIME);
            }


    }
}
