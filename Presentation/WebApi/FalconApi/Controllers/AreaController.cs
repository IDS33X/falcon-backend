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
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;
        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AreaDto areaDto)
        {
            areaDto = await _areaService.Add(areaDto);

            return Ok(areaDto);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var areaDtos = await _areaService.GetAll();

            return Ok(areaDtos);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var areaDto = await _areaService.GetById(id);

                return Ok(areaDto);
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
                var isRemoved = await _areaService.Removed(id);

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
        public async Task<IActionResult> Update(AreaDto areaDto)
        {
            try
            {
                var isUpdated = await _areaService.Update(areaDto);

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
