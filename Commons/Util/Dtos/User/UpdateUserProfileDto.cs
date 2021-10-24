using System.ComponentModel.DataAnnotations;

namespace Util.Dtos.User
{
    public class UpdateUserProfileDto
    {
        [Required]
        public int? Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
