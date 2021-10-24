using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Dtos.ControlDtos
{
    public class ControlUpdateDto
    {
        [Required]
        public Guid Id { get; set; }
        
        public int ControlStateId { get; set; }
        
        public int AutomationLevelId { get; set; }
       
        public int ControlTypeId { get; set; }

        public string Frequency { get; set; }

        public string Code { get; set; }

        public bool Documented { get; set; }

        public string Policy { get; set; }

        public string ResponsablePosition { get; set; }

        public string Activity { get; set; }

        public string Objective { get; set; }

        public string Evidence { get; set; }

        public int UserId { get; set; }
 
    }
}
