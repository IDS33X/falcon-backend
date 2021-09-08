using System.Threading.Tasks;
using Util.Support.Requests.MRole;
using Util.Support.Responses.MRole;

namespace Service.Service
{
    public interface IMRoleService
    {
        Task<GetMRolesResponse> GetAll(GetMRolesRequest request);
    }
}
