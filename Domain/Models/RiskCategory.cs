using System.Collections.Generic;

namespace Domain.Models
{
    public class RiskCategory : BaseMaintenance
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public IEnumerable<Risk> Risks { get; set; }
        public IEnumerable<Control> Controls { get; set; }
    }
}
