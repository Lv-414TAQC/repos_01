
namespace Rest414Test.Data
{
    public class ItemTemplate
    {
        public string Item { get; private set; }    // Required
        public string Index { get; private set; }   // Required

        public ItemTemplate(string item, string index)
        {
            Item = item;
            Index = index;
        }

        public override string ToString()
        {
            return "[Item: " + Item + ", Index: " + Index + "]";
        }
    }

}
