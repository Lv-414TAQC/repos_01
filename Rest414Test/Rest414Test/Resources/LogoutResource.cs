using Rest414Test.Dto;
using Rest414Test.Entity;

namespace Rest414Test.Resources
{
    public class LogoutResource : RestQueries<SimpleEntity, SimpleEntity, SimpleEntity, SimpleEntity>
    {
        public LogoutResource() : base(RestUrlRepository.GetLogout())
        {
        }
    }
}
