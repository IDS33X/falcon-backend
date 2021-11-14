using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Util.Dtos.UserControl;

namespace Util.Support.Requests.UserControl
{
    public class AddRangeUserControlRequest
    {
        [Required]
        public IEnumerable<AddUserControlDto> UserControls { get; set; }
    }
}
