using System;

namespace Util.Dtos.RiskControl
{
    public class RiskControlErrorDto
    {
        public Guid RiskId { get; set; }
        public Guid ControlId { get; set; }
        public string ErrorMessage { get; set; }
    }
}
