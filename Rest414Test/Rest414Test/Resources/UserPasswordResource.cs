using Rest414Test.Dto;
using Rest414Test.Entity;

namespace Rest414Test.Resources
{
    public class UserPasswordResource : RestQueries<SimpleEntity, SimpleEntity, SimpleEntity, SimpleEntity>
    {
        public UserPasswordResource() : base(RestUrlRepository.ChangePassw())
        {

        }
    }
}
