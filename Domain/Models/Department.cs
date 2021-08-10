using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public int DivisionId { get; set; }
        public Division Division { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}