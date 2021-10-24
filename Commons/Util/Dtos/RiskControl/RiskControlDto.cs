using System;

namespace Util.Dtos.RiskControl
{
    public class RiskControlDto
    {

        public Guid RiskId { get; set; }

        public Guid ControlId { get; set; }

        public DateTime AssignDate { get; set; }

        public DateTime? DeallocatedDate { get; set; }

    }
}
