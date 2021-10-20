using Microsoft.AspNetCore.Mvc;
using Service.Service;
using System.Threading.Tasks;
using Util.Support.Requests.MRole;

namespace FalconApi.Controllers
{
    [Route("falconapi/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMRoleService _roleService;

        public RoleController(IMRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] GetMRolesRequest request)
        {
            var response = await _roleService.GetAll(request);

            return Ok(response);
        }
    }
}
