using Rest414Test.Dto;
using Rest414Test.Entity;

namespace Rest414Test.Resources
{
    public class AdminAuthorizedResource : RestQueries<SimpleEntity, SimpleEntity, SimpleEntity, SimpleEntity>
    {
        public AdminAuthorizedResource() : base(RestUrlRepository.GetAdminAuthorized())
        {
        }

    }
}
