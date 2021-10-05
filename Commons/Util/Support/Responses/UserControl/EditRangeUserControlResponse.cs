using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;

namespace Util.Support.Responses.UserControl
{
    public class EditRangeUserControlResponse
    {
        public IEnumerable<UserControlDto> UserControls { get; set; }
    }
}
