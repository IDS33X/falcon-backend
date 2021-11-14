using System.ComponentModel.DataAnnotations;

namespace Util.Support.Requests.User
{
    public class UsersByDepartmentSearchRequest : PaginationRequest
    {
        [Required]
        public int? DepartmentId { get; set; }
        [Required]
        public string Filter { get; set; }
    }
}
