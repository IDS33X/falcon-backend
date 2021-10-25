using System.ComponentModel.DataAnnotations;

namespace Util.Support.Requests.RiskCategory
{
    public class GetRiskCategoriesByDepartmentRequest : PaginationRequest
    {
        [Required]
        public int? DepartmentId { get; set; }
    }
}
