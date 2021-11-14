using System.ComponentModel.DataAnnotations;
using Util.Dtos.RiskControl;

namespace Util.Support.Requests.RiskControl
{
    public class AddRiskControlRequest
    {
        [Required]
        public AddRiskControlDto RiskControl { get; set; }
    }
}
