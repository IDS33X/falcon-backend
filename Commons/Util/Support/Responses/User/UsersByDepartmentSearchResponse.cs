using System.Collections.Generic;
using Util.Dtos;
using Util.Support.Response;

namespace Util.Support.Responses.User
{
    public class UsersByDepartmentSearchResponse : PaginationResponse
    {
        public IEnumerable<UserDto> Users { get; set; }
    }
}
