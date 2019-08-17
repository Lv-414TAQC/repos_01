using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Data
{
    static class GeoZonesRepository
    {
         public static GeoZone GetUAGeoZone()
        {
            return new GeoZone(
                "UA Tax Zone",
                "New Eco Taxes",
                "Ukraine"
            );
        }
    }
}
