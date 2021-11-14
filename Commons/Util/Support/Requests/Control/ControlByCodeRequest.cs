using System.ComponentModel.DataAnnotations;

namespace Util.Support.Requests.Control
{
    public class ControlByCodeRequest
    {
        [Required]
        public string Code { get; set; }
    }
}
