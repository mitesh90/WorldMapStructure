using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMap.Model
{
    public class RoleData
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public List<UserRoleMapping> userRoleMapping { get; set; }
    }
}
