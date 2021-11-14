using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Util.Dtos.UserControl;

namespace Util.Support.Requests.UserControl
{
    public class RemoveRangeUserControlRequest
    {
        [Required]
        public IEnumerable<RemoveUserControlDto> UserControls { get; set; }
    }
}
