using System.Collections.Generic;
using Util.Dtos.User;
using Util.Support.Response;

namespace Util.Support.Responses.User
{
    public class UsersByDepartmentResponse : PaginationResponse
    {
        public IEnumerable<UserDto> Users { get; set; }
    }
}
