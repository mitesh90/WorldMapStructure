using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WorldMap.Model;

namespace WorldMap.ServiceDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserDataService" in both code and config file together.
    [ServiceContract]
    public interface IUserDataService
    {
        [OperationContract]
        void Insert(UserData entity);

        [OperationContract]
        void Delete(UserData entity);

        [OperationContract]
        void Update(UserData entity);

        [OperationContract]
        List<UserData> SelectAll();

        [OperationContract]
        UserData SelectById(object id);
    }
}
