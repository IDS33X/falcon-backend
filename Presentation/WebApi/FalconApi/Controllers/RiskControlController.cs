using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Support.Requests.RiskControl;

namespace FalconApi.Controllers
{
    [Route("falconapi/[controller]")]
    [ApiController]
    public class RiskControlController : ControllerBase
    {
        private readonly IRiskControlService _riskControlService;

        public RiskControlController(IRiskControlService riskControlService)
        {
            _riskControlService = riskControlService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddRiskControlRequest request)
        {
            var response = await _riskControlService.Add(request);

            return Ok(response);
        }

        [HttpPost("AddRange")]
        public async Task<IActionResult> AddRange(AddRangeRiskControlRequest request)
        {
            var response = await _riskControlService.AddRange(request);

            return Ok(response);
        }

        [HttpPut("Remove")]
        public async Task<IActionResult> Remove(EditRiskControlRequest request)
        {
            var response = await _riskControlService.Remove(request);

            return Ok(response);
        }

        [HttpPut("RemoveRange")]
        public async Task<IActionResult> RemoveRange(EditRangeRiskControlRequest request)
        {
            var response = await _riskControlService.RemoveRange(request);

            return Ok(response);
        }
    }
}
