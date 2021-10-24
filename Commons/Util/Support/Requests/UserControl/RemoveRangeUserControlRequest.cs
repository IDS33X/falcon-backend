using System.Collections.Generic;
using Util.Dtos.UserControl;

namespace Util.Support.Requests.UserControl
{
    public class RemoveRangeUserControlRequest
    {
        public IEnumerable<RemoveUserControlDto> UserControls { get; set; }
    }
}
