using System.ComponentModel.DataAnnotations;

namespace Util.Support.Requests.Division
{
    public class DivisionsByAreaSearchRequest : PaginationRequest
    {
        [Required]
        public int? AreaId { get; set; }
        [Required]
        public string Filter { get; set; }
    }
}
