using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Area
    {
        [Key]
        public int AreaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Division> Divisions { get; set; }
    }
}
