using System.ComponentModel.DataAnnotations;

namespace Util.Dtos.AreaDtos
{
    public class AreaCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
