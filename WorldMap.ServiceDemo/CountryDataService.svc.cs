using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WorldMap.Model;
using WorldMap.DAL.CRUDOperation;

namespace WorldMap.ServiceDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CountryDataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CountryDataService.svc or CountryDataService.svc.cs at the Solution Explorer and start debugging.
    public class CountryDataService : ICountryDataService
    {
        CountryDataCRUD countryDataCRUD = new CountryDataCRUD();

        public void Insert(CountryData entity)
        {
            countryDataCRUD.Insert(entity);
        }

        public void Delete(CountryData entity)
        {
            countryDataCRUD.Delete(entity);
        }

        public void Update(CountryData entity)
        {
            countryDataCRUD.Update(entity);
        }

        public List<CountryData> SelectAll()
        {
            return countryDataCRUD.SelectAll();
        }

        public CountryData SelectById(object id)
        {
            return countryDataCRUD.SelectById(id);
        }
    }
}
