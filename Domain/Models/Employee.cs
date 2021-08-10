using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int EmployeeRolId { get; set; }
        public EmployeeRol EmployeeRol { get; set; }
        public Division Division { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
    }
}