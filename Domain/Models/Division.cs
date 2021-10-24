using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Division : BaseMaintenance
    {
        [Required]
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public int? UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        
    }
}