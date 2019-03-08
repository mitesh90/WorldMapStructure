using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WorldMap.Model;

namespace WorldMap.ServiceDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStateDataService" in both code and config file together.
    [ServiceContract]
    public interface IStateDataService
    {
        [OperationContract]
        void Insert(StateData entity);

        [OperationContract]
        void Delete(StateData entity);

        [OperationContract]
        void Update(StateData entity);

        [OperationContract]
        List<StateData> SelectAll();

        [OperationContract]
        StateData SelectById(object id);
    }
}
