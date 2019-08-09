using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Data
{
    public interface IUser
    {
        string Firstname { get; }
        string Lastname { get; }
        string Email { get; }
        string Telephone { get; }
        string Fax { get; }         // not required
        string Company { get; }     // not required
        string Address1 { get; }
        string Address2 { get; }    // not required
        string City { get; }
        string Postcode { get; }
        string Country { get; }
        string RegionState { get; }
        string Password { get; }
        bool Subscribe { get; }
    }
}
