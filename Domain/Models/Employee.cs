using System.Collections.Generic;

namespace Domain.Models
{
    public class Employee
    {
        //Testing purpose constructor
        public Employee(int EmployeeId,string Name,string Lastname,string Code,string Password){
            this.EmployeeId = EmployeeId;
            this.Name = Name;
            this.Lastname = Lastname;
            this.Code = Code;
            this.Password = Password;
        }

        public Employee(){

        }

        //Props
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
        public int DepartmentId { get; set; }
        //public Department Department { get; set; }
        //public int EmployeeRolId { get; set; }
        //public EmployeeRol EmployeeRol { get; set; }
        //public Division Division { get; set; }
        //public IEnumerable<Evaluation> Evaluations { get; set; }
        //public IEnumerable<EmployeeControls> EmployeeControls { get; set; }

    }
}