using System.Collections.Generic;
using Util.Dtos.RiskControl;

namespace Util.Support.Requests.RiskControl
{
    public class AddRangeRiskControlRequest
    {
        public IEnumerable<AddRiskControlDto> RiskControls { get; set; }
    }
}
