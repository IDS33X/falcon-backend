using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;

namespace Util.Support.Responses.MControlType
{
    public class GetControlTypesResponse
    {
        public IEnumerable<MControlTypeDto> ControlTypes { get; set; }
    }
}
