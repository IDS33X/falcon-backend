using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Support.Requests.Control;

namespace FalconApi.Controllers
{
    [Route("falconapi/[controller]")]
    [ApiController]
    public class ControlController : ControllerBase
    {

        private readonly IControlService _controlService;

        public ControlController(IControlService controlService)
        {
            _controlService = controlService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddControlRequest request)
        {
            try
            {
                var response = await _controlService.Add(request);

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

        [HttpPut("Update")]
        public async Task<IActionResult> Update(EditControlRequest request)
        {
            try
            {
                var response = await _controlService.Update(request);

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

        [HttpGet("GetControlByCode")]
        public async Task<IActionResult> GetByCode([FromQuery] ControlByCodeRequest request)
        {
            var response = await _controlService.GetByCode(request);

            return Ok(response);
        }

        [HttpGet("GetControls")]
        public async Task<IActionResult> GetControls([FromQuery] GetControlsRequest request)
        {
            var response = await _controlService.GetControls(request);

            return Ok(response);
        }

        [HttpGet("GetControlsByRisk")]
        public async Task<IActionResult> GetControlsByRisk([FromQuery] GetControlsByRiskRequest request)
        {
            var response = await _controlService.GetControlsByRisk(request);

            return Ok(response);
        }

        [HttpGet("GetControlsByUser")]
        public async Task<IActionResult> GetControlsByUser([FromQuery] GetControlsByUserRequest request)
        {
            var response = await _controlService.GetControlsByUser(request);

            return Ok(response);
        }


        [HttpGet("GetControlsByRiskCategory")]
        public async Task<IActionResult> GetControlsByRiskCategory([FromQuery] GetControlsByRiskCategoryRequest request)
        {
            var response = await _controlService.GetControlsByRiskCategory(request);

            return Ok(response);
        }

        [HttpGet("SearchControlsByCode")]
        public async Task<IActionResult> GetControlsByCodeSearch([FromQuery] GetControlsByCodeSearchRequest request)
        {
            var response = await _controlService.GetControlsByCodeSearch(request);

            return Ok(response);
        }

    }
}
