using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Repository.Repository
{
    public interface IEmployeeRepository : IGenericRepository<Employee,int>
    {
         Task<Employee> FindByCode(string code);
        Task<IEnumerable<Employee>> GetEmployeesByDepartment(int departmentId, int page, int perPage);
        Task<int> GetEmployeesByDepartmentCount(int departmentId);
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentSearch(int departmentId, string filter, int page, int perPage);
        Task<int> GetEmployeesByDepartmentSearchCount(int departmentId, string filter);
    }
}