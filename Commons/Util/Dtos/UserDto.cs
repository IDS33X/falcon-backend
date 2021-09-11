using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public MRoleDto Role { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
    }
}
