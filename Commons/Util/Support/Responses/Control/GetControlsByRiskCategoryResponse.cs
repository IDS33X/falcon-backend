using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos.ControlDtos;
using Util.Support.Response;

namespace Util.Support.Responses.Control
{
    public class GetControlsByRiskCategoryResponse : PaginationResponse
    {
        public IEnumerable<ControlReadDto> Controls { get; set; }
    }
}
