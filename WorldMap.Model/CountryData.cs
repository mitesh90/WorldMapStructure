using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMap.Model
{
    public class CountryData
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCapital { get; set; }
        public Double CountryArea { get; set; }
        public int ContinentId { get; set; }
        public bool IsIsland { get; set; }
        public bool IsActive { get; set; }

        public List<StateData> stateData { get; set; }
        public List<OverseasTerritoriesData> overseasTerritoriesData { get; set; }
    }
}
