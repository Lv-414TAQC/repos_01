using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Data
{
    public class GeoZone
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }

        public GeoZone(string name, string description, string country)
        {
            Name = name;
            Description = description;
            Country = country;
        }
    }
}
