using System.ComponentModel.DataAnnotations;
using Util.Dtos.ControlDtos;

namespace Util.Support.Requests.Control
{
    public class AddControlRequest
    {
        [Required]
        public ControlCreateDto Control { get; set; }
    }
}
