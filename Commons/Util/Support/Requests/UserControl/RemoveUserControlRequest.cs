using System.ComponentModel.DataAnnotations;
using Util.Dtos.UserControl;

namespace Util.Support.Requests.UserControl
{
    public class RemoveUserControlRequest
    {
        [Required]
        public RemoveUserControlDto UserControl { get; set; }
    }
}
