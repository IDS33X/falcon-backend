using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Support.Requests.Control;

namespace FalconApi.Controllers
{
    [Route("falconapi/[controller]")]
    [ApiController]
    public class ControlController : ControllerBase
    {

        private readonly IControlService _controlService;

        public ControlController(IControlService controlService)
        {
            _controlService = controlService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddControlRequest request)
        {
            var response = await _controlService.Add(request);

            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(EditControlRequest request)
        {
            var response = await _controlService.Update(request);

            return Ok(response);
        }

        [HttpGet("GetControlByCode")]
        public async Task<IActionResult> GetByCode([FromQuery] ControlByCodeRequest request)
        {
            var response = await _controlService.GetByCode(request);

            return Ok(response);
        }

        [HttpGet("GetControls")]
        public async Task<IActionResult> GetControls([FromQuery] GetControlsRequest request)
        {
            var response = await _controlService.GetControls(request);

            return Ok(response);
        }

        [HttpGet("GetControlsByRisk")]
        public async Task<IActionResult> GetControlsByRisk(GetControlsByRiskRequest request)
        {
            var response = await _controlService.GetControlsByRisk(request);

            return Ok(response);
        }

        [HttpGet("GetControlsByUser")]
        public async Task<IActionResult> GetControlsByUser(GetControlsByUserRequest request)
        {
            var response = await _controlService.GetControlsByUser(request);

            return Ok(response);
        }

    }
}
