using System.Collections.Generic;
using Util.Dtos.RiskControl;

namespace Util.Support.Responses.RiskControl
{
    public class AddRangeRiskControlResponse
    {
        public IEnumerable<RiskControlDto> RiskControlsAdded { get; set; }
        public IEnumerable<RiskControlErrorDto> RiskControlsNotAdded { get; set; }
    }
}
