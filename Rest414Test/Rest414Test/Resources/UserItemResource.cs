using Rest414Test.Dto;
using Rest414Test.Entity;

namespace Rest414Test.Resources
{
    public class UserItemResource : RestQueries<SimpleEntity, SimpleEntity, SimpleEntity, SimpleEntity>
    {
        public UserItemResource() : base(RestUrlRepository.GetUserItem())
        {
        }
    }
}
