using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Division
    {
        [Key]
        public int DivisionId { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        
    }
}