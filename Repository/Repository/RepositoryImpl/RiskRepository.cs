using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Exceptions;

namespace Repository.Repository.RepositoryImpl
{
    public class RiskRepository : GenericRepository<Risk, Guid>, IRiskRepository
    {
        public RiskRepository(DbContext context) : base(context)
        {
        }

        public new async Task<Risk> GetById(Guid id)
        {
            var risk = await context.Set<Risk>()
                                    .Include(r => r.User)
                                    .Include(r => r.InherentRisk)
                                    .Include(r => r.ControlledRisk)
                                    .FirstOrDefaultAsync(r => r.Id == id);

            if (risk == null)
            {
                throw new DoesNotExistException("Not exist");
            }
            else
            {
                return risk;
            }
        }

        public async Task<IEnumerable<Risk>> GetRisksByCategory(int page, int perPage, int riskCategoryId)
        {
            return await context.Set<Risk>().Where(r => r.RiskCategoryId == riskCategoryId)
                                .Include(r => r.User)
                                .Include(r => r.InherentRisk)
                                .Include(r => r.ControlledRisk)
                                .Skip((page - 1) * perPage)
                                .Take(perPage)
                                .ToListAsync();
        }
        public async Task<IEnumerable<Risk>> GetRiskByCategoryAndCode(string filter, int page, int perPage, int riskCategoryId)
        {
            return await context.Set<Risk>()
                                .Where(r => r.RiskCategoryId == riskCategoryId && r.Code.Contains(filter))
                                .Include(r => r.User)
                                .Include(r => r.InherentRisk)
                                .Include(r => r.ControlledRisk)
                                .Skip((page - 1) * perPage)
                                .Take(perPage)
                                .ToListAsync();
        }  
        public async Task<IEnumerable<Risk>> GetRiskByCategoryAndDescription(string filter, int page, int perPage, int riskCategoryId)
        {
            return await context.Set<Risk>()
                                .Where(r => r.RiskCategoryId == riskCategoryId && r.Description.Contains(filter))
                                .Include(r => r.User)
                                .Include(r => r.InherentRisk)
                                .Include(r => r.ControlledRisk)
                                .Skip((page - 1) * perPage)
                                .Take(perPage)
                                .ToListAsync();
        }

        public async Task<int> GetRiskByCategoryCount(int riskCategoryId)
        {
            return await context.Set<Risk>().CountAsync(r => r.RiskCategoryId == riskCategoryId);
        }

        public async Task<int> GetRiskByCategoryAndCodeCount(string filter, int riskCategoryId)
        {
            return await context.Set<Risk>().CountAsync(r => r.RiskCategoryId == riskCategoryId && r.Code.Contains(filter));
        }

        public async Task<int> GetRiskByCategoryAndDescriptionCount(string filter, int riskCategoryId)
        {
            return await context.Set<Risk>().CountAsync(r => r.RiskCategoryId == riskCategoryId && r.Description.Contains(filter));
        }
    }
}
