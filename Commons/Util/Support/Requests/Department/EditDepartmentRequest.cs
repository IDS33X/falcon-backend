using System.ComponentModel.DataAnnotations;
using Util.Dtos.DepartmentDtos;

namespace Util.Support.Requests.Department
{
    public class EditDepartmentRequest
    {
        [Required]
        public DepartmentUpdateDto Department { get; set; }
    }
}
