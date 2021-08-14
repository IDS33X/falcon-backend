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
    public class AreaRepository : GenericRepository<Area>, IAreaRepository
    {
        public AreaRepository(FalconDBContext context) : base(context)
        {

        }

        public async Task<int> GetDivisionsCount(int areaId)
        {
            int count = await context.Set<Division>().CountAsync(d => d.AreaId == areaId);
            return count;
        }
    }
}
