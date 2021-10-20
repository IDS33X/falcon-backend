using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;

namespace Util.Support.Responses.MControlState
{
    public class GetControlStatesResponse
    {
        public IEnumerable<MControlStateDto> ControlStates { get; set; }
    }
}
