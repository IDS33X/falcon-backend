using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Department
    {
        public Department(int departmentId, int divisionId, Division division, string name, string description, IEnumerable<Employee> employees)
        {
            DepartmentId = departmentId;
            DivisionId = divisionId;
            Division = division;
            Name = name;
            Description = description;
            Employees = employees;
        }

        public Department(){}

        [Key]
        public int DepartmentId { get; set; }
        public int DivisionId { get; set; }
        public Division Division { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}