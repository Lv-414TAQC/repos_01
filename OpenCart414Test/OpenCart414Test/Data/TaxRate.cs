using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Data
{
    public class TaxRate
    {
        public string Name { get; set; }
        public double Rate { get; set; }
        public string Type { get; set; }
        public string GeoZone { get; set; }

        public TaxRate(string name, double rate, string type, string geoZone)
        {
            Name = name;
            Rate = rate;
            Type = type;
            GeoZone = geoZone;
        }
    }    
}
