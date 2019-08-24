using Rest414Test.Dto;
using Rest414Test.Entity;

namespace Rest414Test.Resources
{
    public class CoolDownTimeResource : RestQueries<SimpleEntity, SimpleEntity, SimpleEntity, SimpleEntity>
    {
        public CoolDownTimeResource() : base(RestUrlRepository.GetCoolDownTime())
        {
        }
    }
}
