using System.ComponentModel.DataAnnotations;

namespace Util.Dtos.User
{
    public class UpdateUserPasswordDto
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
