using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Area
    {
        public Area(int areaId, string name, string description, IEnumerable<Division> divisions)
        {
            AreaId = areaId;
            Name = name;
            Description = description;
            Divisions = divisions;
        }

        public Area(){}

        [Key]
        public int AreaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Division> Divisions { get; set; }
    }
}
