using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WorldMap.Model;

namespace WorldMap.ServiceDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICityDataService" in both code and config file together.
    [ServiceContract]
    public interface ICityDataService
    {
        [OperationContract]
        void Insert(CityData entity);

        [OperationContract]
        void Delete(CityData entity);

        [OperationContract]
        void Update(CityData entity);

        [OperationContract]
        List<CityData> SelectAll();

        [OperationContract]
        CityData SelectById(object id);
    }
}
