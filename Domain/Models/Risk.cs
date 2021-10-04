using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Risk
    {
        [Key]
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public UserProfile User { get; set; }
        public int RiskCategoryId { get; set; }
        public RiskCategory RiskCategory { get; set; }
        public int InherentRiskId { get; set; }
        public RiskImpact InherentRisk { get; set; }
        public int ControlledRiskId { get; set; }
        public RiskImpact ControlledRisk { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Code { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string RootCause { get; set; }

        public IEnumerable<RiskControl> Controls { get; set; }
    }
}
