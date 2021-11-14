using System.ComponentModel.DataAnnotations;

namespace Util.Support.Requests.Risk
{
    public class GetRiskByCategoryRequest : PaginationRequest
    {
        [Required]
        public int? RiskCategoryId { get; set; }
    }
}
