using Microsoft.AspNetCore.Mvc;
using Service.Service;
using System;
using System.Threading.Tasks;
using Util.Exceptions;
using Util.Support.Requests.Division;

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
        public async Task<IActionResult> Add(AddDivisionRequest request)
        {
            var response = await _divisionService.Add(request);

            return Ok(response);
        }

        [HttpGet("GetDivisionsByArea")]
        public async Task<IActionResult> GetDivisionsByArea([FromQuery] DivisionsByAreaRequest request)
        {
            var response = await _divisionService.GetDivisionsByArea(request);

            return Ok(response);
        } 
        [HttpGet("SearchDivisionsByArea")]
        public async Task<IActionResult> GetDivisionsByAreaAndSearch([FromQuery] DivisionsByAreaSearchRequest request)
        {
            var response = await _divisionService.GetDivisionsByAreaAndSearch(request);

            return Ok(response);
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
        public async Task<IActionResult> Update(EditDivisionRequest request)
        {
            try
            {
                var response = await _divisionService.Update(request);

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
