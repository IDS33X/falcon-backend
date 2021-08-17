using Microsoft.AspNetCore.Mvc;
using Service.Service;
using System;
using System.Threading.Tasks;
using Util.Exceptions;
using Util.Support.Requests.Employee;

namespace FalconApi.Controllers
{
    [Route("falconapi/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddEmployeeRequest request)
        {
            var response = await _employeeService.Add(request);

            return Ok(response);
        }

        [HttpGet("GetEmployeesByDepartment")]
        public async Task<IActionResult> GetEmployeesByDepartment([FromQuery] EmployeesByDepartmentRequest request)
        {
            var response = await _employeeService.GetEmployeesByDepartment(request);

            return Ok(response);
        } 
        [HttpGet("SearchEmployeesByDepartment")]
        public async Task<IActionResult> GetEmployeesByDepartmentAndSearch([FromQuery] EmployeesByDepartmentSearchRequest request)
        {
            var response = await _employeeService.GetEmployeesByDepartmentAndSearch(request);

            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var employeeDto = await _employeeService.GetById(id);

                return Ok(employeeDto);
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
                var isRemoved = await _employeeService.Removed(id);

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
        public async Task<IActionResult> Update(EditEmployeeRequest request)
        {
            try
            {
                var response = await _employeeService.Update(request);

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
