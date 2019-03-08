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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserDataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserDataService.svc or UserDataService.svc.cs at the Solution Explorer and start debugging.
    public class UserDataService : IUserDataService
    {
        UserDataCRUD userDataCRUD = new UserDataCRUD();

        public void Insert(UserData entity)
        {
            userDataCRUD.Insert(entity);
        }

        public void Delete(UserData entity)
        {
            userDataCRUD.Delete(entity);
        }

        public void Update(UserData entity)
        {
            userDataCRUD.Update(entity);
        }

        public List<UserData> SelectAll()
        {
            return userDataCRUD.SelectAll();
        }

        public UserData SelectById(object id)
        {
            return userDataCRUD.SelectById(id);
        }
    }
}
