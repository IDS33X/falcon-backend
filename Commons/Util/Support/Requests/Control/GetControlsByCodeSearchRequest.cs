using System.ComponentModel.DataAnnotations;

namespace Util.Support.Requests.Control
{
    public class GetControlsByCodeSearchRequest : PaginationRequest
    {
        [Required]
        public int? RiskCategoryId { get; set; }
        [Required]
        public string Filter { get; set; }
    }
}
