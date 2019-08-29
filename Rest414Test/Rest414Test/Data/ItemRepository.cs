
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
        public static ItemTemplate UserItemFirst()
        {
            return new ItemTemplate("first user item", "888");
        }
        public static ItemTemplate UserItemSecond()
        {
            return new ItemTemplate("second user item", "999");
        }
        public static ItemTemplate UpdateItem()
        {
            return new ItemTemplate("updated information", "123");
        }

    }

}
