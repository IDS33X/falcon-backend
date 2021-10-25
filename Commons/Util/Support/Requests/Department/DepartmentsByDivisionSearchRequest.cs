using System.ComponentModel.DataAnnotations;

namespace Util.Support.Requests.Department
{
    public class DepartmentsByDivisionSearchRequest : PaginationRequest
    {
        [Required]
        public int? DivisionId { get; set; }
        [Required]
        public string Filter { get; set; }
    }
}