using System.ComponentModel.DataAnnotations;

namespace Util.Dtos.AreaDtos
{
    public class AreaUpdateDto
    {
        [Required]
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
