using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var response = await _userControlService.Add(request);

            return Ok(response);
        }

        [HttpPost("AddRange")]
        public async Task<IActionResult> AddRange(AddRangeUserControlRequest request)
        {
            var response = await _userControlService.AddRange(request);

            return Ok(response);
        }

        [HttpPut("Remove")]
        public async Task<IActionResult> Remove(EditUserControlRequest request)
        {
            var response = await _userControlService.Remove(request);

            return Ok(response);
        }

        [HttpPut("RemoveRange")]
        public async Task<IActionResult> RemoveRange(EditRangeUserControlRequest request)
        {
            var response = await _userControlService.RemoveRange(request);

            return Ok(response);
        }
    }
}
