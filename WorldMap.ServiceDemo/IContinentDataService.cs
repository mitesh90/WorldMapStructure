using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WorldMap.Model;

namespace WorldMap.ServiceDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IContinentDataService" in both code and config file together.
    [ServiceContract]
    public interface IContinentDataService
    {
        [OperationContract]
        void Insert(ContinentData entity);

        [OperationContract]
        void Delete(ContinentData entity);

        [OperationContract]
        void Update(ContinentData entity);

        [OperationContract]
        List<ContinentData> SelectAll();

        [OperationContract]
        ContinentData SelectById(object id);
    }
}
