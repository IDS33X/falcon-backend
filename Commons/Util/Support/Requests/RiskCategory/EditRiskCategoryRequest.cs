using System.ComponentModel.DataAnnotations;
using Util.Dtos.RiskCategory;

namespace Util.Support.Requests.RiskCategory
{
    public class EditRiskCategoryRequest
    {
        [Required]
        public UpdateRiskCategoryDto RiskCategory { get; set; }
    }
}
