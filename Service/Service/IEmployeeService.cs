using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Dtos;

namespace Service.Service
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> Add(EmployeeDto employeeDto);
        Task<bool> Removed(int id);
        Task<EmployeeDto> GetById(int id);
        Task<IEnumerable<EmployeeDto>> GetAll();
        Task<bool> Update(EmployeeDto employeeDto);
    }
}
