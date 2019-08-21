using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest414Test.Data
{
    public class Lifetime
    {
        public string Time { get; set; }

        public Lifetime()
        {
            Time = String.Empty;
        }

        public Lifetime(string time)
        {
            Time = time;
        }

        public override bool Equals(object obj)
        {
            bool result = false;
            if (this == obj)
            {
                result = true;
            }
            else if ((obj == null)       // string.IsNullOrEmpty
                || (!(obj is Lifetime))) // this.GetType() != obj.GetType()
            {
                result = false;
            }
            else 
            {
                result = Time.Equals((obj as Lifetime).Time);
            }
            return result;
        }

        public override string ToString()
        {
            return "Lifetime: [ Time = " + Time + " ];";
        }

        // TODO Equals, Integer
    }

}
