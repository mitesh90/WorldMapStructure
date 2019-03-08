using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMap.Model
{
    public class ContinentData
    {
        public int ContinentId { get; set; }
        public string ContinentName { get; set; }
        public bool IsActive { get; set; }

        public List<CountryData> countryData { get; set; }
    }
}
