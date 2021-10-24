using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;

namespace Repository.Repository
{
    public interface IAreaRepository : IGenericRepository<Area, int>
    {
        Task<IEnumerable<Area>> GetAreas(int page, int perPage);
        Task<int> GetAreasCount();
        Task<IEnumerable<Area>> GetAreasSearch(string filter, int page, int perPage);
        Task<int> GetAreasSearchCount(string filter);
        
    }
}
