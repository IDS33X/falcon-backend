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
    public class AutomationLevelController : ControllerBase
    {
        private readonly IMAutomationLevelService _automationLevelService;

        public AutomationLevelController(IMAutomationLevelService automationLevelService)
        {
            _automationLevelService = automationLevelService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _automationLevelService.GetAll();

            return Ok(response);
        }
    }
}
