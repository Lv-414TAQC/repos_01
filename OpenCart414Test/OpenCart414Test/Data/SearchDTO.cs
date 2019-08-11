
namespace OpenCart414Test.Data
{
    public class SearchDTO
    {
        public string UIPartialName { get; private set; }
        public string SearchByName { get; private set; }

        public SearchDTO(string uiPartialName, string searchByName)
        {
            UIPartialName = uiPartialName;
            SearchByName = searchByName;
        }
    }
}
