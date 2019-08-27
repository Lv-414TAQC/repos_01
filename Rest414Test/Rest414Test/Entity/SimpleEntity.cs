
namespace Rest414Test.Entity
{
    public class SimpleEntity
    {
        
        public string content { get; set; }

        public SimpleEntity()
        {
        }

        public bool Equals(bool condition)
        {
            return content.ToLower().Equals(condition.ToString().ToLower());
        }

        public override bool Equals(object obj)
        {
            bool result = false;
            if (this == obj)
            {
                result = true;
            }
            else if ((obj == null)
                || (!(obj is SimpleEntity)))
            {
                result = false;
            }
            else
            {
                result = content.Equals((obj as SimpleEntity).content);
            }
            return result;
        }

        public override string ToString()
        {
            return content;
        }
    }

}
