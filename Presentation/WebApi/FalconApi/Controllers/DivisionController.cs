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
            try
            {
                var response = await _divisionService.Add(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                string innerExceptionMessage = ex.InnerException?.Message;
                bool? missingChild1 = innerExceptionMessage.StartsWith("The MERGE statement conflicted with the FOREIGN KEY constraint");
                bool? missingChild2 = innerExceptionMessage.StartsWith("The INSERT statement conflicted with the FOREIGN KEY constraint");
                if ((missingChild1 != null && missingChild1 == true) || (missingChild2 != null && missingChild2 == true))
                {
                    string aux = innerExceptionMessage.Substring(innerExceptionMessage.IndexOf("dbo.") + 4);
                    int length = aux.LastIndexOf('"');
                    string missingEntityName = aux.Substring(0, length);
                    if (missingEntityName.StartsWith("M") && char.IsUpper(missingEntityName[1]))
                    {
                        missingEntityName = missingEntityName.Substring(1);
                    }
                    string errorMessage = $"Can not find any {missingEntityName} with the {missingEntityName}Id provided";
                    return NotFound(errorMessage);
                }
                return StatusCode(500, $"Exception message: {ex.Message}\n\n{(innerExceptionMessage != null ? $"InnerException message: {innerExceptionMessage}" : "")}");
            }
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
                return NotFound(e.Message);
            }
            catch (Exception ex)
            {
                string innerExceptionMessage = ex.InnerException?.Message;
                bool? missingChild1 = innerExceptionMessage.StartsWith("The MERGE statement conflicted with the FOREIGN KEY constraint");
                bool? missingChild2 = innerExceptionMessage.StartsWith("The INSERT statement conflicted with the FOREIGN KEY constraint");
                if ((missingChild1 != null && missingChild1 == true) || (missingChild2 != null && missingChild2 == true))
                {
                    string aux = innerExceptionMessage.Substring(innerExceptionMessage.IndexOf("dbo.") + 4);
                    int length = aux.LastIndexOf('"');
                    string missingEntityName = aux.Substring(0, length);
                    if (missingEntityName.StartsWith("M") && char.IsUpper(missingEntityName[1]))
                    {
                        missingEntityName = missingEntityName.Substring(1);
                    }
                    string errorMessage = $"Can not find any {missingEntityName} with the {missingEntityName}Id provided";
                    return NotFound(errorMessage);
                }
                return StatusCode(500, $"Exception message: {ex.Message}\n\n{(innerExceptionMessage != null ? $"InnerException message: {innerExceptionMessage}" : "")}");
            }

        }
    }
}
