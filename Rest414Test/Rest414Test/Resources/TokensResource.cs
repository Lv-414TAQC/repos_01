using Rest414Test.Dto;
using Rest414Test.Entity;

namespace Rest414Test.Resources
{
    public class TokensResource :  RestQueries<SimpleEntity, SimpleEntity, SimpleEntity, SimpleEntity>
    {
        public TokensResource() : base(RestUrlRepository.GetTokens())
        {

        }

    }
}
