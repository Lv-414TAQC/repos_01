
namespace Rest414Test.Data
{
    public sealed class CoolDownTimeRepository
    {
        
            public const string DefaultCoolDownTime = "180000";
            public const string NewCoolDownTime = "240000";


            private CoolDownTimeRepository()
            {
            }

            public static CoolDownTime GetDefault()
            {
                return new CoolDownTime(DefaultCoolDownTime);
            }
            public static CoolDownTime NewCoolDown()
            {
                return new CoolDownTime(NewCoolDownTime);
            }
    }
}
