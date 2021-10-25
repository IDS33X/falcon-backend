using System.ComponentModel.DataAnnotations;

namespace Util.Support.Requests.Department
{
    public class DepartmentsByDivisionRequest : PaginationRequest
    {
        [Required]
        public int? DivisionId { get; set; }
    }
}
