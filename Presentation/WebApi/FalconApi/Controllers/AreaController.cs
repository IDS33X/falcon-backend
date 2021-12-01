using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service;
using System;
using System.Threading.Tasks;
using Util.Exceptions;
using Util.Support.Requests.Area;

namespace FalconApi.Controllers
{
    //[Authorize]
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
        public async Task<IActionResult> Add(AddAreaRequest request)
        {
            try
            {
                var response = await _areaService.Add(request);

                return Ok(response);
            }
            catch (AlreadyExistException e)
            {
                return StatusCode(500, $"Exception message: {e.Message}");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            
        }

        //[Authorize(Roles = "Control Interno")]
        [HttpGet("GetAreas")]
        public async Task<IActionResult> GetAreas([FromQuery] GetAreasRequest request)
        {
            var response = await _areaService.GetAreas(request);

            return Ok(response);
        }  

        [HttpGet("SearchAreas")]
        public async Task<IActionResult> GetAreasBySearch([FromQuery] GetAreasSearchRequest request)
        {
            var response = await _areaService.GetAreasBySearch(request);

            return Ok(response);
        }

        //[Authorize(Roles = "Analista de Riesgo")]
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
        public async Task<IActionResult> Update(EditAreaRequest request)
        {
            try
            {
                var response = await _areaService.Update(request);

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
