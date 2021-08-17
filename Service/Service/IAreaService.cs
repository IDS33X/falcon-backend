using System.Threading.Tasks;
using Util.Dtos;
using Util.Support.Requests.Area;
using Util.Support.Responses.Area;

namespace Service.Service
{
    public interface IAreaService
    {
        Task<AddAreaResponse> Add(AddAreaRequest request);
        Task<bool> Removed(int id);
        Task<AreaDto> GetById(int id);
        Task<EditAreaResponse> Update(EditAreaRequest request);
        Task<GetAreasResponse> GetAreas(GetAreasRequest request);
        Task<GetAreasSearchResponse> GetAreasBySearch(GetAreasSearchRequest request);
    }
}
