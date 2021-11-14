using System.ComponentModel.DataAnnotations;

namespace Util.Support.Requests.Risk
{
    public class GetRiskByCategoryAndDescriptionRequest : PaginationRequest
    {
        [Required]
        public int? RiskCategoryId { get; set; }
        [Required]
        public string Filter { get; set; }
    }
}