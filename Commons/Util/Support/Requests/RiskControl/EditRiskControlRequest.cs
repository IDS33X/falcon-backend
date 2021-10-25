using System.ComponentModel.DataAnnotations;
using Util.Dtos.RiskControl;

namespace Util.Support.Requests.RiskControl
{
    public class EditRiskControlRequest
    {
        [Required]
        public RemoveRiskControlDto RiskControl { get; set; }
    }
}
