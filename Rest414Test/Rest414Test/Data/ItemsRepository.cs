using System.Collections.Generic;

namespace Rest414Test.Data
{
    public sealed class ItemsRepository
    {
        private ItemsRepository()
        {
        }

        public static List<ItemTemplate> ListItems()
        {
            List<ItemTemplate> list = new List<ItemTemplate>();
            list.Add(ItemRepository.GetFirst());
            list.Add(ItemRepository.GetSecond());
            return list;
        }
    }
}
