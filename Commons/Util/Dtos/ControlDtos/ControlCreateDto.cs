using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Dtos.ControlDtos
{
    public class ControlCreateDto
    {
        [Required]
        public int RiskCategoryId { get; set; }

        [Required]
        public int ControlStateId { get; set; }

        [Required]
        public int AutomationLevelId { get; set; }

        [Required]
        public int ControlTypeId { get; set; }

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
        public string ResponsablePosition { get; set; }

        [Required]
        [MaxLength(200)]
        public string Activity { get; set; }

        [Required]
        [MaxLength(100)]
        public string Objective { get; set; }

        [Required]
        [MaxLength(200)]
        public string Evidence { get; set; }

        [Required]
        public int UserId { get; set; }

    }
}
