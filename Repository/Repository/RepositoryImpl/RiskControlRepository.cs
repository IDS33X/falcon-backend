using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.RepositoryImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.RepositoryImpl
{
    public class RiskControlRepository : GenericRepository<RiskControl,int> , IRiskControlRepository
    {
        public RiskControlRepository(FalconDBContext context): base(context)
        {

        }

        public async Task<IEnumerable<RiskControl>> AddRange(IEnumerable<RiskControl> risksControls)
        {
            await context.Set<RiskControl>().AddRangeAsync(risksControls);
            return risksControls;
        }

        public async Task<IEnumerable<RiskControl>> UpdateRange(IEnumerable<RiskControl> risksControls)
        {
            await Task.Run(() => context.Set<RiskControl>().UpdateRange(risksControls));
            return risksControls;
        }
    }
}
