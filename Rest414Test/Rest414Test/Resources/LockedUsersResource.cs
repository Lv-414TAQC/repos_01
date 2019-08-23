using Rest414Test.Dto;
using Rest414Test.Entity;

namespace Rest414Test.Resources
{
    public class LockedUsersResource : RestQueries<SimpleEntity, SimpleEntity, SimpleEntity, SimpleEntity>
    {
       
        
            public LockedUsersResource() : base(RestUrlRepository.GetLockedUsers())
            {

            }
    
    }
}
