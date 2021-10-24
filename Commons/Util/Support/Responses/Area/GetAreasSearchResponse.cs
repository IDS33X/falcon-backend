using System.Collections.Generic;
using Util.Dtos;
using Util.Dtos.AreaDtos;
using Util.Support.Response;

namespace Util.Support.Responses.Area
{
    public class GetAreasSearchResponse : PaginationResponse
    {
        public IEnumerable<AreaReadDto> Areas { get; set; }
    }
}
