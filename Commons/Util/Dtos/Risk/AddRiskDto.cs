using System.ComponentModel.DataAnnotations;

namespace Util.Dtos.Risk
{
    public class AddRiskDto
    {
        [Required]
        public int? UserId { get; set; }
        [Required]
        public int? RiskCategoryId { get; set; }
        [Required]
        public int? InherentRiskId { get; set; }
        [Required]
        public int? ControlledRiskId { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string RootCause { get; set; }
    }
}
