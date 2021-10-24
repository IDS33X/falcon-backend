using System.Collections.Generic;
using Util.Dtos.RiskImpact;

namespace Util.Support.Responses.RiskImpact
{
    public class GetAllRiskImpactsResponse
    {
        public IEnumerable<RiskImpactDto> RiskImpacts { get; set; }
    }
}
