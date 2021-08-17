using Microsoft.AspNetCore.Mvc;
using Service.Service;
using System.Threading.Tasks;
using Util.Support.Requests.EmployeeRol;

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
        public async Task<IActionResult> GetAll([FromQuery] GetEmployeeRolsRequest request)
        {
            var response = await _employeeRolService.GetAll(request);

            return Ok(response);
        }
    }
}
