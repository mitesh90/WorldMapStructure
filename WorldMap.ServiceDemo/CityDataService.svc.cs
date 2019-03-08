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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CityDataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CityDataService.svc or CityDataService.svc.cs at the Solution Explorer and start debugging.
    public class CityDataService : ICityDataService
    {
        CityDataCRUD cityDataCRUD = new CityDataCRUD();

        public void Insert(CityData entity)
        {
            cityDataCRUD.Insert(entity);
        }

        public void Delete(CityData entity)
        {
            cityDataCRUD.Delete(entity);
        }

        public void Update(CityData entity)
        {
            cityDataCRUD.Update(entity);
        }

        public List<CityData> SelectAll()
        {
            return cityDataCRUD.SelectAll();
        }

        public CityData SelectById(object id)
        {
            return cityDataCRUD.SelectById(id);
        }
    }
}
