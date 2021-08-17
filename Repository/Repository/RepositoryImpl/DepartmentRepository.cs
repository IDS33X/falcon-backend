using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryImpl;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository.RepositoryImpl
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DbContext context) : base(context)
        {
        }
        public async Task<int> GetDepartmentsByDivisionCount(int divisionId)
        {
            int count = await context.Set<Department>().CountAsync(d => d.DivisionId == divisionId);
            return count;
        }
        public async Task<int> GetDepartmentsByDivisionSearchCount(int divisionId, string filter)
        {
            int count = await context.Set<Department>().CountAsync(d => d.DivisionId == divisionId && d.Name.Contains(filter));
            return count;
        }
        public async Task<IEnumerable<Department>> GetDepartmentsByDivision(int divisionId, int page, int perPage)
        {
            return await context.Set<Department>()
                                 .Where(d => d.DivisionId == divisionId)
                                 .Skip((page - 1) * perPage)
                                 .Take(perPage)
                                 .ToListAsync();
        }
        public async Task<IEnumerable<Department>> GetDepartmentsByDivisionSearch(int divisionId, string filter, int page, int perPage)
        {
            return await context.Set<Department>()
                                .Where(d => d.DivisionId == divisionId && d.Name.Contains(filter))
                                .Skip((page - 1) * perPage)
                                .Take(perPage)
                                .ToListAsync();
        }
    }
}
