using AutoMapper;
using Repository.UnitOfWork;
using System.Threading.Tasks;
using Util.Dtos;
using System.Linq;
using Util.Support.Requests.RiskImpact;
using Util.Support.Responses.RiskImpact;

namespace Service.Service.ServiceImpl
{
    public class RiskImpactService : IRiskImpactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RiskImpactService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetAllRiskImpactsResponse> GetAll(GetAllRiskImpactsRequest request)
        {
            var riskImpacts = await _unitOfWork.RiskImpacts.GetAll();

            return  new GetAllRiskImpactsResponse { RiskImpacts = riskImpacts.Select(riskImpact => _mapper.Map<RiskImpactDto>(riskImpact)) };
        }
    }
}
