using System;

namespace Util.Dtos
{
    public class RiskDto
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public int RiskCategoryId { get; set; }
        public RiskCategoryDto RiskCategory { get; set; }
        public int InherentRiskId { get; set; }
        public RiskImpactDto InherentRisk { get; set; }
        public int ControlledRiskId { get; set; }
        public RiskImpactDto ControlledRisk { get; set; }
        public DateTime CreationDate { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string RootCause { get; set; }

    }
}
