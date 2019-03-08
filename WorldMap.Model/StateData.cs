using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMap.Model
{
    public class StateData
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string StateCapital { get; set; }
        public int CountryId { get; set; }
        public bool IsActive { get; set; }

        public List<CityData> cityData { get; set; }
    }
}
