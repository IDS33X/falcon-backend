using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Control
    {
        [Key]
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public string Frequency { get; set; }

        [Required]
        [MaxLength(50)]
        public string Code { get; set; }

        [Required]
        public bool Documented { get; set; }

        [Required]
        [MaxLength(500)]
        public string Policy { get; set; }

        [Required]
        [MaxLength(100)]
        public string ResponsiblePosition { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? LastUpdateDate { get; set; }

        [Required]
        [MaxLength(200)]
        public string Activity { get; set; }

        [Required]
        [MaxLength(100)]
        public string Ojective { get; set; }

        [Required]
        [MaxLength(200)]
        public string Evidence { get; set; }

        public int AutomationLevelId { get; set; }
        public MAutomationLevel AutomationLevel { get; set; }
        public int ControlStateId { get; set; }
        public MControlState ControlState { get; set; }
        public int ControlTypeId{ get; set; }
        public MControlType ControlType { get; set; }
        public int UserId { get; set; }
        public UserProfile User { get; set; }
        public IEnumerable<UserControl> Users { get; set; }

        public IEnumerable<RiskControl> Risks { get; set; }
    }
}
