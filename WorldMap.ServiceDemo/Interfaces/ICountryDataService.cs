using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WorldMap.Model;

namespace WorldMap.ServiceDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICountryDataService" in both code and config file together.
    [ServiceContract]
    public interface ICountryDataService
    {
        [OperationContract]
        void Insert(CountryData entity);

        [OperationContract]
        void Delete(CountryData entity);

        [OperationContract]
        void Update(CountryData entity);

        [OperationContract]
        List<CountryData> SelectAll();

        [OperationContract]
        CountryData SelectById(object id);
    }
}
