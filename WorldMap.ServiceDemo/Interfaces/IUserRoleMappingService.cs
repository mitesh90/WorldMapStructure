using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WorldMap.Model;

namespace WorldMap.ServiceDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserRoleMappingService" in both code and config file together.
    [ServiceContract]
    public interface IUserRoleMappingService
    {
        [OperationContract]
        void Insert(UserRoleMapping entity);

        [OperationContract]
        void Delete(UserRoleMapping entity);

        [OperationContract]
        void Update(UserRoleMapping entity);

        [OperationContract]
        List<UserRoleMapping> SelectAll();

        [OperationContract]
        UserRoleMapping SelectById(object id);
    }
}
