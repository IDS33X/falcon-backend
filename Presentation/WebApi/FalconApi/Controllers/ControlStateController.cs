using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FalconApi.Controllers
{
    [Route("falconapi/[controller]")]
    [ApiController]
    public class ControlStateController : ControllerBase
    {
        private readonly IMControlStateService _controlStateService;

        public ControlStateController(IMControlStateService controlStateService)
        {
            _controlStateService = controlStateService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _controlStateService.GetAll();

            return Ok(response);
        }
    }
}
