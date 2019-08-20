using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest414Test.Entity
{
    public class SimpleEntity
    {
        
        public string content { get; set; }

        public SimpleEntity() // for T result = default(T); from class RestCrud<T>
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
            else if ((obj == null)           // string.IsNullOrEmpty
                || (!(obj is SimpleEntity))) // this.GetType() != obj.GetType()
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
