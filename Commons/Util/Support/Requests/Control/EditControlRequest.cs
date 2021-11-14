using System.ComponentModel.DataAnnotations;
using Util.Dtos.ControlDtos;

namespace Util.Support.Requests.Control
{
    public class EditControlRequest
    {
        [Required]
        public ControlUpdateDto Control { get; set; }
    }
}
