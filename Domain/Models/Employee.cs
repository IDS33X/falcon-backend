using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Employee
    {
        public Employee(int employeeId, int departmentId, Department department, int employeeRolId, EmployeeRol employeeRol, Division division, string name, string lastName, string code, string password)
        {
            EmployeeId = employeeId;
            DepartmentId = departmentId;
            Department = department;
            EmployeeRolId = employeeRolId;
            EmployeeRol = employeeRol;
            Division = division;
            Name = name;
            LastName = lastName;
            Code = code;
            Password = password;
        }

        public Employee(){}

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