using System.Threading.Tasks;
using Util.Dtos;
using Util.Support.Requests.Employee;
using Util.Support.Responses.Employee;

namespace Service.Service
{
    public interface IEmployeeService
    {
        Task<AddEmployeeResponse> Add(AddEmployeeRequest request);
        Task<bool> Removed(int id);
        Task<EmployeeDto> GetById(int id);
        Task<EditEmployeeResponse> Update(EditEmployeeRequest request);
        Task<EmployeesByDepartmentResponse> GetEmployeesByDepartment(EmployeesByDepartmentRequest request);
        Task<EmployeesByDepartmentSearchResponse> GetEmployeesByDepartmentAndSearch(EmployeesByDepartmentSearchRequest request);
    }
}
