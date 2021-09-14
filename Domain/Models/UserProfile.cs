using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        [Required]
        public Guid? UserId { get; set; }

        public User User { get; set; }

        [Required]
        [MaxLength(45)]
        public string Name { get; set; }

        [Required]
        [MaxLength(55)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        public string Code { get; set; }
        public Division Division { get; set; }

        public IEnumerable<Risk> Risks { get; set; }

    }
}
