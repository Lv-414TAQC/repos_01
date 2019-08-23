
namespace Rest414Test.Data
{
    public sealed class CoolDownTimeRepository
    {
        
            public const string DEFAULT_COOLDOWNTIME = "180000";
            

            private CoolDownTimeRepository()
            {
            }

            public static CoolDownTime GetDefault()
            {
                return new CoolDownTime(DEFAULT_COOLDOWNTIME);
            }

            
        }
}
