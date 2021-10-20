using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserControl
    {

        [Required]
        public int UserId { get; set; }
        public UserProfile User { get; set; }

        [Required]
        public Guid ControlId { get; set; }
        public Control Control { get; set; }
        [Required]
        public DateTime AssignDate { get; set; }

        public DateTime? DeallocatedDate { get; set; }

        
        



    }
}
