using System.ComponentModel.DataAnnotations;

namespace Util.Support.Requests.Control
{
    public class GetControlsByRiskCategoryRequest : PaginationRequest
    {
        [Required]
        public int? RiskCategoryId { get; set; }
    }
}
