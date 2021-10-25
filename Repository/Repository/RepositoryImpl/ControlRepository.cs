using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.RepositoryImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Exceptions;

namespace Repository.Repository.RepositoryImpl
{
    public class ControlRepository : GenericRepository<Control, Guid>, IControlRepository
    {
        public ControlRepository(FalconDBContext context) : base(context)
        {

        }

        public async Task<Control> GetControlByCode(string code)
        {
            var control = await context.Set<Control>()
                                       .Include(c => c.User)
                                       .Include(c => c.AutomationLevel)
                                       .Include(c => c.ControlState)
                                       .Include(c => c.ControlType)
                                       .Where(c => c.Code == code)
                                       .SingleOrDefaultAsync();

            if (control == null)
                throw new DoesNotExistException("Not exist");
            else
                return control;
        }

        public async Task<IEnumerable<Control>> GetControls(int page, int perPage)
        {
            return await context.Set<Control>()
                                 .Include(c => c.User)
                                 .Include(c => c.AutomationLevel)
                                 .Include(c => c.ControlState)
                                 .Include(c => c.ControlType)
                                 .Skip((page - 1) * perPage)
                                 .Take(perPage)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Control>> GetControlsByRisk(Guid? riskId, int page, int perPage)
        {
            return await context.Set<Control>()
                                 .Include(c => c.User)
                                 .Include(c => c.AutomationLevel)
                                 .Include(c => c.ControlState)
                                 .Include(c => c.ControlType)
                                 .Where(c => c.Risks.Any(rc => rc.RiskId == riskId && rc.DeallocatedDate == null))
                                 .Skip((page - 1) * perPage)
                                 .Take(perPage)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Control>> GetControlsByUser(int? userId, int page, int perPage)
        {
            return await context.Set<Control>()
                                 .Include(c => c.User)
                                 .Include(c => c.AutomationLevel)
                                 .Include(c => c.ControlState)
                                 .Include(c => c.ControlType)
                                 .Where(c => c.Users.Any(rc => rc.UserId == userId && rc.DeallocatedDate == null))
                                 .Skip((page - 1) * perPage)
                                 .Take(perPage)
                                 .ToListAsync();
        }

        public new async Task<Control> GetById(Guid id)
        {
            return await context.Set<Control>().Include(c => c.User)
                                 .Include(c => c.AutomationLevel)
                                 .Include(c => c.ControlState)
                                 .Include(c => c.ControlType)
                                 .Where(c => c.Id == id)
                                 .SingleOrDefaultAsync();
        }

        public new async Task<Control> Update(Control control)
        {
            var previousControl = await context.Set<Control>()
                                 .Include(c => c.User)
                                 .Include(c => c.AutomationLevel)
                                 .Include(c => c.ControlState)
                                 .Include(c => c.ControlType)
                                 .FirstOrDefaultAsync(c => c.Id == control.Id);

            if(control.ControlStateId != 0 && control.ControlStateId != previousControl.ControlStateId)
            {
                previousControl.ControlStateId = control.ControlStateId;
                previousControl.ControlState = await context.Set<MControlState>().FindAsync(previousControl.ControlStateId);
            }

            if (control.AutomationLevelId != 0 && control.AutomationLevelId != previousControl.AutomationLevelId)
            {
                previousControl.AutomationLevelId = control.AutomationLevelId;
                previousControl.AutomationLevel = await context.Set<MAutomationLevel>().FindAsync(previousControl.AutomationLevelId);
            }

            if (control.ControlTypeId != 0 && control.ControlTypeId != previousControl.ControlTypeId)
            {
                previousControl.ControlTypeId = control.ControlTypeId;
                previousControl.ControlType = await context.Set<MControlType>().FindAsync(previousControl.ControlTypeId);
            }

            if (control.UserId != 0 && control.UserId != previousControl.UserId)
            {
                previousControl.UserId = control.UserId;
                previousControl.User = await context.Set<UserProfile>().FindAsync(previousControl.UserId);
            }

            if (control.Documented != previousControl.Documented )
                previousControl.Documented = control.Documented;
 

            previousControl.Frequency = control.Frequency ?? previousControl.Frequency;
            previousControl.Code = control.Code ?? previousControl.Code;
            previousControl.Policy = control.Policy ?? previousControl.Policy;
            previousControl.ResponsablePosition = control.ResponsablePosition ?? previousControl.ResponsablePosition;
            previousControl.Activity = control.Activity ?? previousControl.Activity;
            previousControl.Objective = control.Objective ?? previousControl.Objective;
            previousControl.Evidence = control.Evidence ?? previousControl.Evidence;

            await Task.Run(() => context.Set<Control>().Update(previousControl));

            return previousControl;
        }

        public async Task<int> GetControlsCount()
        {
            return await context.Set<Control>().CountAsync();
        }

        public async Task<int> GetControlsByRiskCount(Guid? riskId)
        {
            return await context.Set<Control>().CountAsync(c => c.Risks.Any(rc => rc.RiskId == riskId));
        }

        public async Task<int> GetControlsByUserCount(int? userId)
        {
            return await context.Set<Control>().CountAsync(c => c.Users.Any(rc => rc.UserId == userId));
        }

        public async Task<IEnumerable<Control>> GetControlsByCodeSearch(int? riskCategoryId, string filter, int page, int perPage)
        {
            return await context.Set<Control>()
                                .Include(c => c.User)
                                .Include(c => c.AutomationLevel)
                                .Include(c => c.ControlState)
                                .Include(c => c.ControlType)
                                .Where(c => c.RiskCategoryId == riskCategoryId && c.Code.Contains(filter))
                                .Skip((page - 1) * perPage)
                                .Take(perPage)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Control>> GetControlsByRiskCategory(int? riskCategoryId,int page, int perPage)
        {
            return await context.Set<Control>()
                                .Include(c => c.User)
                                .Include(c => c.AutomationLevel)
                                .Include(c => c.ControlState)
                                .Include(c => c.ControlType)
                                .Where(c => c.RiskCategoryId == riskCategoryId )
                                .Skip((page - 1) * perPage)
                                .Take(perPage)
                                .ToListAsync();
        }

        public async Task<int> GetControlsByCodeSearchCount(int? riskCategoryId, string filter)
        {
            int count = await context.Set<Control>().CountAsync(c => c.RiskCategoryId == riskCategoryId && c.Code.Contains(filter));
            return count;
        }

        public async Task<int> GetControlsByRiskCategoryCount(int? riskCategoryId)
        {
            int count = await context.Set<Control>().CountAsync(c => c.RiskCategoryId == riskCategoryId);
            return count;
        }
    }
}
