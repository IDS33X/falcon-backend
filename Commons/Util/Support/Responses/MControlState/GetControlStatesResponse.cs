using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;
using Util.Dtos.ControlStateDtos;

namespace Util.Support.Responses.MControlState
{
    public class GetControlStatesResponse
    {
        public IEnumerable<MControlStateReadDto> ControlStates { get; set; }
    }
}
