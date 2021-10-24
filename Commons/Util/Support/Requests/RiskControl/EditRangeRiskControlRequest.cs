using System.Collections.Generic;
using Util.Dtos.RiskControl;

namespace Util.Support.Requests.RiskControl
{
    public class EditRangeRiskControlRequest
    {
        public IEnumerable<RemoveRiskControlDto> RiskControls { get; set; }
    }
}
