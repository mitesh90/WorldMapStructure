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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OverseasTerritoriesDataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OverseasTerritoriesDataService.svc or OverseasTerritoriesDataService.svc.cs at the Solution Explorer and start debugging.
    public class OverseasTerritoriesDataService : IOverseasTerritoriesDataService
    {
        OverseasTerritoriesDataCRUD overseasTerritoriesDataCRUD = new OverseasTerritoriesDataCRUD();

        public void Insert(OverseasTerritoriesData entity)
        {
            overseasTerritoriesDataCRUD.Insert(entity);
        }

        public void Delete(OverseasTerritoriesData entity)
        {
            overseasTerritoriesDataCRUD.Delete(entity);
        }

        public void Update(OverseasTerritoriesData entity)
        {
            overseasTerritoriesDataCRUD.Update(entity);
        }

        public List<OverseasTerritoriesData> SelectAll()
        {
            return overseasTerritoriesDataCRUD.SelectAll();
        }

        public OverseasTerritoriesData SelectById(object id)
        {
            return overseasTerritoriesDataCRUD.SelectById(id);
        }
    }
}
