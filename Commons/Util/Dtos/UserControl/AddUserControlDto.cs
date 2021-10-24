using System;
using System.ComponentModel.DataAnnotations;

namespace Util.Dtos.UserControl
{
    public class AddUserControlDto
    {
        [Required]
        public int? UserId { get; set; }
        [Required]
        public Guid? ControlId { get; set; }
    }
}
