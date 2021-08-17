using System.Collections.Generic;

namespace Util.Dtos
{
    public class DivisionDto
    {
        public int DivisionId { get; set; }
        public int AreaId { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeDto Employee { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CountDepartments { get; set; }

    }
}
