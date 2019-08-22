using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest414Test.Data
{
    public interface IUser
    {
        string Name { get; }        // Required
        string Password { get; set; }    // Required
        string Token { get; set; }
    }

}
