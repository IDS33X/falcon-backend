using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.RepositoryImpl;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Exceptions;

namespace Repository.Repository.RepositoryImpl
{
    public class DivisionRepository : GenericRepository<Division>, IDivisionRepository
    {
        public DivisionRepository(FalconDBContext context) : base(context)
        {

        }

        public async Task<int> GetDivisionsByAreaSearchCount(int areaId)
        {
            int count = await context.Set<Division>().CountAsync(d => d.AreaId == areaId);
            return count;
        }  
        public async Task<int> GetDivisionsByAreaSearchCount(int areaId, string filter)
        {
            int count = await context.Set<Division>().CountAsync(d => d.AreaId == areaId && d.Name.Contains(filter));
            return count;
        }

        public new async Task<Division> GetById(int id)
        {
            Division division = await context.Set<Division>().Include(d => d.Employee).SingleOrDefaultAsync(e => e.DivisionId == id);

            if (division == null)
            {
                throw new DoesNotExistException("Not exist");
            }
            else
            {
                return division;
            }
        }
        public async Task<IEnumerable<Division>> GetDivisionsByArea(int areaId, int page, int perPage)
        {
            return await context.Set<Division>()
                                 .Where(d => d.AreaId == areaId)
                                 .Include(d => d.Employee)
                                 .Skip((page - 1) * perPage)
                                 .Take(perPage)
                                 .ToListAsync();
        }  
        public async Task<IEnumerable<Division>> GetDivisionsByAreaSearch(int areaId, string filter, int page, int perPage)
        {
            return await context.Set<Division>()
                                .Where(d => d.AreaId == areaId && d.Name.Contains(filter))
                                .Include(d => d.Employee)
                                .Skip((page - 1) * perPage)
                                .Take(perPage)
                                .ToListAsync();
        }
    }
}
