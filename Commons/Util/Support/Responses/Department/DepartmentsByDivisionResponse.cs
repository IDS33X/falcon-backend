using System.Collections.Generic;
using Util.Dtos;
using Util.Dtos.DepartmentDtos;
using Util.Support.Response;

namespace Util.Support.Responses.Department
{
    public class DepartmentsByDivisionResponse : PaginationResponse
    {
        public IEnumerable<DepartmentReadDto> Departments { get; set; }
    }
}
