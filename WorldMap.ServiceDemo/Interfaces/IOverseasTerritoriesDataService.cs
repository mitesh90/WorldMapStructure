using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WorldMap.Model;

namespace WorldMap.ServiceDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOverseasTerritoriesDataService" in both code and config file together.
    [ServiceContract]
    public interface IOverseasTerritoriesDataService
    {
        [OperationContract]
        void Insert(OverseasTerritoriesData entity);

        [OperationContract]
        void Delete(OverseasTerritoriesData entity);

        [OperationContract]
        void Update(OverseasTerritoriesData entity);

        [OperationContract]
        List<OverseasTerritoriesData> SelectAll();

        [OperationContract]
        OverseasTerritoriesData SelectById(object id);
    }
}
