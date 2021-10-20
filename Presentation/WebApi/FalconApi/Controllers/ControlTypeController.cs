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
    public class ControlTypeController : ControllerBase
    {
        private readonly IMControlTypeService _controlTypeService;

        public ControlTypeController(IMControlTypeService controlTypeService)
        {
            _controlTypeService = controlTypeService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _controlTypeService.GetAll();

            return Ok(response);
        }
    }
}
