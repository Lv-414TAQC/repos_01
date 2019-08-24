
namespace Rest414Test.Data
{
    public sealed class ItemRepository
    {
        private ItemRepository()
        {
        }

        public static ItemTemplate GetFirst()
        {
            return new ItemTemplate("my first information", "123");
        }

        public static ItemTemplate GetSecond()
        {
            return new ItemTemplate("my second information", "2345");
        }

    }

}
