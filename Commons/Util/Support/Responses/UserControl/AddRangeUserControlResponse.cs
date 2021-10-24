using System.Collections.Generic;
using Util.Dtos.UserControl;

namespace Util.Support.Responses.UserControl
{
    public class AddRangeUserControlResponse
    {
        public IEnumerable<UserControlDto> UserControlsAdded { get; set; }
        public IEnumerable<UserControlErrorDto> UsersControlsNotAdded { get; set; }
    }
}
