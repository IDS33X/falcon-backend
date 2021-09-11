using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Area : BaseMaintenance
    {   
        public IEnumerable<Division> Divisions { get; set; }
    }
}
