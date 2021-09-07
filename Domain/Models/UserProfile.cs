using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
    }
}
