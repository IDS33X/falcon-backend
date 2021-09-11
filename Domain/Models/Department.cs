using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Department : BaseMaintenance
    {
        public int DivisionId { get; set; }
        public Division Division { get; set; }
        public IEnumerable<UserProfile> UserProfiles { get; set; }
        public IEnumerable<RiskCategory> RiskCategories { get; set; }
    }
}