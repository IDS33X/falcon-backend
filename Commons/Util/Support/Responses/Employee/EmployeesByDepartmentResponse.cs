using System.Collections.Generic;
using Util.Dtos;
using Util.Support.Response;

namespace Util.Support.Responses.Employee
{
    public class EmployeesByDepartmentResponse : PaginationResponse
    {
        public IEnumerable<EmployeeDto> Employees { get; set; }
    }
}
