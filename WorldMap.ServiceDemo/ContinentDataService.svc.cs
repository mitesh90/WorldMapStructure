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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ContinentDataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ContinentDataService.svc or ContinentDataService.svc.cs at the Solution Explorer and start debugging.
    public class ContinentDataService : IContinentDataService
    {
        ContinentDataCRUD continentData = new ContinentDataCRUD();

        public void Insert(ContinentData entity)
        {
            continentData.Insert(entity);
        }

        public void Delete(ContinentData entity)
        {
            continentData.Delete(entity);
        }

        public void Update(ContinentData entity)
        {
            continentData.Update(entity);
        }

        public List<ContinentData> SelectAll()
        {
            return continentData.SelectAll();
        }

        public ContinentData SelectById(object id)
        {
            return continentData.SelectById(id);
        }
    }
}
