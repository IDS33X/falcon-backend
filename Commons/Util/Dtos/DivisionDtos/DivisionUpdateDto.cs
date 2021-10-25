using System.ComponentModel.DataAnnotations;

namespace Util.Dtos.DivisionDtos
{
    public class DivisionUpdateDto
    {
        [Required]
        public int? Id { get; set; }
        public int? UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        
    }
}
