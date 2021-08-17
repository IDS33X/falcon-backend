using System.Collections.Generic;
using Util.Dtos;
using Util.Support.Response;

namespace Util.Support.Responses.Division
{
    public class DivisionsByAreaSearchResponse : PaginationResponse
    {
        public IEnumerable<DivisionDto> Divisions { get; set; }
    }
}