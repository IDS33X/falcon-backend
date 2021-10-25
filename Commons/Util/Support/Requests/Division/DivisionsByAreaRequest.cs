using System.ComponentModel.DataAnnotations;

namespace Util.Support.Requests.Division
{
    public class DivisionsByAreaRequest : PaginationRequest
    {
        [Required]
        public int? AreaId { get; set; }
    }
}
