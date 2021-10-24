using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class RiskControl
    {

        [Required]
        public Guid RiskId { get; set; }

        public Risk Risk { get; set; }

        [Required]
        public Guid ControlId { get; set; }

        public Control Control { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public DateTime AssignDate { get; set; }

        public DateTime? DeallocatedDate { get; set; }


    }
}
