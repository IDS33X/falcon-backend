using System.Collections.Generic;
using Util.Dtos;
using Util.Dtos.DivisionDtos;
using Util.Support.Response;

namespace Util.Support.Responses.Division
{
    public class DivisionsByAreaSearchResponse : PaginationResponse
    {
        public IEnumerable<DivisionReadDto> Divisions { get; set; }
    }
}