using System.ComponentModel.DataAnnotations;
using Util.Dtos.UserControl;

namespace Util.Support.Requests.UserControl
{
    public class AddUserControlRequest
    {
        [Required]
        public AddUserControlDto UserControl { get; set; }
    }
}
