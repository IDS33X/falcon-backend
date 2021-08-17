using System.Collections.Generic;
using Util.Dtos;

namespace Util.Support.Responses.EmployeeRol
{
    public class GetEmployeeRolsResponse
    {
        public IEnumerable<EmployeeRolDto> EmployeeRols { get; set; }
    }
}
