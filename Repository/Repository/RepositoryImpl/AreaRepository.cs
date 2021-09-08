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
    public class AreaRepository : GenericRepository<Area, int>, IAreaRepository
    {
        public AreaRepository(FalconDBContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Area>> GetAreas(int page, int perPage)
        {
            return await context.Set<Area>()
                                 .Skip((page - 1) * perPage)
                                 .Take(perPage)
                                 .ToListAsync();
        } 
        public async Task<IEnumerable<Area>> GetAreasSearch(string filter, int page, int perPage)
        {
            return await context.Set<Area>()
                                .Where(a => a.Name.Contains(filter))
                                .Skip((page - 1) * perPage)
                                .Take(perPage)
                                .ToListAsync();
        }

        public async Task<int> GetAreasCount()
        {
            return await context.Set<Area>().CountAsync();
        }
        public async Task<int> GetAreasSearchCount(string filter)
        {
            return await context.Set<Area>().CountAsync(a => a.Name.Contains(filter));
        }
    }
}
