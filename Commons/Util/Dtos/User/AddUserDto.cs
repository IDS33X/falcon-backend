using System.ComponentModel.DataAnnotations;

namespace Util.Dtos.User
{
    public class AddUserDto
    {
        [Required]
        public int? DepartmentId { get; set; }
        [Required]
        public int? RoleId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
