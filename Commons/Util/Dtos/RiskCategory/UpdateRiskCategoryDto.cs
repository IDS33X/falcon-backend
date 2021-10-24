using System.ComponentModel.DataAnnotations;

namespace Util.Dtos.RiskCategory
{
    public class UpdateRiskCategoryDto
    {
        [Required]
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
