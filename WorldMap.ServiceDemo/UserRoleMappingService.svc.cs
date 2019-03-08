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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserRoleMappingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserRoleMappingService.svc or UserRoleMappingService.svc.cs at the Solution Explorer and start debugging.
    public class UserRoleMappingService : IUserRoleMappingService
    {
        UserRoleMappingCRUD userRoleMappingCRUD = new UserRoleMappingCRUD();

        public void Insert(UserRoleMapping entity)
        {
            userRoleMappingCRUD.Insert(entity);
        }

        public void Delete(UserRoleMapping entity)
        {
            userRoleMappingCRUD.Delete(entity);
        }

        public void Update(UserRoleMapping entity)
        {
            userRoleMappingCRUD.Update(entity);
        }

        public List<UserRoleMapping> SelectAll()
        {
            return userRoleMappingCRUD.SelectAll();
        }

        public UserRoleMapping SelectById(object id)
        {
            return userRoleMappingCRUD.SelectById(id);
        }
    }
}
