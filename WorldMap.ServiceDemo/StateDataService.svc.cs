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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StateDataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StateDataService.svc or StateDataService.svc.cs at the Solution Explorer and start debugging.
    public class StateDataService : IStateDataService
    {
        StateDataCRUD stateDataCRUD = new StateDataCRUD();

        public void Insert(StateData entity)
        {
            stateDataCRUD.Insert(entity);
        }

        public void Delete(StateData entity)
        {
            stateDataCRUD.Delete(entity);
        }

        public void Update(StateData entity)
        {
            stateDataCRUD.Update(entity);
        }

        public List<StateData> SelectAll()
        {
            return stateDataCRUD.SelectAll();
        }

        public StateData SelectById(object id)
        {
            return stateDataCRUD.SelectById(id);
        }
    }
}
