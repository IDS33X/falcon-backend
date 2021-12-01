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
    public class AreaRepository : GenericRepository<Area, int?>, IAreaRepository
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
                                .Where(a => a.Title.Contains(filter))
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
            return await context.Set<Area>().CountAsync(a => a.Title.Contains(filter));
        }

        public new async Task<Area> Update(Area area)
        {
            var previousArea = await context.Set<Area>().FirstOrDefaultAsync(a => a.Id == area.Id);

            if(previousArea == null)
            {
                throw new DoesNotExistException("Not Exist");
            }

            if(area.Title != null)
            {
                var areaWithSameTitle = await context.Set<Area>().Where(a => a.Title == area.Title).FirstOrDefaultAsync();

                if(areaWithSameTitle != null && area.Id != areaWithSameTitle.Id)
                {
                    throw new AlreadyExistException("An area with that Title already exists");
                }
            }

            previousArea.Title = area.Title ?? previousArea.Title;
            previousArea.Description = area.Description ?? previousArea.Description;

            await Task.Run(() => context.Set<Area>().Update(previousArea));

            return previousArea;
        }


        public async new Task<Area> Add(Area area)
        {
            var sameTitle = await context.Set<Area>().FirstOrDefaultAsync(a => a.Title == area.Title);

            if(sameTitle != null)
            {
                throw new AlreadyExistException($"An area with that title already exists, change the TITLE:({sameTitle.Title}) to another one.");
            }

            await context.Set<Area>().AddAsync(area);

            return area;
        }

    }
}
