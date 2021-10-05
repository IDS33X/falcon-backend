using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;

namespace Util.Support.Requests.UserControl
{
    public class AddRangeUserControlRequest
    {
        public IEnumerable<UserControlDto> UserControls { get; set; }
    }
}
