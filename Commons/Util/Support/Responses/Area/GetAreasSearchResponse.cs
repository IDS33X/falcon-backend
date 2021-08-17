using System.Collections.Generic;
using Util.Dtos;
using Util.Support.Response;

namespace Util.Support.Responses.Area
{
    public class GetAreasSearchResponse : PaginationResponse
    {
        public IEnumerable<AreaDto> Areas { get; set; }
    }
}
