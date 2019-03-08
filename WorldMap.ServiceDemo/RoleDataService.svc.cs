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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoleDataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RoleDataService.svc or RoleDataService.svc.cs at the Solution Explorer and start debugging.
    public class RoleDataService : IRoleDataService
    {
        RoleDataCRUD roleDataCRUD = new RoleDataCRUD();

        public void Insert(RoleData entity)
        {
            roleDataCRUD.Insert(entity);
        }

        public void Delete(RoleData entity)
        {
            roleDataCRUD.Delete(entity);
        }

        public void Update(RoleData entity)
        {
            roleDataCRUD.Update(entity);
        }

        public List<RoleData> SelectAll()
        {
            return roleDataCRUD.SelectAll();
        }

        public RoleData SelectById(object id)
        {
            return roleDataCRUD.SelectById(id);
        }
    }
}
