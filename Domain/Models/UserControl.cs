using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class UserControl
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public Guid ControlId { get; set; }

        [Required]
        public DateTime AssignDate { get; set; }

        public DateTime? DeallocatedDate { get; set; }

        public UserProfile User { get; set; }
        public Control Control { get; set; }



    }
}
