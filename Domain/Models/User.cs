using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public int UserRoleId { get; set; }
        public MRole UserRole { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Seq { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Enabled { get; set; } = true;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
