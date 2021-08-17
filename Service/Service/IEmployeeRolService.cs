using System.Threading.Tasks;
using Util.Support.Requests.EmployeeRol;
using Util.Support.Responses.EmployeeRol;

namespace Service.Service
{
    public interface IEmployeeRolService
    {
        Task<GetEmployeeRolsResponse> GetAll(GetEmployeeRolsRequest request);
    }
}
