using System.ComponentModel.DataAnnotations;
using Util.Dtos.Risk;

namespace Util.Support.Requests.Risk
{
    public class EditRiskRequest
    {
        [Required]
        public UpdateRiskDto Risk { get; set; }
    }
}
