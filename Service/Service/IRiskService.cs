using System.Threading.Tasks;
using Util.Support.Requests.Risk;
using Util.Support.Responses.Risk;

namespace Service.Service
{
    public interface IRiskService
    {
        Task<AddRiskResponse> Add(AddRiskRequest request);
        Task<GetRiskByCategoryResponse> GetRiskByCategory(GetRiskByCategoryRequest request);
        Task<GetRiskByCategoryAndCodeResponse> GetRiskByCategoryAndCode(GetRiskByCategoryAndCodeRequest request);
        Task<GetRiskByCategoryAndDescriptionResponse> GetRiskByCategoryAndDescription(GetRiskByCategoryAndDescriptionRequest request);
        Task<EditRiskResponse> Update(EditRiskRequest request);
    }
}
