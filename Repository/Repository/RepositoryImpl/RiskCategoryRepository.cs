using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryImpl;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Exceptions;

namespace Repository.Repository.RepositoryImpl
{
    public class RiskCategoryRepository : GenericRepository<RiskCategory, int>, IRiskCategoryRepository
    {
        public RiskCategoryRepository(DbContext context) : base(context)
        {

        }

        public new async Task<RiskCategory> Add(RiskCategory riskCategory)
        {
            var riskCategoryWithThatTitle = await context.Set<RiskCategory>().Where(rc => rc.Title == riskCategory.Title).FirstOrDefaultAsync();

            if (riskCategoryWithThatTitle != null)
            {
                throw new AlreadyExistException("A risk category with the title provided already exists");
            }

            await context.Set<RiskCategory>().AddAsync(riskCategory);

            return riskCategory;
        }

        public new async Task<RiskCategory> Update(RiskCategory riskCategory)
        {
            var riskCategoryBeforeUpdate = await context.Set<RiskCategory>().FirstOrDefaultAsync(r => r.Id == riskCategory.Id);

            if (riskCategoryBeforeUpdate == null)
            {
                throw new DoesNotExistException("Not exist");
            }

            if (riskCategory.Title != null)
            {
                var riskCategoryWithThatTitle = await context.Set<RiskCategory>().Where(rc => rc.Title == riskCategory.Title).FirstOrDefaultAsync();

                if (riskCategoryWithThatTitle != null && riskCategory.Id != riskCategoryWithThatTitle.Id)
                {
                    throw new AlreadyExistException("A risk category with the title provided already exists");
                }
            }

            riskCategoryBeforeUpdate.Title = riskCategory.Title ?? riskCategoryBeforeUpdate.Title;
            riskCategoryBeforeUpdate.Description = riskCategory.Description ?? riskCategoryBeforeUpdate.Description;

            await Task.Run( () => context.Set<RiskCategory>().Update(riskCategoryBeforeUpdate));

            return riskCategoryBeforeUpdate;
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
