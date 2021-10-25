using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IDepartmentRepository : IGenericRepository<Department, int>
    {
        Task<IEnumerable<Department>> GetDepartmentsByDivision(int? divisionId, int page, int perPage);
        Task<int> GetDepartmentsByDivisionCount(int? divisionId);
        Task<IEnumerable<Department>> GetDepartmentsByDivisionSearch(int? divisionId, string filter, int page, int perPage);
        Task<int> GetDepartmentsByDivisionSearchCount(int? divisionId, string filter);
    }
}
