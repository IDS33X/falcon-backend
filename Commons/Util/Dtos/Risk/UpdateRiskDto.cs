using System;
using System.ComponentModel.DataAnnotations;

namespace Util.Dtos.Risk
{
    public class UpdateRiskDto
    {
        [Required]
        public Guid? Id { get; set; }
        public int InherentRiskId { get; set; }
        public int ControlledRiskId { get; set; }
        public string Description { get; set; }
        public string RootCause { get; set; }
    }
}
