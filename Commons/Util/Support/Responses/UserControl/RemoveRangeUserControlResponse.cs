using System.Collections.Generic;
using Util.Dtos.UserControl;

namespace Util.Support.Responses.UserControl
{
    public class RemoveRangeUserControlResponse
    {
        public IEnumerable<UserControlDto> UserControlsRemoved { get; set; }
        public IEnumerable<UserControlErrorDto> UserControlsNotRemoved { get; set; }
    }
}
