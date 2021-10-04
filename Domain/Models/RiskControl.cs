using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RiskControl
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid RiskId { get; set; }

        public Risk Risk { get; set; }

        [Required]
        public Guid ControlId { get; set; }

        public Control Control { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public DateTime AssignDate { get; set; }

        public DateTime? DeallocatedDate { get; set; }


    }
}
