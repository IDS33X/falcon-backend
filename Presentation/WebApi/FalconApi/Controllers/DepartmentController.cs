using Microsoft.AspNetCore.Mvc;
using Service.Service;
using System;
using System.Threading.Tasks;
using Util.Exceptions;
using Util.Support.Requests.Department;

namespace FalconApi.Controllers
{
    [Route("falconapi/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddDepartmentRequest request)
        {
            var response = await _departmentService.Add(request);

            return Ok(response);
        }

        [HttpGet("GetDepartmentsByDivision")]
        public async Task<IActionResult> GetDepartmentsByDivision([FromQuery] DepartmentsByDivisionRequest request)
        {
            var response = await _departmentService.GetDepartmentsByDivision(request);

            return Ok(response);
        }
        [HttpGet("SearchDepartmentsByDivision")]
        public async Task<IActionResult> GetDepartmentsByDivisionAndSearch([FromQuery] DepartmentsByDivisionSearchRequest request)
        {
            var response = await _departmentService.GetDepartmentsByDivisionAndSearch(request);

            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var departmentDto = await _departmentService.GetById(id);

                return Ok(departmentDto);
            }
            catch (DoesNotExistException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var isRemoved = await _departmentService.Removed(id);

                return Ok(isRemoved);
            }
            catch (DoesNotExistException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(EditDepartmentRequest request)
        {
            try
            {
                var response = await _departmentService.Update(request);

                return Ok(response);
            }
            catch (DoesNotExistException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
