using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class EmployeeRol
    {
        public EmployeeRol(int employeeRolId, string name, IEnumerable<Employee> employees)
        {
            EmployeeRolId = employeeRolId;
            Name = name;
            Employees = employees;
        }

        public EmployeeRol(){}

        [Key]
        public int EmployeeRolId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}