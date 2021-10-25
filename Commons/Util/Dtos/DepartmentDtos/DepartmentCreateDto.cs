using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Dtos.DepartmentDtos
{
    public class DepartmentCreateDto
    {
        [Required]
        public int? DivisionId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
