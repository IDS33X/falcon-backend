using System.ComponentModel.DataAnnotations;

namespace Util.Support.Requests.Control
{
    public class GetControlsByUserRequest : PaginationRequest
    {
        [Required]
        public int? UserId { get; set; }
    }
}
