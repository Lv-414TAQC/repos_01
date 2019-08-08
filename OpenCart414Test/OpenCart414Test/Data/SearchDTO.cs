using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Data
{
    public class SearchDTO
    {
        public string UIPartialName { get; private set; }
        public string SearchByName { get; private set; }

        public SearchDTO(string uiPartialName, string searchByName)
        {
            UIPartialName = uiPartialName;
            SearchByName = searchByName;
        }
    }
}
