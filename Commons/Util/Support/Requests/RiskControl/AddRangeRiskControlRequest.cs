using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Util.Dtos.RiskControl;

namespace Util.Support.Requests.RiskControl
{
    public class AddRangeRiskControlRequest
    {
        [Required]
        public IEnumerable<AddRiskControlDto> RiskControls { get; set; }
    }
}
