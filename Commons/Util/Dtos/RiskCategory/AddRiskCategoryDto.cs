using System.ComponentModel.DataAnnotations;

namespace Util.Dtos.RiskCategory
{
    public class AddRiskCategoryDto
    {
        [Required]
        public int? DepartmentId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
