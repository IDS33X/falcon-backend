using System.ComponentModel.DataAnnotations;

namespace Util.Support.Requests
{
    public class LogInRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}