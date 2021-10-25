using System.ComponentModel.DataAnnotations;

namespace Util.Support.Requests.Area
{
    public class GetAreasSearchRequest : PaginationRequest
    {
        [Required]
        public string Filter { get; set; }
    }
}
