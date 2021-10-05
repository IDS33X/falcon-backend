using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;
using Util.Support.Response;

namespace Util.Support.Responses.Control
{
    public class GetControlsByUserResponse : PaginationResponse
    {
        public IEnumerable<ControlDto> Controls { get; set; }
    }
}
