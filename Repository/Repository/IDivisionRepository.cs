using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Support.Requests;
using Util.Support.Response;

namespace Repository.Repository
{
    public interface IDivisionRepository : IGenericRepository<Division, int>
    {
        Task<IEnumerable<Division>> GetDivisionsByArea(int? areaId, int page, int perPage);
        Task<int> GetDivisionsByAreaCount(int? areaId);
        Task<IEnumerable<Division>> GetDivisionsByAreaSearch(int? areaId, string filter, int page, int perPage);
        Task<int> GetDivisionsByAreaSearchCount(int? areaId, string filter);
    }
}
