using Microsoft.AspNetCore.Mvc;
using Service.Service;
using System.Threading.Tasks;
using Util.Support.Requests.RiskImpact;

namespace FalconApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiskImpactController : ControllerBase
    {
        private readonly IRiskImpactService _riskImpactService;
        public RiskImpactController(IRiskImpactService riskImpactService)
        {
            _riskImpactService = riskImpactService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllRiskImpactsRequest request)
        {
           return Ok( await _riskImpactService.GetAll(request));
        }
    }
}
