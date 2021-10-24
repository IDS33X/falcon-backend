using System.Collections.Generic;
using Util.Dtos.MRole;

namespace Util.Support.Responses.MRole
{
    public class GetMRolesResponse
    {
        public IEnumerable<MRoleDto> Roles { get; set; }
    }
}
