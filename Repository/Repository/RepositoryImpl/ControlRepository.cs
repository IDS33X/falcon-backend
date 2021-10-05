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
            var control = await context.Set<Control>().Where(c => c.Code == code).SingleOrDefaultAsync();

            if (control == null)
                throw new DoesNotExistException("Not exist");
            else
                return control;
        }

        public async Task<IEnumerable<Control>> GetControls(int page, int perPage)
        {
            return await context.Set<Control>()
                                 .Skip((page - 1) * perPage)
                                 .Take(perPage)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Control>> GetControlsByRisk(Guid riskId, int page, int perPage)
        {
            return await context.Set<Control>()
                                 .Where(c => c.Risks.Any(rc => rc.RiskId == riskId))
                                 .Skip((page - 1) * perPage)
                                 .Take(perPage)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Control>> GetControlsByUser(int userId, int page, int perPage)
        {
            return await context.Set<Control>()
                                 .Where(c => c.Users.Any(rc => rc.UserId == userId))
                                 .Skip((page - 1) * perPage)
                                 .Take(perPage)
                                 .ToListAsync();
        }

        public async Task<int> GetControlsCount()
        {
            return await context.Set<Control>().CountAsync();
        }
    }
}
