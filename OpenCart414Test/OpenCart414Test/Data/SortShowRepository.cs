
namespace OpenCart414Test.Data
{
    public sealed class SortShowRepository
    {
        private SortShowRepository() { }

        public static SortShowCriteria ShowBy25()
        {
            return new SortShowCriteria("Default", "25");
        }
        public static SortShowCriteria SortByAsc()
        {
            return new SortShowCriteria("Price (Low > High)", "15");
        }
    }
}
