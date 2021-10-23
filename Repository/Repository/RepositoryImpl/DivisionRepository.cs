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
    public class DivisionRepository : GenericRepository<Division, int>, IDivisionRepository
    {
        public DivisionRepository(FalconDBContext context) : base(context)
        {

        }

        public async Task<int> GetDivisionsByAreaCount(int areaId)
        {
            int count = await context.Set<Division>().CountAsync(d => d.AreaId == areaId);
            return count;
        }  
        public async Task<int> GetDivisionsByAreaSearchCount(int areaId, string filter)
        {
            int count = await context.Set<Division>().CountAsync(d => d.AreaId == areaId && d.Title.Contains(filter));
            return count;
        }

        public new async Task<Division> GetById(int id)
        {
            Division division = await context.Set<Division>().Include(d => d.UserProfile).SingleOrDefaultAsync(e => e.Id == id);

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
                                 .Include(d => d.UserProfile)
                                 .Skip((page - 1) * perPage)
                                 .Take(perPage)
                                 .ToListAsync();
        }  
        public async Task<IEnumerable<Division>> GetDivisionsByAreaSearch(int areaId, string filter, int page, int perPage)
        {
            return await context.Set<Division>()
                                .Where(d => d.AreaId == areaId && d.Title.Contains(filter))
                                .Include(d => d.UserProfile)
                                .Skip((page - 1) * perPage)
                                .Take(perPage)
                                .ToListAsync();
        }

        public new async Task<Division> Update(Division division)
        {
            var previousDivision = await context.Set<Division>().Include(d => d.UserProfile).FirstOrDefaultAsync(d => d.Id == division.Id);

            if (division.UserProfileId != 0 && division.UserProfileId != previousDivision.UserProfileId)
            {
                previousDivision.UserProfileId = division.UserProfileId;
                previousDivision.UserProfile = await context.Set<UserProfile>().FindAsync(previousDivision.UserProfileId);
            }

            previousDivision.Title = division.Title ?? previousDivision.Title;
            previousDivision.Description = division.Description ?? previousDivision.Description;

            

            await Task.Run(() => context.Set<Division>().Update(previousDivision));

            return previousDivision;

        }
    }
}
