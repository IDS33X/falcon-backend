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
    public class DivisionController : ControllerBase
    {
        private readonly IDivisionService _divisionService;
        public DivisionController(IDivisionService divisionService)
        {
            _divisionService = divisionService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(DivisionDto divisionDto)
        {
            divisionDto = await _divisionService.Add(divisionDto);

            return Ok(divisionDto);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var divisionDtos = await _divisionService.GetAll();

            return Ok(divisionDtos);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var divisionDto = await _divisionService.GetById(id);

                return Ok(divisionDto);
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
                var isRemoved = await _divisionService.Removed(id);

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
        public async Task<IActionResult> Update(DivisionDto divisionDto)
        {
            try
            {
                var isUpdated = await _divisionService.Update(divisionDto);

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
