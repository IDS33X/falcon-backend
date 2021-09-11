using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IRiskCategoryRepository : IGenericRepository<RiskCategory, int>
    {
        Task<IEnumerable<RiskCategory>> GetRiskCategoriesByDepartment(int departmentId, int page, int perPage);
        Task<IEnumerable<RiskCategory>> GetRiskCategoriesByDepartmentSearch(int departmentId, string filter, int page, int perPage);
        Task<int> GetRiskCategoriesCountByDepartment(int departmentId);
        Task<int> GetRiskCategoriesCountByDepartmentSearch(int departmentId, string filter);
    }
}
