using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorldMap.Model;

namespace WorldMap.MVC.Models
{
    public class ContinentDataModel
    {
        public ContinentData SearchCountry { get; set; }
        public List<ContinentData> CountryList { get; set; }
    }
}