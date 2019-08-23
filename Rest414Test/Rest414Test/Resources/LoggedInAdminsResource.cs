using Rest414Test.Dto;
using Rest414Test.Entity;

namespace Rest414Test.Resources
{
    public class LoggedInAdminsResource : RestQueries<SimpleEntity, SimpleEntity, SimpleEntity, SimpleEntity>
    {
        public LoggedInAdminsResource() : base(RestUrlRepository.GetLoggedInAdmins())
        {

        }
    }
}
