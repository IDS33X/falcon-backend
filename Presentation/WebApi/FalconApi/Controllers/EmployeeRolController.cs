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
    public class EmployeeRolController : ControllerBase
    {
        private readonly IEmployeeRolService _employeeRolService;

        public EmployeeRolController(IEmployeeRolService employeeRolService)
        {
            _employeeRolService = employeeRolService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var rols = await _employeeRolService.GetAll();

            return Ok(rols);
        }
    }
}
