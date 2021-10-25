using System.ComponentModel.DataAnnotations;
using Util.Dtos.Risk;

namespace Util.Support.Requests.Risk
{
    public class AddRiskRequest
    {
        [Required]
        public AddRiskDto Risk { get; set; }
    }
}
