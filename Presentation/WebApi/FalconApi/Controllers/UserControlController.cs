using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Exceptions;
using Util.Support.Requests.UserControl;

namespace FalconApi.Controllers
{
    [Route("falconapi/[controller]")]
    [ApiController]
    public class UserControlController : ControllerBase
    {
        private readonly IUserControlService _userControlService;

        public UserControlController(IUserControlService userControlService)
        {
            _userControlService = userControlService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddUserControlRequest request)
        {
            try
            {
                var response = await _userControlService.Add(request);

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
        public async Task<IActionResult> AddRange(AddRangeUserControlRequest request)
        {
            var response = await _userControlService.AddRange(request);

            return Ok(response);
        }

        [HttpPut("Remove")]
        public async Task<IActionResult> Remove(RemoveUserControlRequest request)
        {
            try
            {
                var response = await _userControlService.Remove(request);

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
        public async Task<IActionResult> RemoveRange(RemoveRangeUserControlRequest request)
        {
            var response = await _userControlService.RemoveRange(request);

            return Ok(response);
        }
    }
}
