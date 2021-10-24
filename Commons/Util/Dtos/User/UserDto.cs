using Util.Dtos.MRole;

namespace Util.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public MRoleDto Role { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
    }
}
