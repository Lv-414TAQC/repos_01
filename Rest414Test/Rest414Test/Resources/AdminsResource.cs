using Rest414Test.Dto;
using Rest414Test.Entity;

namespace Rest414Test.Resources
{
    public class AdminsResource : RestQueries<SimpleEntity, SimpleEntity, SimpleEntity, SimpleEntity>
    {
        public AdminsResource() : base(RestUrlRepository.GetAllAdmins())
        {

        }
    }
}
