using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryImpl;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository.RepositoryImpl
{
    public class RiskCategoryRepository : GenericRepository<RiskCategory, int>, IRiskCategoryRepository
    {
        public RiskCategoryRepository(DbContext context) : base(context)
        {

        }

        public async Task<int> GetRiskCategoriesCountByDepartment(int departmentId)
        {
            int count = await context.Set<RiskCategory>().CountAsync(r => r.DepartmentId == departmentId);
            return count;
        }
        public async Task<int> GetRiskCategoriesCountByDepartmentSearch(int departmentId, string filter)
        {
            int count = await context.Set<RiskCategory>().CountAsync(r => r.DepartmentId == departmentId && r.Title.Contains(filter));
            return count;
        }
        public async Task<IEnumerable<RiskCategory>> GetRiskCategoriesByDepartment(int departmentId, int page, int perPage)
        {
            return await context.Set<RiskCategory>()
                                 .Where(r => r.DepartmentId == departmentId)
                                 .Skip((page - 1) * perPage)
                                 .Take(perPage)
                                 .ToListAsync();
        }
        public async Task<IEnumerable<RiskCategory>> GetRiskCategoriesByDepartmentSearch(int departmentId, string filter, int page, int perPage)
        {
            return await context.Set<RiskCategory>()
                                .Where(r => r.DepartmentId == departmentId && r.Title.Contains(filter))
                                .Skip((page - 1) * perPage)
                                .Take(perPage)
                                .ToListAsync();
        }
    }
}
