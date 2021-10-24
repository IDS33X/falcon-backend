using System;
using System.ComponentModel.DataAnnotations;

namespace Util.Dtos.RiskControl
{
    public class RemoveRiskControlDto
    {
        [Required]
        public Guid? RiskId { get; set; }
        [Required]
        public Guid? ControlId { get; set; }
    }
}
