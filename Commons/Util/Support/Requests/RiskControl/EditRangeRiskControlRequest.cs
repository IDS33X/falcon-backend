using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Util.Dtos.RiskControl;

namespace Util.Support.Requests.RiskControl
{
    public class EditRangeRiskControlRequest
    {
        [Required]
        public IEnumerable<RemoveRiskControlDto> RiskControls { get; set; }
    }
}
