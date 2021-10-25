using System.ComponentModel.DataAnnotations;

namespace Util.Support.Requests.RiskCategory
{
    public class GetRiskCategoriesByDepartmentSearchRequest : PaginationRequest
    {
        [Required]
        public int? DepartmentId { get; set; }
        [Required]
        public string Filter { get; set; }
    }
}
