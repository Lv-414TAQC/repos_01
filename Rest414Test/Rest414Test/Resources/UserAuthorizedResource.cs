using Rest414Test.Dto;
using Rest414Test.Entity;

namespace Rest414Test.Resources
{
    public class UserAuthorizedResource : RestQueries<SimpleEntity, SimpleEntity, SimpleEntity, SimpleEntity>
    {
        public UserAuthorizedResource() : base(RestUrlRepository.GetUserAuthorized())
        {
        }
    }
}
