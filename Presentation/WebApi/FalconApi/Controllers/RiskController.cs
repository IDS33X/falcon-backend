using Microsoft.AspNetCore.Mvc;
using Service.Service;
using System;
using System.Threading.Tasks;
using Util.Exceptions;
using Util.Support.Requests.Risk;

namespace FalconApi.Controllers
{
    [Route("falconapi/[controller]")]
    [ApiController]
    public class RiskController : ControllerBase
    {
        private readonly IRiskService _riskService;
        public RiskController(IRiskService riskService)
        {
            _riskService = riskService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddRiskRequest request)
        {
            try
            {
                var response = await _riskService.Add(request);

                return Ok(response);
            }
            catch (AlreadyExistException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                string innerExceptionMessage = ex.InnerException?.Message;
                bool? missingChild1 = innerExceptionMessage == null ? null : innerExceptionMessage.StartsWith("The MERGE statement conflicted with the FOREIGN KEY constraint");
                bool? missingChild2 = innerExceptionMessage == null ? null : innerExceptionMessage.StartsWith("The INSERT statement conflicted with the FOREIGN KEY constraint");
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

        [HttpGet("GetRiskByCategory")]
        public async Task<IActionResult> GetRiskByCategory([FromQuery] GetRiskByCategoryRequest request)
        {
            var response = await _riskService.GetRiskByCategory(request);

            return Ok(response);
        }

        [HttpGet("GetRiskByCategoryAndCode")]
        public async Task<IActionResult> GetRiskByCategoryAndCode([FromQuery] GetRiskByCategoryAndCodeRequest request)
        {
            var response = await _riskService.GetRiskByCategoryAndCode(request);

            return Ok(response);
        }  
        
        [HttpGet("GetRiskByCategoryAndDescription")]
        public async Task<IActionResult> GetRiskByCategoryAndDescription([FromQuery] GetRiskByCategoryAndDescriptionRequest request)
        {
            var response = await _riskService.GetRiskByCategoryAndDescription(request);

            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(EditRiskRequest request)
        {
            try
            {
                var response = await _riskService.Update(request);

                return Ok(response);
            }
            catch (DoesNotExistException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception ex)
            {
                string innerExceptionMessage = ex.InnerException?.Message;
                bool? missingChild1 = innerExceptionMessage == null ? null : innerExceptionMessage.StartsWith("The MERGE statement conflicted with the FOREIGN KEY constraint");
                bool? missingChild2 = innerExceptionMessage == null ? null : innerExceptionMessage.StartsWith("The INSERT statement conflicted with the FOREIGN KEY constraint");
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
