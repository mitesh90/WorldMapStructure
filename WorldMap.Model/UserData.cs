using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMap.Model
{
    public class UserData
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public List<UserRoleMapping> userRoleMapping { get; set; }
    }
}
