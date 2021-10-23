using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;
using Util.Dtos.ControlDtos;

namespace Util.Support.Requests.Control
{
    public class EditControlRequest
    {
        public ControlUpdateDto Control { get; set; }
    }
}
