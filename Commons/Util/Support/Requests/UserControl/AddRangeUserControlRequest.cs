using System.Collections.Generic;
using Util.Dtos.UserControl;

namespace Util.Support.Requests.UserControl
{
    public class AddRangeUserControlRequest
    {
        public IEnumerable<AddUserControlDto> UserControls { get; set; }
    }
}
