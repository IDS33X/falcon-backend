using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Dtos;
using Util.Exceptions;

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
        public async Task<IActionResult> Add(EmployeeDto employeeDto)
        {
            employeeDto = await _employeeService.Add(employeeDto);

            return Ok(employeeDto);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var employeeDtos = await _employeeService.GetAll();

            return Ok(employeeDtos);
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
        public async Task<IActionResult> Update(EmployeeDto employeeDto)
        {
            try
            {
                var isUpdated = await _employeeService.Update(employeeDto);

                return Ok(isUpdated);
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
