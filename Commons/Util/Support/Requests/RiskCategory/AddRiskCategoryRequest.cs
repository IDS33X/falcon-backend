using System.ComponentModel.DataAnnotations;
using Util.Dtos.RiskCategory;

namespace Util.Support.Requests.RiskCategory
{
    public class AddRiskCategoryRequest
    {
        [Required]
        public AddRiskCategoryDto RiskCategory { get; set; }
    }
}
