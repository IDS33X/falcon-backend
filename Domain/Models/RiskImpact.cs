using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class RiskImpact
    {
        [Key]
        public int Id { get; set; }
        public int ImpactTypeId { get; set; }
        public ImpactType ImpactType { get; set; }
        public int Severity { get; set; }
        public int Probability { get; set; }
        public IEnumerable<Risk> Risks { get; set; }
    }
}
