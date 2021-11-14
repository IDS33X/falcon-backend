using System.ComponentModel.DataAnnotations;
using Util.Dtos.DepartmentDtos;

namespace Util.Support.Requests.Department
{
    public class AddDepartmentRequest
    {
        [Required]
        public DepartmentCreateDto Department { get; set; }
    }
}
