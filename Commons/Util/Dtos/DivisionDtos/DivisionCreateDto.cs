using System.ComponentModel.DataAnnotations;

namespace Util.Dtos.DivisionDtos
{
    public class DivisionCreateDto
    {
        [Required]
        public int? AreaId { get; set; }

        
        public int? UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
