using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int UserRoleId { get; set; }

        public MRole UserRole { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Seq { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        public bool Enabled { get; set; } = true;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public DateTime CreatedDate { get; set; }

        public UserProfile UserProfile { get; set; }
    }
}
