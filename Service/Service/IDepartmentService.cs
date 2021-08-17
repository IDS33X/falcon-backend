using System.Threading.Tasks;
using Util.Dtos;
using Util.Support.Requests.Department;
using Util.Support.Responses;
using Util.Support.Responses.Department;

namespace Service.Service
{
    public interface IDepartmentService
    {
        Task<AddDepartmentResponse> Add(AddDepartmentRequest request);
        Task<bool> Removed(int id);
        Task<DepartmentDto> GetById(int id);
        Task<EditDepartmentResponse> Update(EditDepartmentRequest request);
        Task<DepartmentsByDivisionResponse> GetDepartmentsByDivision(DepartmentsByDivisionRequest request);
        Task<DepartmentsByDivisionSearchResponse> GetDepartmentsByDivisionAndSearch(DepartmentsByDivisionSearchRequest request);
    }
}
