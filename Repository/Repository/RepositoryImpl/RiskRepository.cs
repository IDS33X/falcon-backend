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

        public new async Task<Risk> Add(Risk risk)
        {
            var riskDbSet = context.Set<Risk>();

            var riskWithThatCode = await riskDbSet.Where(r => r.Code == risk.Code).FirstOrDefaultAsync();

            if (riskWithThatCode != null)
            {
                throw new AlreadyExistException("A risk with that code already exists");
            }

            await context.Set<Risk>().AddAsync(risk);
            return risk;
        }

        public new async Task<Risk> Update(Risk risk)
        {
            var riskBeforeUpdate = await context.Set<Risk>()
                        .Include(r => r.User)
                        .Include(r => r.InherentRisk)
                        .ThenInclude(ir => ir.ImpactType)
                        .Include(r => r.ControlledRisk)
                        .ThenInclude(cr => cr.ImpactType)
                        .Where(r => r.Id == risk.Id)
                        .FirstOrDefaultAsync();

            if (riskBeforeUpdate == null)
            {
                throw new DoesNotExistException("Risk Not exist");
            }

            riskBeforeUpdate.Description = risk.Description ?? riskBeforeUpdate.Description;
            riskBeforeUpdate.RootCause = risk.RootCause ?? riskBeforeUpdate.RootCause;

            if (risk.InherentRiskId != 0 && riskBeforeUpdate.InherentRiskId != risk.InherentRiskId)
            {
                var newInherentRisk = await context.Set<RiskImpact>()
                                                   .Include(ir => ir.ImpactType)
                                                   .Where(ir => ir.Id == risk.InherentRiskId)
                                                   .FirstOrDefaultAsync();

                riskBeforeUpdate.InherentRisk = newInherentRisk ?? throw new DoesNotExistException("Inherent Risk Not exist");
                riskBeforeUpdate.InherentRiskId = risk.InherentRiskId;
            }

            if (risk.ControlledRiskId != 0 && riskBeforeUpdate.ControlledRiskId != risk.ControlledRiskId)
            {
                var newControlledRisk = await context.Set<RiskImpact>()
                                                   .Include(cr => cr.ImpactType)
                                                   .Where(cr => cr.Id == risk.InherentRiskId)
                                                   .FirstOrDefaultAsync();

                riskBeforeUpdate.ControlledRisk = newControlledRisk ?? throw new DoesNotExistException("Controlled Risk Not exist");
                riskBeforeUpdate.ControlledRiskId = risk.InherentRiskId;
            }

            await Task.Run(() =>  context.Set<Risk>().Update(riskBeforeUpdate));

            return riskBeforeUpdate;
        }

        public new async Task<Risk> GetById(Guid id)
        {
            var risk = await context.Set<Risk>()
                                    .Include(r => r.User)
                                    .Include(r => r.InherentRisk)
                                    .ThenInclude(ir => ir.ImpactType)
                                    .Include(r => r.ControlledRisk)
                                    .ThenInclude(cr => cr.ImpactType)
                                    .Where(r => r.Id == id)
                                    .FirstOrDefaultAsync();

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
            return await context.Set<Risk>()
                                .Where(r => r.RiskCategoryId == riskCategoryId)
                                .Include(r => r.User)
                                .Include(r => r.InherentRisk)
                                .ThenInclude(ir => ir.ImpactType)
                                .Include(r => r.ControlledRisk)
                                .ThenInclude(cr => cr.ImpactType)
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
                                .ThenInclude(ir => ir.ImpactType)
                                .Include(r => r.ControlledRisk)
                                .ThenInclude(cr => cr.ImpactType)
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
                                .ThenInclude(ir => ir.ImpactType)
                                .Include(r => r.ControlledRisk)
                                .ThenInclude(cr => cr.ImpactType)
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
