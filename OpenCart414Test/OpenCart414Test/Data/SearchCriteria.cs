
namespace OpenCart414Test.Data
{
    public class SearchCriteria
    {
        public const string ALL_CATEGORIES = "All Categories";
        //
        public string SearchValue { get; private set; }
        public string SearchCategory { get; private set; }
        public bool IsSearchInSubcategories { get; private set; }
        public bool IsSearchInDescription { get; private set; }

        public SearchCriteria(string searchValue, string searchCategory,
            bool isSearchInSubcategories, bool isSearchInDescription)
        {
            SearchValue = searchValue;
            SearchCategory = searchCategory;
            IsSearchInSubcategories = isSearchInSubcategories;
            IsSearchInDescription = isSearchInDescription;
        }
    }
}
