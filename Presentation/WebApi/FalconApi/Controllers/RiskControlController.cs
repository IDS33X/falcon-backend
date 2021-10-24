using Microsoft.AspNetCore.Mvc;
using Service.Service;
using System;
using System.Threading.Tasks;
using Util.Exceptions;
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
            try
            {
                var response = await _riskControlService.Add(request);

                return Ok(response);
            }
            catch (AlreadyExistException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Exception message: {ex.Message}\n\n{(ex.InnerException?.Message != null ? $"InnerException message: {ex.InnerException.Message}" : "")}");
            }
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
            try
            {
                var response = await _riskControlService.Remove(request);

                return Ok(response);
            }
            catch (DoesNotExistException ex)
            {
                return NotFound(ex.Message);
            }
            catch (AlreadyExistException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Exception message: {ex.Message}\n\n{(ex.InnerException?.Message != null ? $"InnerException message: {ex.InnerException.Message}" : "")}");
            }
        }

        [HttpPut("RemoveRange")]
        public async Task<IActionResult> RemoveRange(EditRangeRiskControlRequest request)
        {
            var response = await _riskControlService.RemoveRange(request);

            return Ok(response);
        }
    }
}
