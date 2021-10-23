using System.Threading.Tasks;
using Util.Dtos;
using Util.Dtos.DivisionDtos;
using Util.Support.Requests.Division;
using Util.Support.Responses.Division;

namespace Service.Service
{
    public interface IDivisionService
    {
        Task<AddDivisionResponse> Add(AddDivisionRequest request);
        Task<bool> Removed(int id);
        Task<DivisionReadDto> GetById(int id);
        Task<EditDivisionResponse> Update(EditDivisionRequest request);
        Task<DivisionsByAreaResponse> GetDivisionsByArea(DivisionsByAreaRequest request);
        Task<DivisionsByAreaSearchResponse> GetDivisionsByAreaAndSearch(DivisionsByAreaSearchRequest request);
    }
}
