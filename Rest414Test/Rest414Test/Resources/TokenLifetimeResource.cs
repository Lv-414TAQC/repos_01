using Rest414Test.Dto;
using Rest414Test.Entity;

namespace Rest414Test.Resources
{
    public class TokenLifetimeResource : RestQueries<SimpleEntity, SimpleEntity, SimpleEntity, SimpleEntity>
    {
        public TokenLifetimeResource() : base(RestUrlRepository.GetTokenLifetime())
        {
        }

    }
}
