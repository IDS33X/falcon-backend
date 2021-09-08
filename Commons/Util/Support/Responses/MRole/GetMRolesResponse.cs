using System.Collections.Generic;
using Util.Dtos;

namespace Util.Support.Responses.MRole
{
    public class GetMRolesResponse
    {
        public IEnumerable<MRoleDto> Roles { get; set; }
    }
}
