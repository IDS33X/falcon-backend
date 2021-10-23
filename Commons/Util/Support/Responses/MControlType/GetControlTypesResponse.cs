using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;
using Util.Dtos.ControlTypeDtos;

namespace Util.Support.Responses.MControlType
{
    public class GetControlTypesResponse
    {
        public IEnumerable<MControlTypeReadDto> ControlTypes { get; set; }
    }
}
