using System.ComponentModel.DataAnnotations;

namespace Util.Support.Requests.User
{
    public class UsersByDepartmentRequest : PaginationRequest
    {
        [Required]
        public int? DepartmentId { get; set; }
    }
}
