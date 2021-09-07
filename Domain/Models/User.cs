using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int UserRoleId { get; set; }
        public MRole UserRole { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Seq { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Enabled { get; set; } = true;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public UserProfile UserProfile { get; set; }
    }
}
