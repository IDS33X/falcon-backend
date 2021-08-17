using System.Collections.Generic;
using Util.Dtos;
using Util.Support.Response;

namespace Util.Support.Responses.Department
{
    public class DepartmentsByDivisionResponse : PaginationResponse
    {
        public IEnumerable<DepartmentDto> Departments { get; set; }
    }
}
