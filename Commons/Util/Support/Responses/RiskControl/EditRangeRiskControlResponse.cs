using System.Collections.Generic;
using Util.Dtos.RiskControl;

namespace Util.Support.Responses.RiskControl
{
    public class EditRangeRiskControlResponse
    {
        public IEnumerable<RiskControlDto> RiskControlsRemoved { get; set; }
        public IEnumerable<RiskControlErrorDto> RiskControlsNotRemoved { get; set; }
    }
}
