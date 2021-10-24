using System;
using System.ComponentModel.DataAnnotations;

namespace Util.Dtos.RiskControl
{
    public class AddRiskControlDto
    {
        [Required]
        public Guid? RiskId { get; set; }
        [Required]
        public Guid? ControlId { get; set; }
    }
}
