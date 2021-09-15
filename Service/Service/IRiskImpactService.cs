using System.Threading.Tasks;
using Util.Support.Requests.RiskImpact;
using Util.Support.Responses.RiskImpact;

namespace Service.Service
{
    public interface IRiskImpactService
    {
        Task<GetAllRiskImpactsResponse> GetAll(GetAllRiskImpactsRequest request);
    }
}
